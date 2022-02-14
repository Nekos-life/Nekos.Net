using System;
using System.Threading.Tasks;
using Nekos.Net.Prototypes;
using Nekos.Net.V3.Endpoints;
using Nekos.Net.V3.Responses;

namespace Nekos.Net.V3;

public class NekosV3Client : BaseNekosClient
{
    static NekosV3Client()
    {
        HostUrl = "https://api.nekos.dev/api/v3/images";
    }

    private string _mediaType = "img";
    private string _maturity = "sfw";
    private string _endpoint = "poke";

    public NekosV3Client WithSfwImgEndpoint(SfwImgEndpoint endpoint)
    {
        _mediaType = "img";
        _maturity = "sfw";
        _endpoint = endpoint != SfwImgEndpoint._8ball ? endpoint.ToString().ToLower() : "8ball";
        return this;
    }
    
    public NekosV3Client WithSfwGifEndpoint(SfwGifEndpoint endpoint)
    {
        _mediaType = "gif";
        _maturity = "sfw";
        _endpoint = endpoint.ToString().ToLower();
        return this;
    }

    public NekosV3Client WithNsfwImgEndpoint(NsfwImgEndpoint endpoint)
    {
        _mediaType = "img";
        _maturity = "nsfw";
        _endpoint = endpoint.ToString().ToLower();
        return this;
    }

    public NekosV3Client WithNsfwGifEndpoint(NsfwGifEndpoint endpoint)
    {
        _mediaType = "gif";
        _maturity = "nsfw";
        _endpoint = endpoint.ToString().ToLower();
        return this;
    }

    public async Task<NekosSingleResponse> GetSingleAsync()
    {
        return await
            GetResponse<NekosSingleResponse>(
                    $"{HostUrl}/{_maturity}/{_mediaType}/{_endpoint}")
                .ConfigureAwait(false);
    }

    public async Task<NekosListedResponse> GetManyAsync(uint count = 2)
    {
        if (count is 1 or > 20)
            throw new ArgumentException("Must be between 2 and 20", nameof(count));
        
        var response = await
            GetResponse<NekosListedResponse>(
                $"{HostUrl}/{_maturity}/{_mediaType}/{_endpoint}?count={count}")
                .ConfigureAwait(false);

        return response;
    }
}