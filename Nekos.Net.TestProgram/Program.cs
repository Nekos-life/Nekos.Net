using Nekos.Net.V2;
using Nekos.Net.V2.Endpoint;
using Nekos.Net.V3;
using Nekos.Net.V3.Endpoints;

namespace Nekos.Net.TestProgram;

public static class Program
{
    public static void Main()
    {
        V2().ConfigureAwait(false).GetAwaiter().GetResult();
        V3().ConfigureAwait(false).GetAwaiter().GetResult();
    }

    private static async Task V2()
    {
        NekosV2Client client = new();

        await client.RequestAllNsfwAsync();
        await client.RequestAllSfwAsync();
        await client.RequestNsfwResultsAsync(NsfwEndpoint.Random | NsfwEndpoint.All | NsfwEndpoint.Eron);
        await client.RequestSfwResultsAsync(SfwEndpoint.Random | SfwEndpoint.All | SfwEndpoint.Holo);
        await client.RequestFactsAsync();
        await client.RequestNamesAsync();
        await client.RequestSpoilerAsync("never gonna give you up");
        await client.RequestOwOifyTextAsync("never gonna let you down");
        await client.RequestWhyQuestionsAsync();
    }

    private static async Task V3()
    {
        NekosV3Client client = new();
        
        IEnumerable<SfwImgEndpoint> availableFlags1 = Enum.GetValues<SfwImgEndpoint>();
        IEnumerable<SfwGifEndpoint> availableFlags2 = Enum.GetValues<SfwGifEndpoint>();
        IEnumerable<NsfwImgEndpoint> availableFlags3 = Enum.GetValues<NsfwImgEndpoint>();
        IEnumerable<NsfwGifEndpoint> availableFlags4 = Enum.GetValues<NsfwGifEndpoint>();
        
        foreach (SfwImgEndpoint endpoint in availableFlags1) await client.WithSfwImgEndpoint(endpoint).GetAsync();
        foreach (SfwGifEndpoint endpoint in availableFlags2) await client.WithSfwGifEndpoint(endpoint).GetAsync();
        foreach (NsfwImgEndpoint endpoint in availableFlags3) await client.WithNsfwImgEndpoint(endpoint).GetAsync();
        foreach (NsfwGifEndpoint endpoint in availableFlags4) await client.WithNsfwGifEndpoint(endpoint).GetAsync();
    }
}