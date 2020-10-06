using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiHelper
{
    public static class DogApiProcessor
    {

        public static async Task<List<string>> LoadBreedList()
        {
            ///TODO : À compléter LoadBreedList
            /// Attention le type de retour n'est pas nécessairement bon
            /// J'ai mis quelque chose pour avoir une base
            /// TODO : Compléter le modèle manquant

            string url = "https://dog.ceo/api/breeds/list";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    DogModel result = await response.Content.ReadAsAsync<DogModel>();
                    Console.WriteLine(result);
                    return result.Message;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<string>> GetImageUrl(string breed, int number)
        {
            /// TODO : GetImageUrl()
            /// TODO : Compléter le modèle manquant

            string url = $"https://dog.ceo/api/breed/{ breed }/images/random/{ number }";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    DogModel result = await response.Content.ReadAsAsync<DogModel>();
                    Console.WriteLine(result);
                    return result.Message;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
