using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nekos.Net.Prototypes;
using Nekos.Net.V2.Endpoint;
using Nekos.Net.V2.Responses;

namespace Nekos.Net.V2;

/// <summary>
///     A client to interact with nekos.life API v2
/// </summary>
public class NekosV2Client : BaseNekosClient
{
    static NekosV2Client()
    {
        HostUrl = "https://nekos.life/api/v2";
    }

    /// <summary>
    ///     <inheritdoc/>
    /// </summary>
    public NekosV2Client() : base()
    {
    }
    
    /// <summary>
    ///     <inheritdoc/>
    /// </summary>
    public NekosV2Client(NekosV2Client other) : base(other)
    {
    }

    /// <summary>
    ///     <inheritdoc/>
    /// </summary>
    public NekosV2Client(ILogger logger, bool isLoggingAllowed = true) : base(logger, isLoggingAllowed)
    {
    }

    // segments
    private const string MediaRequestUrlSegment = "/img";
    private const string EightBallUrlSegment = "/8ball";
    private const string FactUrlSegment = "/fact";
    private const string NameUrlSegment = "/name";
    private const string OwOifyUrlSegment = "/owoify";
    private const string SpoilerUrlSegment = "/spoiler";
    private const string WhyUrlSegment = "/why";

    /// <summary>
    ///     Get SFW results.
    /// </summary>
    /// <param name="endpoints">Members of <see cref="SfwEndpoint" /> enum representing the endpoints.</param>
    /// <param name="count">How many times EACH INDIVIDUAL REQUEST should be made.</param>
    /// <returns>Requested SFW results.</returns>
    /// <exception cref="ArgumentException">When the count is zero.</exception>
    public async Task<IEnumerable<NekosImage>> RequestSfwResultsAsync(SfwEndpoint endpoints, uint count = 1)
    {
        if (count == 0)
            throw new ArgumentException("\"count\" must not be zero", nameof(count));
        
        List<NekosImage> responses = new();
        IEnumerable<SfwEndpoint> availableFlags = Enum.GetValues<SfwEndpoint>();

        foreach (var endpoint in availableFlags)
        {
            var isSet = (endpoint & endpoints) != 0;
            if (!isSet) continue;
            
            if (endpoint == SfwEndpoint.All)
            {
                var images = await RequestAllSfwAsync(count).ConfigureAwait(false);
                responses.AddRange(images);
                continue;
            }

            SfwEndpoint tempEndpoint = endpoint;

            while (tempEndpoint == SfwEndpoint.Random)
            {
                var r = new Random();
                // random is 0
                // so simply ignore it
                var indexPick = r.Next(1, Enum.GetNames(typeof(SfwEndpoint)).Length - 1);
                tempEndpoint = availableFlags.ToArray()[indexPick];

                if (IsLoggingAllowed)
                    NekoLogger.LogWarning($"Replaced \"Random\" with \"{tempEndpoint.ToString().ToLower()}\"");
            }

            var dest = tempEndpoint.ToString().ToLower();

            for (var i = 0; i < count; ++i)
            {
                var response = await GetResponse<NekosImage>($"{HostUrl}{MediaRequestUrlSegment}/{dest}").ConfigureAwait(false);
                responses.Add(response);
            }
        }

        return responses;
    }

