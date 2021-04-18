using System;
using System.Threading.Tasks;
using Nekos.Net.Endpoints.Version2;
using Nekos.Net.Responses.Version2;

// ReSharper disable MemberCanBePrivate.Global

namespace Nekos.Net.Versions
{
    public class NekosV2Client : BaseNekosClient
    {
        private const string HostUrl = "https://nekos.life/api/v2";

        /// <summary>
        ///     Get an image from random SFW endpoint.
        /// </summary>
        /// <returns>The image/GIF from random SFW endpoint.</returns>
        public async Task<NekosImage> GetSfwAsync()
        {
            var r = new Random();
            var index = r.Next(0, Enum.GetNames(typeof(SfwEndpointV2)).Length - 1);
            return await GetSfwAsync((SfwEndpointV2) index);
        }

        /// <summary>
        ///     Get an image from random NSFW endpoint.
        /// </summary>
        /// <returns>The image/GIF from random NSFW endpoint.</returns>
        public async Task<NekosImage> GetNsfwAsync()
        {
            var r = new Random();
            var index = r.Next(0, Enum.GetNames(typeof(NsfwEndpointV2)).Length - 1);
            return await GetNsfwAsync((NsfwEndpointV2) index);
        }

        /// <summary>
        ///     Get a Safe-For-Work image/GIF
        /// </summary>
        /// <param name="endpoint">A member of <see cref="SfwEndpointV2" /> enum represents the endpoint.</param>
        /// <returns>A Safe-For-Work image/GIF.</returns>
        public async Task<NekosImage> GetSfwAsync(SfwEndpointV2 endpoint)
        {
            return await GetResponse<NekosImage>($"{HostUrl}/img/{endpoint.ToString().ToLower()}");
        }

        /// <summary>
        ///     Get a Not-Safe-For-Work image/GIF
        /// </summary>
        /// <param name="endpoint">A member of <see cref="NsfwEndpointV2" /> enum represents the endpoint.</param>
        /// <returns>A Not-Safe-For-Work image/GIF.</returns>
        public async Task<NekosImage> GetNsfwAsync(NsfwEndpointV2 endpoint)
        {
            if (endpoint == NsfwEndpointV2.Random_Hentai_Gif)
                // idk about this lol
                return await GetResponse<NekosImage>("/img/Random_hentai_gif");

            return await GetResponse<NekosImage>($"{HostUrl}/img/{endpoint.ToString().ToLower()}");
        }

        /// <summary>
        ///     Get a random why question.
        /// </summary>
        /// <returns>A random why question.</returns>
        public async Task<NekosWhy> GetWhyAsync()
        {
            return await GetResponse<NekosWhy>($"{HostUrl}/why");
        }

        /// <summary>
        ///     Get a random cat emoji.
        /// </summary>
        /// <returns>A random cat emoji.</returns>
        public async Task<NekosCat> GetCatAsync()
        {
            return await GetResponse<NekosCat>($"{HostUrl}/cat");
        }

        /// <summary>
        ///     Get a random fact.
        /// </summary>
        /// <returns>A random fact.</returns>
        public async Task<NekosFact> GetFactAsync()
        {
            return await GetResponse<NekosFact>($"{HostUrl}/fact");
        }

        /// <summary>
        ///     Get a random 8 ball answer.
        /// </summary>
        /// <returns>A random 8 ball answer.</returns>
        public async Task<Nekos8Ball> Get8BallAsync()
        {
            return await GetResponse<Nekos8Ball>($"{HostUrl}/8ball");
        }

        /// <summary>
        ///     Owo-ify the input text.
        /// </summary>
        /// <param name="text">The string to owoify.</param>
        /// <returns>The owoified string.</returns>
        /// <exception cref="ArgumentException">When the text is either null or empty.</exception>
        public async Task<NekosOwoify> GetOwoifyStringAsync(string text)
        {
            if (string.IsNullOrEmpty(text.Trim()))
                throw new ArgumentException("Text cannot be null or whitespace", nameof(text));

            return await GetResponse<NekosOwoify>($"{HostUrl}/owoify?text={Uri.EscapeUriString(text)}");
        }

        /// <summary>
        ///     Create a Discord spoiler of EVERY CHARACTER in the input text.
        /// </summary>
        /// <param name="text">Text to make a Discord spoiler.</param>
        /// <returns>Discord spoiler of EVERY CHARACTER in the input text.</returns>
        /// <exception cref="ArgumentException">When the text is either null or empty.</exception>
        public async Task<NekosOwoify> GetSpoilerStringAsync(string text)
        {
            if (string.IsNullOrEmpty(text.Trim()))
                throw new ArgumentException("Text cannot be null or whitespace", nameof(text));

            return await GetResponse<NekosOwoify>($"{HostUrl}/spoiler?text={Uri.EscapeUriString(text)}");
        }

        /// <summary>
        ///     Get a random name.
        /// </summary>
        /// <returns>A random name.</returns>
        public async Task<NekosName> GetRandomNameAsync()
        {
            return await GetResponse<NekosName>($"{HostUrl}/name");
        }
    }
}