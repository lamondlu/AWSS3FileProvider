using Amazon.S3.Model;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AWSS3FileProvider
{
    public class S3ObjectFileContentInfo : IFileInfo
    {
        private Stream _stream;

        public S3ObjectFileContentInfo(Stream stream)
        {
            _stream = stream;
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
                return _stream.Length;
            }
        }

        public string PhysicalPath
        {
            get
            {
                return string.Empty;
            }
        }

        public string Name
        {
            get
            {
                return string.Empty;
            }
        }

        public DateTimeOffset LastModified
        {
            get
            {
                return DateTime.Now;
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
            return _stream;
        }
    }
}
