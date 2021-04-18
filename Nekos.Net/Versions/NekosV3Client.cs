using System;
using System.Threading.Tasks;
using Nekos.Net.Endpoints.Version3;
using Nekos.Net.Responses.Version3;

namespace Nekos.Net.Versions
{
    [Obsolete("This is not ready yet.", true)]
    public class NekosV3Client : BaseNekosClient
    {
        private const string HostUrl = "https://api.nekos.dev/api/v3/images";

        /// <summary>
        ///     Get multiple SFW media file from server.
        /// </summary>
        /// <param name="endpoint">A member of <see cref="SfwEndpointV3" /> enum represents the endpoint.</param>
        /// <param name="count">Determines how many media files you want to get. Ranges from 2 to 10 inclusively.</param>
        public async Task<NekosResponseList> GetMultipleSfwAsync(SfwEndpointV3 endpoint, int count = 2)
        {
            return await GetResponse<NekosResponseList>($"{HostUrl}/{GetEndpoint(endpoint)}?count={count}");
        }

        /// <summary>
        ///     Get single SFW media files from server.
        /// </summary>
        /// <param name="endpoint">A member of <see cref="SfwEndpointV3" /> enum represents the endpoint.</param>
        public async Task<NekosResponse> GetSingleSfwAsync(SfwEndpointV3 endpoint)
        {
            return await GetResponse<NekosResponse>($"{HostUrl}/{GetEndpoint(endpoint)}");
        }

        /// <summary>
        ///     Get multiple NSFW media file from server.
        /// </summary>
        /// <param name="endpoint">A member of <see cref="NsfwEndpointV3" /> enum represents the endpoint.</param>
        /// <param name="count">Determines how many media files you want to get.</param>
        public async Task<NekosResponseList> GetMultipleNsfwAsync(NsfwEndpointV3 endpoint, int count = 2)
        {
            return await GetResponse<NekosResponseList>($"{HostUrl}/{GetEndpoint(endpoint)}?count={count}");
        }

        /// <summary>
        ///     Get single NSFW media files from server.
        /// </summary>
        /// <param name="endpoint">A member of <see cref="NsfwEndpointV3" /> enum represents the endpoint.</param>
        public async Task<NekosResponse> GetSingleNsfwAsync(NsfwEndpointV3 endpoint)
        {
            return await GetResponse<NekosResponse>($"{HostUrl}/{GetEndpoint(endpoint)}");
        }

        private string GetEndpoint(SfwEndpointV3 endpoint)
        {
            throw new NotImplementedException();
        }

        private string GetEndpoint(NsfwEndpointV3 endpoint)
        {
            throw new NotImplementedException();
        }
    }
}