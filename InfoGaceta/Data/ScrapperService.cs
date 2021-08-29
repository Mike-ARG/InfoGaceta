using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using HtmlAgilityPack;

namespace InfoGaceta.Data
{
    public class ScrapperService
    {
        public async Task<List<string>> DoScrapping()
        {
            List<string> Data1st = new();

            HttpClient hc = new();
            HttpResponseMessage result = await hc.GetAsync($"https://www.lagaceta.com.ar/");
            Stream stream = await result.Content.ReadAsStreamAsync();
            HtmlDocument doc = new();
            doc.Load(stream);
            var datos = doc.DocumentNode.SelectNodes("//div[@class='text']/h2");

            foreach (var item in datos)
            {
                Data1st.Add(item.InnerText);
            }
            return Data1st;
        }
        public async Task<List<string>> GetCategorias()
        {
            List<string> Data1st = new();

            HttpClient hc = new();
            HttpResponseMessage result = await hc.GetAsync($"https://www.lagaceta.com.ar/");
            Stream stream = await result.Content.ReadAsStreamAsync();
            HtmlDocument doc = new();
            doc.Load(stream);
            var datos = doc.DocumentNode.SelectNodes("//div[@class='smallTitle']");

            foreach (var item in datos)
            {
                Data1st.Add(item.InnerText.Trim());
            }
            return Data1st;
        }
    }
}
