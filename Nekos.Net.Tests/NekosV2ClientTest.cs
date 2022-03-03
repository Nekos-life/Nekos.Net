using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nekos.Net.V2;
using Nekos.Net.V2.Endpoint;
using Nekos.Net.V2.Responses;

namespace Nekos.Net.Tests;

[TestClass]
public class NekosV2ClientTest
{

    private NekosV2Client _client = new();

    [TestMethod]
    public async Task RequestAllAsMethodCallTest()
    {
        List<NekosImage> results = new();
        results.AddRange(await _client.RequestAllNsfwAsync());
        results.AddRange(await _client.RequestAllSfwAsync());

        // -2: exclude Random and All
        var nsfwValidFlagCount = Enum.GetValues<NsfwEndpoint>().Length - 2;
        var sfwValidFlagCount = Enum.GetValues<SfwEndpoint>().Length - 2;

        Assert.IsTrue(results.Count == nsfwValidFlagCount + sfwValidFlagCount);
    }

    [TestMethod]
    public async Task RequestAllAsFlagTest()
    {
        List<NekosImage> results = new();
        results.AddRange(await _client.RequestSfwResultsAsync(SfwEndpoint.All));
        results.AddRange(await _client.RequestNsfwResultsAsync(NsfwEndpoint.All));

        // -2: exclude Random and All
        var nsfwValidFlagCount = Enum.GetValues<NsfwEndpoint>().Length - 2;
        var sfwValidFlagCount = Enum.GetValues<SfwEndpoint>().Length - 2;

        Assert.IsTrue(results.Count == nsfwValidFlagCount + sfwValidFlagCount);
    }

    [TestMethod]
    public async Task RequestSingleEndpointTest()
    {
        List<NekosImage> results = new();
        results.AddRange(await _client.RequestSfwResultsAsync(SfwEndpoint.Holo));
        results.AddRange(await _client.RequestNsfwResultsAsync(NsfwEndpoint.Eron));
        Assert.IsTrue(results.Count == 2);
    }

    [TestMethod]
    public async Task RequestRandomEndpointTest()
    {
        List<NekosImage> results = new();
        results.AddRange(await _client.RequestSfwResultsAsync(SfwEndpoint.Random));
        results.AddRange(await _client.RequestNsfwResultsAsync(NsfwEndpoint.Random));
        Assert.IsTrue(results.Count == 2);
    }

    [TestMethod]
    public async Task RequestSfwMixedFlagsTest()
    {
        List<NekosImage> results = new();
        results.AddRange(await _client.RequestSfwResultsAsync(SfwEndpoint.Random | SfwEndpoint.All | SfwEndpoint.Holo));
        var sfwValidFlagCount = Enum.GetValues<SfwEndpoint>().Length - 2;
        Assert.IsTrue(results.Count == sfwValidFlagCount + 1 + 1);
    }

    [TestMethod]
    public async Task RequestNsfwMixedFlagsTest()
    {
        List<NekosImage> results = new();
        results.AddRange(
            await _client.RequestNsfwResultsAsync(NsfwEndpoint.Random | NsfwEndpoint.All | NsfwEndpoint.Eron));
        var nsfwValidFlagCount = Enum.GetValues<NsfwEndpoint>().Length - 2;
        Assert.IsTrue(results.Count == nsfwValidFlagCount + 1 + 1);
    }

    [TestMethod]
    public async Task RequestMiscTest()
    {
        bool isSuccess = true;

        try
        {
            await _client.RequestFactsAsync();
            await _client.RequestNamesAsync();
            await _client.RequestSpoilerAsync("never gonna give you up");
            await _client.RequestOwOifyTextAsync("never gonna let you down");
            await _client.RequestWhyQuestionsAsync();
            await _client.RequestCatAsync();
        }
        catch
        {
            isSuccess = false;
        }

        Assert.IsTrue(isSuccess);
    }
}