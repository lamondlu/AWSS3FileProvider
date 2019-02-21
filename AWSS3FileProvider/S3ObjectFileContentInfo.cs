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
            _stream.Position = 0;
        }

        public bool Exists => throw new NotImplementedException();

        public long Length => throw new NotImplementedException();

        public string PhysicalPath => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public DateTimeOffset LastModified => throw new NotImplementedException();

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
