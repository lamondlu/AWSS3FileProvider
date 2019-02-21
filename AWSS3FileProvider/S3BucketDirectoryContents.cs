using Microsoft.Extensions.FileProviders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AWSS3FileProvider
{
    public class S3BucketDirectoryContents : IDirectoryContents
    {
        public List<IFileInfo> _files = null;

        public S3BucketDirectoryContents(List<IFileInfo> files)
        {
            _files = files;
        }

        public bool Exists
        {
            get
            {
                return true;
            }
        }

        public IEnumerator<IFileInfo> GetEnumerator()
        {
            return _files.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _files.GetEnumerator();
        }
    }
}
