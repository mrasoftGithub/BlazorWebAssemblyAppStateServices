using BlazorBlogProject.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBlogProject.Client.Model
{
    public class DbModel : IModel
    {
        private readonly HttpClient _http;

        public DbModel(HttpClient http)
        {
            // Constructor
            _http = http;
        }

        public async Task<IEnumerable<EIGENAAR>> GetLijstEigenaren()
        {
            //-- Direct
            // return await _http.GetFromJsonAsync<List<EIGENAAR>>("api/ServiceDB/GetLijstEigenaren/");

            //-- Eerst de statuscode uitlezen
            var resultaat = await _http.GetAsync("api/ServiceDB/GetLijstEigenaren/");
            if (resultaat.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var boodschap = await resultaat.Content.ReadAsStringAsync();
                return new List<EIGENAAR> { new EIGENAAR() { Omschrijving = boodschap } };
            }
            else
            {
                return await resultaat.Content.ReadFromJsonAsync<List<EIGENAAR>>();
            }
        }

        public async Task<int> GetTotaalAantalEigenaren()
        {
            //-- Direct
            //-- TotaalAantalEigenaren = await _http.GetFromJsonAsync<int>("api/ServiceDB/GetTotaalAantalEigenaren/");

            //-- Eerst de statuscode uitlezen
            var resultaat = await _http.GetAsync("api/ServiceDB/GetTotaalAantalEigenaren/");
            if (resultaat.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var boodschap = await resultaat.Content.ReadAsStringAsync();
                Console.WriteLine(boodschap);
                return 0;
            }
            else
            {
                return await resultaat.Content.ReadFromJsonAsync<int>();
            }
        }

        public async Task VoegToe(EIGENAAR eigenaar)
        {
            var resultaat = await _http.PostAsJsonAsync("api/ServiceDB", eigenaar);
            if (resultaat.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var boodschap = await resultaat.Content.ReadAsStringAsync();
                Console.WriteLine(boodschap);
            }
        }
    }
}
