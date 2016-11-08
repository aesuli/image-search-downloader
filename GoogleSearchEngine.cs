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

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace ImageSearchDownloader
{
    public class GoogleSearchEngine : ISearchEngine
    {
        public string Name
        {
            get
            {
                return "Google";
            }
        }

        private static string userAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36";

        static int resultPageTimeout = 60000;

        public IEnumerator<IImageSearchResult> ProcessQuery(string query, int maxResults)
        {
            string baseUri = "https://www.google.com/search?tbm=isch";
            baseUri += "&q=";
            string encodedQuery = HttpUtility.UrlEncode(query);
            var resultsPage = Path.GetTempFileName();
            WebDownloader.DownloadRemoteFile(baseUri + encodedQuery, resultsPage, userAgent, null, resultPageTimeout);
            string pageContent = File.ReadAllText(resultsPage);
            int count = 0;
            while (pageContent != null)
            {
                var resultEnumerator = ParseResultPage(pageContent);
                int prevCount = count;
                while (resultEnumerator.MoveNext())
                {
                    ++count;
                    yield return resultEnumerator.Current;
                    if (count >= maxResults)
                        yield break;
                }
                if (count!=prevCount && count%20==0 && count < maxResults)
                {
                    try
                    {
                        WebDownloader.DownloadRemoteFile(baseUri + encodedQuery + "&start=" + count, resultsPage, userAgent, null, resultPageTimeout);
                        pageContent = File.ReadAllText(resultsPage);
                    }
                    catch
                    {
                        pageContent = null;
                    }
                }
                else
                    pageContent = null;
            }
        }

        private IEnumerator<IImageSearchResult> ParseResultPage(string pageContent)
        {
            var imgRefMatches = Regex.Matches(pageContent, "\"ru\":\"([^\"]+)\"");
            var imgMatches = Regex.Matches(pageContent, "\"ou\":\"([^\"]+)\"");

            for (int i = 0; i < imgMatches.Count; ++i)
                    yield return new ImageSearchResult(HttpUtility.UrlDecode(imgMatches[i].Groups[1].Value), HttpUtility.UrlDecode(imgRefMatches[i].Groups[1].Value));
        }
    }
}
