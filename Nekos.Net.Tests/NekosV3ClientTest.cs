using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nekos.Net.V3;
using Nekos.Net.V3.Endpoints;

namespace Nekos.Net.Tests
{
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
                client.AllowLogging(false);
                
                IEnumerable<SfwImgEndpoint> availableFlags1 = Enum.GetValues<SfwImgEndpoint>();
                IEnumerable<SfwGifEndpoint> availableFlags2 = Enum.GetValues<SfwGifEndpoint>();
                IEnumerable<NsfwImgEndpoint> availableFlags3 = Enum.GetValues<NsfwImgEndpoint>();
                IEnumerable<NsfwGifEndpoint> availableFlags4 = Enum.GetValues<NsfwGifEndpoint>();
        
                foreach (SfwImgEndpoint endpoint in availableFlags1) client.WithSfwImgEndpoint(endpoint).GetSingleAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                foreach (SfwGifEndpoint endpoint in availableFlags2) client.WithSfwGifEndpoint(endpoint).GetSingleAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                foreach (NsfwImgEndpoint endpoint in availableFlags3) client.WithNsfwImgEndpoint(endpoint).GetSingleAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                foreach (NsfwGifEndpoint endpoint in availableFlags4) client.WithNsfwGifEndpoint(endpoint).GetSingleAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            } catch
            {
                isSuccess = false;
            }

            Assert.IsTrue(isSuccess);
        }
    }
}