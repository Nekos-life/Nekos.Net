using Nekos.Net.Client;
using Nekos.Net.Endpoints.V2;

namespace Nekos.Net.TestProgram;

public class Program
{
    public static void Main()
    {
        MainAsync().ConfigureAwait(false).GetAwaiter().GetResult();
    }

    private static async Task MainAsync()
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
}