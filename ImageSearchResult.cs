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

namespace ImageSearchDownloader
{
    public class ImageSearchResult : IImageSearchResult
    {
        private Uri imageUri;
        private Uri pageUri;

        public ImageSearchResult(string imageUri, string pageUri)
        {
            try
            {
                this.imageUri = new Uri(imageUri);
                this.pageUri = new Uri(pageUri);
            }
            catch
            {
            }
        }

        public Uri ImageUri
        {
            get
            {
                return imageUri;
            }
        }

        public Uri SourcePageUri
        {
            get
            {
                return pageUri;
            }
        }
    }
}
