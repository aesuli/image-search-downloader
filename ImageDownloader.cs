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
using System.Text.RegularExpressions;

namespace ImageSearchDownloader
{
    public class ImageDownloader : IImageDownloader
    {
        static int imageDownloadTimeout = 60000;
        public void DownloadImage(IImageSearchResult result, DirectoryInfo destination, string filenamePrefix, bool downloadSourcePage)
        {
            var imageUri = result.ImageUri;
            var filename = imageUri.Segments[imageUri.Segments.Length-1];
            filename = Regex.Replace(filename, "[\\/:*?\"<>]", "_");
            var destinationPath = destination.FullName + Path.DirectorySeparatorChar + filenamePrefix+filename;
            WebDownloader.DownloadRemoteFile(imageUri.AbsoluteUri, destinationPath, null, null, imageDownloadTimeout);
             
            if (downloadSourcePage)
            {
                var pageUri = result.SourcePageUri;
                destinationPath = destination.FullName + Path.DirectorySeparatorChar + "html";
                if (!Directory.Exists(destinationPath))
                    Directory.CreateDirectory(destinationPath);
                destinationPath+= Path.DirectorySeparatorChar+filenamePrefix + filename+".html";
                WebDownloader.DownloadRemoteFile(pageUri.AbsoluteUri, destinationPath, null, null, imageDownloadTimeout);
            }
        }
    }
}
