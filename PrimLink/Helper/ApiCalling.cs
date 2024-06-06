using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PrimLink.Helper
{
    public static class ApiCalling
    {
        public static Tuple<string, string> RunPostAsync(string URL, string Key, string Message)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // var message = "{\"address\": {\"regionCode\": \"US\",\"locality\": \"View\",\"addressLines\": [\"1900 Amphitheatre Pkwy\"]},\"enableUspsCass\": false}";

            var res = client.PostAsync(URL + Key, new StringContent(Message));


            try
            {
                res.Result.EnsureSuccessStatusCode();
                return new Tuple<string, string>(res.Result.StatusCode.ToString(), res.Result.Content.ReadAsStringAsync().Result.ToString());
            }
            catch (Exception ex)
            {

                return new Tuple<string, string>("500", res.Result.Content.ReadAsStringAsync().Result.ToString());

            }
        }


        public static Tuple<string, string> RunGetAsync(string URL, string Key)
        {

            HttpClient client = new HttpClient();
            var res = client.GetAsync(URL + Key);


            try
            {
                res.Result.EnsureSuccessStatusCode();
                return new Tuple<string, string>(res.Result.StatusCode.ToString(), res.Result.Content.ReadAsStringAsync().Result.ToString());
            }
            catch (Exception ex)
            {

                return new Tuple<string, string>("500", res.Result.Content.ReadAsStringAsync().Result.ToString());

            }
        }


        public static Tuple<string, string> RunGetAsync_Header(string URL)
        {



            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Basic Nzg2MmVhOGItMWM3OS00MDcwLWFiOTAtYjdmYWZlZWY2NDUw");
            client.DefaultRequestHeaders.TryAddWithoutValidation("partner-token", "e9f5e172dc3d4991acc5f3f238fb4d6b");
            var res = client.GetAsync(URL);


            try
            {
                res.Result.EnsureSuccessStatusCode();
                return new Tuple<string, string>(res.Result.StatusCode.ToString(), res.Result.Content.ReadAsStringAsync().Result.ToString());
            }
            catch (Exception ex)
            {

                return new Tuple<string, string>("500", res.Result.Content.ReadAsStringAsync().Result.ToString());

            }
        }

    }
}


