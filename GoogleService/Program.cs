using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Analytics.v3;
using Google.Apis.Services;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Util.Store;
using System.Configuration;

namespace GoogleService
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Google Analytics API: Service Account sample");
            Console.WriteLine("==========================");

            string serviceAccountEmail =
                ConfigurationSettings.AppSettings["ServiceAccountEmail"];

            var escapedFilePathToCertificate = "C:\\key.p12.pfx";
            var certificatePassword = "notasecret";
            var certificate = new X509Certificate2(
                escapedFilePathToCertificate,
                certificatePassword,
                X509KeyStorageFlags.Exportable);

            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = new[] { AnalyticsService.Scope.Analytics }
               }.FromCertificate(certificate));

            // Create the service.
            var service = new AnalyticsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ConfigurationSettings.AppSettings["ApplicationName"]
                });

            var profileId = ConfigurationSettings.AppSettings["ProfileId"];
            var list = service.Data.Ga.Get("ga:" + profileId,
                "2014-01-01", // Start date.
                "2014-01-15", // End date.
                "ga:visitors") // Metrics.
                .Execute();

            Console.WriteLine("  Visitors: " + list.TotalsForAllResults["ga:visitors"]);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
