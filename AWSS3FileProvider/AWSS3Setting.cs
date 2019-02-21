using System;
using System.Collections.Generic;
using System.Text;

namespace AWSS3FileProvider
{
    public class AWSS3Setting
    {
        public string AccessKeyId { get; set; }

        public string AccessKeySecret { get; set; }

        public string RegionName { get; set; }

        public string BucketName { get; set; }
    }
}
