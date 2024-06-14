using ConsumoApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoApi.Controllers
{
    public class CharacterController
    {
        private HttpClient client;

        public CharacterController()
        {
            client = new HttpClient();
        }

        public async Task<Application> GetAllCharacters()
        {
            try
            {
                Application character = new Application();
                HttpResponseMessage response = await client.GetAsync("https://rickandmortyapi.com/api/character");
                
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                character = JsonConvert.DeserializeObject<Application>(responseJson);

                return character;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
