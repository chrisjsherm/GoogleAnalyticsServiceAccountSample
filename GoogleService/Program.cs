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
            Console.WriteLine("============================================");

            // Service account set up in the Google Developer Console.
            string serviceAccountEmail =
                ConfigurationSettings.AppSettings["ServiceAccountEmail"];

            /*
             * Certificate from Service Account saved under my Windows profile 
             * in the (hidden) AppData/Roaming folder.
             */
            var pathToCertificate = 
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "\\" + ConfigurationSettings.AppSettings["CertificateName"];

            // Password for the certificate provided by Google upon download.
            var certificatePassword = "notasecret";

            var certificate = new X509Certificate2(
                pathToCertificate,
                certificatePassword,
                X509KeyStorageFlags.Exportable);

            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = new[] { AnalyticsService.Scope.AnalyticsReadonly }
               }.FromCertificate(certificate));

            var service = new AnalyticsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ConfigurationSettings.AppSettings["ApplicationName"]
                });

            var profileId = ConfigurationSettings.AppSettings["ProfileId"];

            string metricsStartDate = "2014-01-14";
            string metricsEndDate = "2014-01-16";
            string metrics = "ga:visitors";

            var analyticsData = service.Data.Ga.Get("ga:" + profileId,
                metricsStartDate,
                metricsEndDate,
                metrics)
                .Execute();

            Console.WriteLine("   Visitors: " + analyticsData.TotalsForAllResults["ga:visitors"]);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
