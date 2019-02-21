using Amazon.S3.Model;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AWSS3FileProvider
{
    public class S3ObjectFileInfo : IFileInfo
    {
        private S3Object _fileInfo;

        public S3ObjectFileInfo(S3Object fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public bool Exists
        {
            get
            {
                return true;
            }
        }

        public long Length
        {
            get
            {
                return _fileInfo.Size;
            }
        }

        public string PhysicalPath
        {
            get
            {
                return _fileInfo.Key;
            }
        }

        public string Name
        {
            get
            {
                return _fileInfo.Key;
            }
        }

        public DateTimeOffset LastModified
        {
            get
            {
                return _fileInfo.LastModified;
            }
        }

        public bool IsDirectory
        {
            get
            {
                return false;
            }
        }

        public Stream CreateReadStream()
        {
            throw new NotImplementedException();
        }
    }
}
