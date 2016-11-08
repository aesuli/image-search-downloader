// Copyright (C) 2016 Andrea Esuli (andrea@esuli.it)
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ImageSearchDownloader
{
    public class QueryProcessor
    {
        private Queue<string> queries;
        private bool running;
        private Thread processor;
        private ISearchEngine [] searchEngines;
        private int[] selectedSearchEngines;
        private IImageDownloader imageDownloader;
        private DirectoryInfo destination;
        private bool downloadSourcePage;
        private EventHandler stopNotification;
        private EventHandler<string> queryNotification;
        private EventHandler<string> downloadNotification;
        private int maxResults;

        public QueryProcessor(ISearchEngine [] searchEngines, int [] seletectedSearchEngines, DirectoryInfo destination, bool downloadSourcePage, int maxResults, EventHandler<string> queryNotification, EventHandler<string> downloadNotification, EventHandler stopNotification)
        {
            queries = new Queue<string>();
            running = false;
            processor = new Thread(this.Run);
            this.searchEngines = searchEngines;
            this.selectedSearchEngines = seletectedSearchEngines;
            this.destination = destination;
            imageDownloader = new ImageDownloader();
            this.downloadSourcePage = downloadSourcePage;
            this.stopNotification = stopNotification;
            this.queryNotification = queryNotification;
            this.downloadNotification = downloadNotification;
            this.maxResults = maxResults;
        }

        public void AddQuery(string query)
        {
            lock (query)
            {
                queries.Enqueue(query);
            }
        }

        public void Start()
        {
            running = true;
            processor.Start();
        }

        public void Stop()
        {
            running = false;
            do Thread.Sleep(100);
            while (processor.ThreadState == ThreadState.Running);
        }

        private void Run()
        {
            try
            {
                running = true;
                while (running && queries.Count > 0)
                {
                    string query;
                    lock (queries)
                    {
                        query = queries.Peek().Trim();
                    }
                    var queryDestination = new DirectoryInfo(destination.FullName + Path.DirectorySeparatorChar + query);
                    queryDestination.Create();
                    foreach (var index in selectedSearchEngines)
                    {
                        using (
                            var infoFile =
                                File.CreateText(queryDestination.FullName + Path.DirectorySeparatorChar + "result_" +
                                                searchEngines[index].Name + ".txt"))
                        using (var resultsEnumerator = searchEngines[index].ProcessQuery(query, maxResults))
                        {
                            infoFile.WriteLine("query: " + query);
                            queryNotification(this, query);
                            int count = 0;
                            while (running && resultsEnumerator.MoveNext())
                            {
                                var result = resultsEnumerator.Current;
                                infoFile.WriteLine("result " + count + " img: " + result.ImageUri);
                                infoFile.WriteLine("result " + count + " page: " + result.SourcePageUri);
                                try
                                {
                                    imageDownloader.DownloadImage(result, queryDestination,
                                        searchEngines[index].Name + "_" + count + "_", downloadSourcePage);
                                }
                                catch
                                {
                                }
                                downloadNotification(this, result.ImageUri.ToString());
                                ++count;
                            }
                        }
                    }
                    if (running)
                        queries.Dequeue();
                }
                running = false;
            }
            finally
            {
                stopNotification(this, null);
            }
        }

        public List<string> PendingQueries
        {
            get
            {
                lock (queries)
                {
                    return new List<string>(queries);
                }
            }
        }
    }
}
