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

        public bool Exists => throw new NotImplementedException();

        public long Length => throw new NotImplementedException();

        public string PhysicalPath => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public DateTimeOffset LastModified => throw new NotImplementedException();

        public bool IsDirectory => throw new NotImplementedException();

        public Stream CreateReadStream()
        {
            throw new NotImplementedException();
        }
    }
}
