using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace AWSS3FileProvider
{
    public class S3FileProvider : IFileProvider
    {
        private AWSS3Setting _setting = null;

        public S3FileProvider(AWSS3Setting setting)
        {
            _setting = setting;

            if (_setting == null)
            {
                throw new ArgumentNullException("The aws setting is missing.");
            }

            if (string.IsNullOrWhiteSpace(_setting.AccessKeyId))
            {
                throw new ArgumentNullException("The aws access key id is missing in the config.");
            }

            if (string.IsNullOrWhiteSpace(_setting.AccessKeySecret))
            {
                throw new ArgumentNullException("The aws access key secret is missing in the config.");
            }

            if (string.IsNullOrWhiteSpace(_setting.BucketName))
            {
                throw new ArgumentNullException("The bucket name is missing in the config.");
            }

            if (string.IsNullOrWhiteSpace(_setting.RegionName))
            {
                throw new ArgumentNullException("The region is missing in the config.");
            }

        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            using (var client = GetClient())
            {
                ListObjectsRequest request = new ListObjectsRequest();
                request.BucketName = _setting.BucketName;

                ListObjectsResponse response = client.ListObjectsAsync(request).Result;

                List<IFileInfo> files = new List<IFileInfo>();

                foreach (S3Object entry in response.S3Objects)
                {
                    files.Add(new S3ObjectFileInfo(entry));
                }

                return new S3BucketDirectoryContents(files);
            }
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            using (var client = GetClient())
            {
                GetObjectRequest request = new GetObjectRequest();
                request.BucketName = _setting.BucketName;
                request.Key = subpath.Substring(1);

                GetObjectResponse response = client.GetObjectAsync(request).Result;
                var stream = response.ResponseStream;

                return new S3ObjectFileContentInfo(stream);
            }
        }

        public IChangeToken Watch(string filter)
        {
            throw new NotImplementedException();
        }

        private AmazonS3Client GetClient()
        {
            return new AmazonS3Client(_setting.AccessKeyId, _setting.AccessKeySecret, RegionEndpoint.GetBySystemName(_setting.RegionName));
        }
    }
}
