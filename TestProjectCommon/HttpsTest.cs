using DevExpress.XtraRichEdit.Import.Html;
using ExchangeRates.Model;
using Firma.Module.BusinessObjects;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectCommon
{
    internal class HttpsTest
    {
        [Test]
        public async System.Threading.Tasks.Task TestAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://utapl.azurewebsites.net/api/Station?Page=2000&Size=500&Country=DEU");
            request.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJSb2xlcyI6IkRlZmF1bHQsUHJhY293bmlrIEtsaWVudGEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjA4YzQ1MTZiLTA1MWYtNGVhOC1iMGRlLTQzNmFmZmEzMDc5NCIsIlhhZlNlY3VyaXR5QXV0aFBhc3NlZCI6IlhhZlNlY3VyaXR5QXV0aFBhc3NlZCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJVdGFQbFRlc3QiLCJYYWZTZWN1cml0eSI6IlhhZlNlY3VyaXR5IiwiWGFmTG9nb25QYXJhbXMiOiJxMVlLTFU0dDhrdk1UVld5VWdvdFNReklDVWt0TGxIU1VRcElMQzR1enk5S0FRcWIrTGtXSjdwRmhpalZBZ0E9IiwiZXhwIjoxNzExNDg4NDkwfQ.1ljCpgINy9I4HeUlSOrytV762FovtwL4iDTR5hpkGFg");
            request.Headers.Add("Cookie", "ARRAffinity=49423cf21a7c8f31473ef02d2227745c0c400eef47ec6f4bd5f71cd68d6585b4; ARRAffinitySameSite=49423cf21a7c8f31473ef02d2227745c0c400eef47ec6f4bd5f71cd68d6585b4");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }

        [Test]
        public async System.Threading.Tasks.Task AuthorizationTestAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://utapl.azurewebsites.net/api/Authentication/Authenticate");
            request.Headers.Add("Cookie", "ARRAffinity=49423cf21a7c8f31473ef02d2227745c0c400eef47ec6f4bd5f71cd68d6585b4; ARRAffinitySameSite=49423cf21a7c8f31473ef02d2227745c0c400eef47ec6f4bd5f71cd68d6585b4");
            var content = new StringContent("{\r\n  \"userName\": \"UtaPlTest\",\r\n  \"password\": \"xxxxx\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
        [Test]
        public async System.Threading.Tasks.Task DupaTestAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://utapl.azurewebsites.net/api/Authentication/Authenticate");
            request.Headers.Add("Cookie", "ARRAffinity=49423cf21a7c8f31473ef02d2227745c0c400eef47ec6f4bd5f71cd68d6585b4; ARRAffinitySameSite=49423cf21a7c8f31473ef02d2227745c0c400eef47ec6f4bd5f71cd68d6585b4");
            var content = new StringContent("{\r\n  \"userName\": \"UtaPlTest\",\r\n  \"password\": \"xxxxx\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var dupa = await response.Content.ReadAsStringAsync();
            Console.WriteLine(dupa);
        }




        


        
        [Test]
        public async System.Threading.Tasks.Task TestNowejMetodyAsync()
        {
            string responseString = await GetResponseStringAsync();
            if (responseString != null)
            {
                Console.WriteLine($"Odpowiedź z serwera: {responseString}");
            }
        }
        static async Task<string> GetResponseStringAsync()
        {
            var httpClient = new HttpClient();
            var content = new StringContent("{\r\n  \"userName\": \"UtaPlTest\",\r\n  \"password\": \"xxxxx\"\r\n}", null, "application/json");
            string url = "https://utapl.azurewebsites.net/api/Authentication/Authenticate"; // Adres URL, z którego chcesz pobrać dane







            try
            {
                var result = await httpClient.PostAsync(url, content);
                string resultContent = await result.Content.ReadAsStringAsync();
                return resultContent;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Wystąpił błąd podczas wykonywania żądania: {e.Message}");
                return null;
            }
        }
    }
}

