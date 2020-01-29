using System;
using System.Net.Http;
using System.Threading.Tasks;
using Nekos.Net.Endpoints;
using Nekos.Net.Responses;
using Newtonsoft.Json;

namespace Nekos.Net
{
    /// <summary>
    ///     Represents for nekos.life API client
    /// </summary>
    public class NekosClient
    {
        private const string HostUrl = "https://nekos.life/api/v2";

        /// <summary>
        ///     Get an image from random SFW endpoint.
        /// </summary>
        /// <returns>The image/GIF from random SFW endpoint.</returns>
        public static async Task<NekosImage> GetRandomSfwAsync()
        {
            Random r = new Random();
            int index = r.Next(0, Enum.GetNames(typeof(SfwEndpoint)).Length - 1); // https://stackoverflow.com/questions/856154/total-number-of-items-defined-in-an-enum
            return await GetSfwAsync((SfwEndpoint)index);
        }

        /// <summary>
        ///     Get an image from random NSFW endpoint.
        /// </summary>
        /// <returns>The image/GIF from random NSFW endpoint.</returns>
        public static async Task<NekosImage> GetRandomNsfwAsync()
        {
            Random r = new Random();
            int index = r.Next(0, Enum.GetNames(typeof(NsfwEndpoint)).Length - 1); // https://stackoverflow.com/questions/856154/total-number-of-items-defined-in-an-enum
            return await GetNsfwAsync((NsfwEndpoint)index);
        }

        /// <summary>
        ///     Get a Safe-For-Work image/GIF
        /// </summary>
        /// <param name="endpoint">A member of <see cref="SfwEndpoint"/> enum</param>
        /// <returns>A Safe-For-Work image/GIF</returns>
        public static async Task<NekosImage> GetSfwAsync(SfwEndpoint endpoint)
        {
            return await GetResponse<NekosImage>($"/img/{endpoint.ToString().ToLower()}");
        }

        /// <summary>
        ///     Get a Not-Safe-For-Work image/GIF
        /// </summary>
        /// <param name="endpoint">A member of <see cref="NsfwEndpoint"/> enum</param>
        /// <returns>A Not-Safe-For-Work image/GIF</returns>
        public static async Task<NekosImage> GetNsfwAsync(NsfwEndpoint endpoint)
        {
            if (endpoint == NsfwEndpoint.Random_Hentai_Gif)
            {
                return await GetResponse<NekosImage>("/img/Random_hentai_gif");
            } 
            else 
                return await GetResponse<NekosImage>($"/img/{endpoint.ToString().ToLower()}");
        }

        /// <summary>
        ///     Get a random why question.
        /// </summary>
        /// <returns>A random why question.</returns>
        public static async Task<NekosWhy> GetWhyAsync()
        {
            return await GetResponse<NekosWhy>("/why");
        }

        /// <summary>
        ///     Get a random cat emoji.
        /// </summary>
        /// <returns>A random cat emoji.</returns>
        public static async Task<NekosCat> GetCatAsync()
        {
            return await GetResponse<NekosCat>("/cat");
        }

        /// <summary>
        ///     Get a random fact.
        /// </summary>
        /// <returns>A random fact.</returns>
        public static async Task<NekosFact> GetFactAsync()
        {
            return await GetResponse<NekosFact>("/fact");
        }

        /// <summary>
        ///     Get a random 8 ball answer.
        /// </summary>
        /// <returns>A random 8 ball answer.</returns>
        public static async Task<Nekos8Ball> Get8BallAsync()
        {
            return await GetResponse<Nekos8Ball>("/8ball");
        }

        /// <summary>
        ///     Creates a nice conversation with a chatbot.
        /// </summary>
        /// <param name="text">The text to chat with the bot.</param>
        /// <returns>The response from bot.</returns>
        /// <exception cref="ArgumentException">When the text is null or empty</exception>
        [Obsolete("This endpoint will shutdown in the future."+ "\n" + "If you continue using this, you will get a compilation error", true)]
        public static async Task<NekosChat> GetChatStringAsync(string text)
        {
            if (string.IsNullOrEmpty(text.Trim()))
                throw new ArgumentException("Text cannot be null or whitespace", nameof(text));

            return await GetResponse<NekosChat>($"/chat?text={Uri.EscapeUriString(text)}");
        }

        /// <summary>
        ///     Owo-ify every text input.
        /// </summary>
        /// <param name="text">The string to owoify.</param>
        /// <returns>The owoified string.</returns>
        /// <exception cref="ArgumentException">When the text is null or empty</exception>
        public static async Task<NekosOwoify> GetOwoifyStringAsync(string text)
        {
            if (string.IsNullOrEmpty(text.Trim()))
                throw new ArgumentException("Text cannot be null or whitespace", nameof(text));

            return await GetResponse<NekosOwoify>($"/owoify?text={Uri.EscapeUriString(text)}");
        }

        /// <summary>
        ///     Create a spoiler for EVERY CHARACTER in the text input.
        /// </summary>
        /// <param name="text">Text to make a spoiler</param>
        /// <returns>A spoiler of each character provided</returns>
        /// <exception cref="ArgumentException">When the text is null or empty</exception>
        public static async Task<NekosOwoify> GetSpoilersStringAsync(string text)
        {
            if (string.IsNullOrEmpty(text.Trim()))
                throw new ArgumentException("Text cannot be null or whitespace", nameof(text));

            return await GetResponse<NekosOwoify>($"/spoiler?text={Uri.EscapeUriString(text)}");
        }

        private static async Task<T> GetResponse<T>(string endpoint)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{HostUrl}/{endpoint}");
                HttpResponseMessage res = await httpClient.SendAsync(req);

                if (!res.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Unwanted status code found: {res.StatusCode}");
                }

                string response = await res.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(response);
            }
        }
    }
}