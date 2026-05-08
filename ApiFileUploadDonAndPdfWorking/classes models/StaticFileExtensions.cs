using Microsoft.Extensions.FileProviders;

namespace ApiFileUploadDonAndPdfWorking.classes_models
{
    public static class StaticFileExtensions
    {
        public static IApplicationBuilder UseCustomStaticFiles(
            this IApplicationBuilder app,
            string physicalFolder,
            string requestPath)
        {

            Path.GetDirectoryName()
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), physicalFolder);

            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(fullPath),
                RequestPath = requestPath
            });

            return app;
        }
    }
}
