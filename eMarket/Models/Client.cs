using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;

namespace eMarket.Models
{
    public class Client : IDisposable
    {
        private readonly string DOMAIN_URL = string.Empty;
        private static Client client;
        private HttpClient httpClient;
        private Client()
        {
            DOMAIN_URL = WebConfigurationManager.AppSettings["RestServer"];
            httpClient = new HttpClient();
        }

        public static Client Current
        {
            get
            {
                if (client == null)
                    client = new Client();

                return client;
            }
        }

        public T GetDataAsync<T>(string url) {
            Uri apiUrl = new Uri(new Uri(DOMAIN_URL), url);
            T value = default(T);

            var getDataTask = httpClient.GetAsync(apiUrl.AbsoluteUri)
                .ContinueWith(response=> 
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var readResult = result.Content.ReadAsAsync<T>();
                        readResult.Wait();

                        value = readResult.Result;
                    }
                });

            getDataTask.Wait();

            return value;
        }

        ~Client()
        {
            if (client != null)
                client.Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(client);
        }
    }
}