    /// <summary>
    ///     Get NSFW results.
    /// </summary>
    /// <param name="endpoints">Members of <see cref="NsfwEndpoint" /> enum representing the endpoints.</param>
    /// <param name="count">How many times EACH INDIVIDUAL REQUEST should be made.</param>
    /// <returns>Requested NSFW results.</returns>
    /// <exception cref="ArgumentException">When the count is zero.</exception>
    public async Task<IEnumerable<NekosImage>> RequestNsfwResultsAsync(NsfwEndpoint endpoints, uint count = 1)
    {
        if (count == 0)
            throw new ArgumentException("\"count\" must not be zero", nameof(count));
        
        List<NekosImage> responses = new();
        IEnumerable<NsfwEndpoint> availableFlags = Enum.GetValues<NsfwEndpoint>();

        foreach (var endpoint in availableFlags)
        {
            var isSet = (endpoint & endpoints) != 0;
            if (!isSet) continue;
            
            if (endpoint == NsfwEndpoint.All)
            {
                var images = await RequestAllNsfwAsync(count).ConfigureAwait(false);
                responses.AddRange(images);
                continue;
            }
            
            NsfwEndpoint tempEndpoint = endpoint;
            while (tempEndpoint == NsfwEndpoint.Random)
            {
                var r = new Random();
                // random is 0
                // so simply ignore it
                var indexPick = r.Next(1, Enum.GetNames(typeof(NsfwEndpoint)).Length - 1);
                tempEndpoint = availableFlags.ToArray()[indexPick];

                if (IsLoggingAllowed)
                    NekoLogger.LogWarning($"Replaced \"Random\" with \"{tempEndpoint.ToString().ToLower()}\"");
            }

            var dest = tempEndpoint.ToString().ToLower();

            // special case
            if (endpoint == NsfwEndpoint.Random_Hentai_Gif) dest = "Random_hentai_gif";

            for (var i = 0; i < count; ++i)
            {
                var response = await GetResponse<NekosImage>($"{HostUrl}{MediaRequestUrlSegment}/{dest}").ConfigureAwait(false);
                responses.Add(response);
            }
        }

        return responses;
    }

    /// <summary>
    ///     Request to all NSFW endpoints.
    /// </summary>
    /// <param name="count">How many times EACH INDIVIDUAL REQUEST should be made.</param>
    /// <returns>A list of responses to all NSFW endpoints.</returns>
    /// <exception cref="ArgumentException">When the count is zero.</exception>
    public async Task<IEnumerable<NekosImage>> RequestAllNsfwAsync(uint count = 1)
    {
        if (count == 0)
            throw new ArgumentException("\"count\" must not be zero", nameof(count));
        
        if (IsLoggingAllowed)
            NekoLogger.LogWarning("Requesting to all NSFW endpoints");

        List<NekosImage> responses = new();
        IEnumerable<NsfwEndpoint> availableFlags = Enum.GetValues<NsfwEndpoint>();

        foreach (var endpoint in availableFlags)
        {
            if (endpoint is NsfwEndpoint.All or NsfwEndpoint.Random) continue;

            var dest = endpoint.ToString().ToLower();

            // special case
            if (endpoint == NsfwEndpoint.Random_Hentai_Gif) dest = "Random_hentai_gif";

            for (var i = 0; i < count; ++i)
            {
                var response = await GetResponse<NekosImage>($"{HostUrl}{MediaRequestUrlSegment}/{dest}").ConfigureAwait(false);
                responses.Add(response);
            }
        }

        return responses;
    }

    /// <summary>
    ///     Request to all NSFW endpoints.
    /// </summary>
    /// <param name="count">How many times EACH INDIVIDUAL REQUEST should be made.</param>
    /// <returns>A list of responses to all endpoints.</returns>
    /// <exception cref="ArgumentException">When the count is zero.</exception>
    public async Task<IEnumerable<NekosImage>> RequestAllSfwAsync(uint count = 1)
    {
        if (count == 0)
            throw new ArgumentException("\"count\" must not be zero", nameof(count));
        
        if (IsLoggingAllowed)
            NekoLogger.LogWarning("Requesting to all SFW endpoints");

        List<NekosImage> responses = new();
        IEnumerable<SfwEndpoint> availableFlags = Enum.GetValues<SfwEndpoint>();

        foreach (var endpoint in availableFlags)
        {
            if (endpoint is SfwEndpoint.All or SfwEndpoint.Random) continue;

            var dest = endpoint.ToString().ToLower();

            for (var i = 0; i < count; ++i)
            {
                var response = await GetResponse<NekosImage>($"{HostUrl}{MediaRequestUrlSegment}/{dest}").ConfigureAwait(false);
                responses.Add(response);
            }
        }

        return responses;
    }

