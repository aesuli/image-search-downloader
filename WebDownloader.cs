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

using System.IO;
using System.Net;
using System.Threading;

namespace ImageSearchDownloader
{
    public class WebDownloader
    {
        public static void DownloadRemoteFile(string uri, string fileName, string userAgent = null, Cookie cookie = null, int timeout = Timeout.Infinite)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.UserAgent = userAgent;
            if (cookie != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookie);
            }
            request.Timeout = timeout;
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
            }

            if (response != null)
            {
                if (response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect)
                {
                    try
                    {
                        using (Stream inputStream = response.GetResponseStream())
                        using (Stream outputStream = File.OpenWrite(fileName))
                        {
                            inputStream.ReadTimeout = timeout;
                            byte[] buffer = new byte[4096];
                            int bytesRead;
                            do
                            {
                                bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                                outputStream.Write(buffer, 0, bytesRead);
                            } while (bytesRead != 0);
                        }
                    }
                    catch
                    {
                    }
                }
                response.Dispose();
            }
        }
    }
}
