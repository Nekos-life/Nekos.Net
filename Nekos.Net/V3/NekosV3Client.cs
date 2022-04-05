using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nekos.Net.Prototypes;
using Nekos.Net.V3.Endpoints;
using Nekos.Net.V3.Responses;

namespace Nekos.Net.V3;

/// <summary>
///     A client to interact with nekos.life API v3
/// </summary>
public class NekosV3Client : BaseNekosClient
{
    static NekosV3Client()
    {
        HostUrl = "https://api.nekos.dev/api/v3/images";
    }

    /// <summary>
    ///     <inheritdoc/>
    /// </summary>
    public NekosV3Client()
    {
    }
    
    /// <summary>
    ///     <inheritdoc/>
    /// </summary>
    public NekosV3Client(NekosV3Client other) : base(other)
    {
    }

    /// <summary>
    ///     <inheritdoc/>
    /// </summary>
    public NekosV3Client(ILogger logger, bool isLoggingAllowed = true) : base(logger, isLoggingAllowed)
    {
    }
    
    // segments
    private string _mediaType = "img";
    private string _maturity = "sfw";
    private string _endpoint = "poke";

    /// <summary>
    ///     Override current client request set with a new SFW image endpoint.
    /// </summary>
    /// <param name="endpoint">New SFW image endpoint from <see cref="SfwImgEndpoint"/> enum to override.</param>
    /// <returns>Post-reconfigured client. Most of the time you don't need this.</returns>
    public NekosV3Client WithSfwImgEndpoint(SfwImgEndpoint endpoint)
    {
        _mediaType = "img";
        _maturity = "sfw";
        _endpoint = endpoint != SfwImgEndpoint._8ball ? endpoint.ToString().ToLower() : "8ball";
        return this;
    }
    
    /// <summary>
    ///     Override current client request set with a new SFW GIF endpoint.
    /// </summary>
    /// <param name="endpoint">New SFW GIF endpoint from <see cref="SfwGifEndpoint"/> enum to override.</param>
    /// <returns>Post-reconfigured client. Most of the time you don't need this.</returns>
    public NekosV3Client WithSfwGifEndpoint(SfwGifEndpoint endpoint)
    {
        _mediaType = "gif";
        _maturity = "sfw";
        _endpoint = endpoint.ToString().ToLower();
        return this;
    }

    /// <summary>
    ///     Override current client request set with a new NSFW image endpoint.
    /// </summary>
    /// <param name="endpoint">New NSFW image endpoint from <see cref="NsfwImgEndpoint"/> enum to override.</param>
    /// <returns>Post-reconfigured client. Most of the time you don't need this.</returns>
    public NekosV3Client WithNsfwImgEndpoint(NsfwImgEndpoint endpoint)
    {
        _mediaType = "img";
        _maturity = "nsfw";
        _endpoint = endpoint.ToString().ToLower();
        return this;
    }
    
    /// <summary>
    ///     Override current client request set with a new NSFW image endpoint.
    /// </summary>
    /// <param name="endpoint">New NSFW GIF endpoint from <see cref="NsfwGifEndpoint"/> enum to override.</param>
    /// <returns>Post-reconfigured client. Most of the time you don't need this.</returns>
    public NekosV3Client WithNsfwGifEndpoint(NsfwGifEndpoint endpoint)
    {
        _mediaType = "gif";
        _maturity = "nsfw";
        _endpoint = endpoint.ToString().ToLower();
        return this;
    }

    /// <summary>
    ///     Get a single request asynchronously.
    /// </summary>
    /// <returns>Response data of single result.</returns>
    public async Task<NekosSingleResponse> GetAsync()
    {
        return await
            GetResponse<NekosSingleResponse>(
                    $"{HostUrl}/{_maturity}/{_mediaType}/{_endpoint}")
                .ConfigureAwait(false);
    }

    /// <summary>
    ///     Get multiple requests asynchronously.
    /// </summary>
    /// <param name="count">A non-negative integer determining the quantity of the results.</param>
    /// <returns>Response data of multiple results.</returns>
    /// <exception cref="ArgumentException">When <paramref name="count"/> is either zero (0), one (1) or more than 20 (>20)</exception>
    public async Task<NekosListedResponse> GetAsync(uint count)
    {
        if (count is 0 or 1 or > 20)
            throw new ArgumentException("Must be between 2 and 20", nameof(count));
        
        var response = await
            GetResponse<NekosListedResponse>(
                $"{HostUrl}/{_maturity}/{_mediaType}/{_endpoint}?count={count}")
                .ConfigureAwait(false);

        return response;
    }
}