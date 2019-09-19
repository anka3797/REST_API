using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace rest_api
{
    public class api_helper : Iapi_helper
    {
        public async Task<string> PhoneApiAsync(String num)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://apilayer.net/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //string num = Static.EditableText;
            HttpResponseMessage response = await client.GetAsync($"validate?access_key=925a5c5b10648393004f6a3c8f60b600&number={num}&format=1");
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> IPApiAsync(String ip)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://ipinfo.io/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // ip = Static.EditableText;
            HttpResponseMessage response = await client.GetAsync($"{ip}?token=e59b5ef29b1925");

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

    }

   /* public static class Static
    {
        public static string EditableText;
    }*/
}
