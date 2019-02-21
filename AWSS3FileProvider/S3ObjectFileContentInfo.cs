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
        private S3Object _fileInfo;
        private Stream _stream;

        public S3ObjectFileContentInfo(S3Object fileInfo, Stream stream)
        {
            _fileInfo = fileInfo;
            _stream = stream;
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
