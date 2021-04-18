using System;
using System.Threading.Tasks;
using Nekos.Net.Endpoints.Version2;
using Nekos.Net.Versions;

namespace Tests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MainV2Async().ConfigureAwait(false).GetAwaiter().GetResult();
            // MainV3Async().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private static async Task MainV2Async()
        {
            var client2 = new NekosV2Client();
            var image = await client2.GetSfwAsync(SfwEndpointV2.Poke);

            Console.WriteLine(image.Url);
        }

        /*
        Not ready until I finished doing endpoints 
         
        private static async Task MainV3Async()
        {
            var client3 = new NekosV3Client();
            var response = await client3.GetSingleNsfwAsync(NsfwEndpointV3.gif_BlowJob);
            var url = response.Data.Response.Url;
            
            Console.WriteLine(url);
        }
        */
    }
}