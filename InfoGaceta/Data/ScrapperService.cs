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
            var HeaderNames = doc.DocumentNode.SelectNodes("//div[@class='text']/h2");

            foreach (var item in HeaderNames)
            {
                Data1st.Add(item.InnerText);
            }
            return Data1st;
        }

        public async Task<Dictionary<string, string>> ObtenerTasas()
        {
            Dictionary<string, string> Data = new();

            HttpClient hc = new();
            HttpResponseMessage result = await hc.GetAsync($"http://www.bcra.gov.ar/BCRAyVos/Plazos_fijos_online.asp");
            Stream stream = await result.Content.ReadAsStreamAsync();
            HtmlDocument doc = new();
            doc.Load(stream);
            var datos = doc.DocumentNode.SelectNodes("//table//tr//td[1]");
            var datos2 = doc.DocumentNode.SelectNodes("//table//tr//td[4]");

            for (int i = 0; i < datos.Count; i++)
            {
                Data.Add(datos[i].InnerText, datos2[i].InnerText.Trim().Replace("%", ""));
            }
            return Data.OrderByDescending(key => key.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
