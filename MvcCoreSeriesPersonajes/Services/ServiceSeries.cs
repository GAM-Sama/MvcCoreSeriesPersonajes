using MvcCoreSeriesPersonajes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MvcCoreSeriesPersonajes.Services
{
    public class ServiceSeries
    {
        private string URL;
        private MediaTypeWithQualityHeaderValue Header;


        public ServiceSeries(string url)
        {
            this.URL = url;
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");

        }

        //Los Metodos Get se usan Genericos
        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }

            }
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            string request = "api/Series/GetSeries";
            List<Serie> series = await this.CallApiAsync<List<Serie>>(request);
            return series;
        }
        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            string request = "api/Series/GetPersonajes";
            List<Personaje> personaje = await this.CallApiAsync<List<Personaje>>(request);
            return personaje;
        }
        public async Task<Serie> FindSerieAsync(int idserie)
        {
            string request = "/api/Series/FindSerie/"+idserie;
            Serie serie = await this.CallApiAsync<Serie>(request);
            return serie;
        }
        public async Task<Personaje> FindPersonajeAsync(int idpersonaje)
        {
            string request = "/api/Series/FindPersonaje" + idpersonaje;
            Personaje p = await this.CallApiAsync<Personaje>(request);
            return p;
        }
        public async Task<List<Personaje>> FindPersonajesSerieAsync(int idpersonaje, int idserie)
        {
            string request = "api/Series/FindPersonajesSerie/" + idpersonaje + "/" + idserie;
            List<Personaje> personaje = await this.CallApiAsync<List<Personaje>>(request);
            return personaje;
        }


        public async Task UpdatePersonajeAsync(int idpersonaje, int idserie)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/Series/UpdatePersonajeSerie/" + idpersonaje+"/"+idserie;
                client.BaseAddress = new Uri(this.URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Personaje p = new Personaje();
                p.IdPersonaje = idpersonaje;
                p.IdPersonaje = idserie;
                //Debemos convertir a JSON el objeto
                string json = JsonConvert.SerializeObject(p);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);


            }
        }
    }
}
