using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nekos.Net.V3;
using Nekos.Net.V3.Endpoints;

namespace Nekos.Net.Tests;

[TestClass]
public class NekosV3ClientTest
{
    [TestMethod]
    public void AllEndpointsSuccess()
    {
        bool isSuccess = true;

        try
        {
            NekosV3Client client = new();
                
            foreach (var endpoint in Enum.GetValues<SfwImgEndpoint>())
                client.WithSfwImgEndpoint(endpoint).GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                
            foreach (var endpoint in Enum.GetValues<SfwGifEndpoint>())
                client.WithSfwGifEndpoint(endpoint).GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                
            foreach (var endpoint in Enum.GetValues<NsfwImgEndpoint>())
                client.WithNsfwImgEndpoint(endpoint).GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                
            foreach (var endpoint in Enum.GetValues<NsfwGifEndpoint>())
                client.WithNsfwGifEndpoint(endpoint).GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        } catch
        {
            isSuccess = false;
        }

        Assert.IsTrue(isSuccess);
    }
}