    /// <summary>
    ///     Request an 8ball response.
    /// </summary>
    /// <returns>An 8ball response.</returns>
    public async Task<Nekos8Ball> Request8BallResponseAsync()
    {
        return await GetResponse<Nekos8Ball>($"{HostUrl}{EightBallUrlSegment}").ConfigureAwait(false);
    }

    /// <summary>
    ///     Request a list of facts.
    /// </summary>
    /// <param name="count">Number of facts you want to get.</param>
    /// <returns>List of facts.</returns>
    /// <exception cref="ArgumentException">When the count is zero.</exception>
    public async Task<IEnumerable<NekosFact>> RequestFactsAsync(uint count = 1)
    {
        if (count == 0)
            throw new ArgumentException("\"count\" must not be zero", nameof(count));
        
        List<NekosFact> facts = new();
        for (int i = 0; i < count; ++i)
            facts.Add(await GetResponse<NekosFact>($"{HostUrl}{FactUrlSegment}").ConfigureAwait(false));

        return facts;
    }
    
    /// <summary>
    ///     Request a list of names.
    /// </summary>
    /// <param name="count">Number of names you want to get.</param>
    /// <returns>List of names.</returns>
    /// <exception cref="ArgumentException">When the count is zero.</exception>
    public async Task<IEnumerable<NekosName>> RequestNamesAsync(uint count = 1)
    {
        if (count == 0)
            throw new ArgumentException("\"count\" must not be zero", nameof(count));
        
        List<NekosName> names = new();
        
        for (int i = 0; i < count; ++i)
            names.Add(await GetResponse<NekosName>($"{HostUrl}{NameUrlSegment}").ConfigureAwait(false));

        return names;
    }

    /// <summary>
    ///     OwO-ify your input text.
    /// </summary>
    /// <param name="text">Input text, must be between 1 and 200 in length.</param>
    /// <example>"hello" will become "hewwo"</example>
    /// <returns>OwO-ified input text.</returns>
    /// <exception cref="ArgumentException">When the input text is null, empty, consists of whitespaces or more than 200 characters.</exception>
    public async Task<NekosOwOify> RequestOwOifyTextAsync(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException($"Invalid text provided: {text}", nameof(text));

        if (text.Length > 200)
            throw new ArgumentException($"Text length must be under 200: {text}", nameof(text));

        return await GetResponse<NekosOwOify>($"{HostUrl}{OwOifyUrlSegment}?{nameof(text)}={text}");
    }
    
    /// <summary>
    ///     Cover EVERY CHARACTERS of your input text with Discord-style spoiler.
    /// </summary>
    /// <example>"abc" will become "||a||||b||||c||"</example>
    /// <param name="text">Input text, must be between 1 and 200 in length.</param>
    /// <returns>Spoiler-covered input text.</returns>
    /// <exception cref="ArgumentException">When the input text is null, empty, consists of whitespaces or more than 200 characters.</exception>
    public async Task<NekosOwOify> RequestSpoilerAsync(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException($"Invalid text provided: {text}", nameof(text));

        if (text.Length > 200)
            throw new ArgumentException($"Text length must be under 200: {text}", nameof(text));

        return await GetResponse<NekosOwOify>($"{HostUrl}{SpoilerUrlSegment}?{nameof(text)}={text}");
    }

    /// <summary>
    ///     Request a list of why-questions.
    /// </summary>
    /// <param name="count">Number of why-questions you want to get.</param>
    /// <returns>List of why-questions.</returns>
    /// <exception cref="ArgumentException">When the count is zero.</exception>
    public async Task<IEnumerable<NekosWhy>> RequestWhyQuestionsAsync(uint count = 1)
    {
        if (count == 0)
            throw new ArgumentException("\"count\" must not be zero", nameof(count));
        
        List<NekosWhy> questions = new();
        
        for (int i = 0; i < count; ++i)
            questions.Add(await GetResponse<NekosWhy>($"{HostUrl}{WhyUrlSegment}").ConfigureAwait(false));

        return questions;
    }
}