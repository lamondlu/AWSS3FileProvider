# AzureFileProvider
A library to expose object in the AWS S3 bucket to ASP.NET Core Application with IFileProvider.

# How to use it?
- Add AWS S3 setting in the appSetting.json

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AWSS3Setting": {
    "AccessKeyId": "xxx",
    "AccessKeySecret": "xxx++k4UvbOfb",
    "RegionName": "us-east-1",
    "BucketName": "lamondtest"
  },
  "AllowedHosts": "*"
}


```

- Enable the S3FileProvider in the <code>Configure</code> method

```
  public void Configure(IApplicationBuilder app, IHostingEnvironment env)
  {
      AWSS3Setting o = new AWSS3Setting();
      Configuration.Bind("AWSS3Setting", o);

      app.UseStaticFiles(new StaticFileOptions
      {
          FileProvider = new S3FileProvider(o),
          RequestPath = "/files"
      });

      app.UseMvc();
  }
```

That's all. 
