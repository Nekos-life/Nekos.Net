using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nekos.Net.V2;
using Nekos.Net.V2.Endpoint;

namespace Nekos.Net.Tests;

[TestClass]
public class NekosV2ClientTest
{
    [TestMethod]
    public void AllEndpointsSuccess()
    {
        bool isSuccess = true;

        try
        {
            NekosV2Client client = new();
                
            client.RequestAllNsfwAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            client.RequestAllSfwAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            client.RequestNsfwResultsAsync(NsfwEndpoint.Random | NsfwEndpoint.All | NsfwEndpoint.Eron).ConfigureAwait(false).GetAwaiter().GetResult();
            client.RequestSfwResultsAsync(SfwEndpoint.Random | SfwEndpoint.All | SfwEndpoint.Holo).ConfigureAwait(false).GetAwaiter().GetResult();
            client.RequestFactsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            client.RequestNamesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            client.RequestSpoilerAsync("never gonna give you up").ConfigureAwait(false).GetAwaiter().GetResult();
            client.RequestOwOifyTextAsync("never gonna let you down").ConfigureAwait(false).GetAwaiter().GetResult();
            client.RequestWhyQuestionsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        } catch
        {
            isSuccess = false;
        }

        Assert.IsTrue(isSuccess);
    }
}