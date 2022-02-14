using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using Serilog.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Nekos.Net.Client;

/// <summary>
///     A boilerplate client.
///     Normally you should not use this.
///     Use <see cref="NekosV2Client"/> or <see cref="NekosV3Client"/> class instead.
/// </summary>
public class BaseNekosClient
{
    /// <summary>
    ///     Base URL to send request.
    ///     Should be initialized through a constructor.
    /// </summary>
    protected static string HostUrl;
    
    /// <summary>
    ///     Logger to log the execution of program, an instance of Microsoft.Extensions.Logging.ILogger.
    ///     Defaults to Serilog's instance.
    /// </summary>
    protected static ILogger Logger;
    
    /// <summary>
    ///     Whether logging is allowed or not.
    /// </summary>
    protected bool IsLoggingAllowed;

    /// <summary>
    ///     A boilerplate client.
    ///     Normally you should not use this.
    ///     Use <see cref="NekosV2Client"/> or <see cref="NekosV3Client"/> class instead.
    /// </summary>
    static BaseNekosClient()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Debug()
            .CreateLogger();

        SerilogLoggerProvider logger = new(Log.Logger);
        Logger = logger.CreateLogger(nameof(BaseNekosClient));
    }

    /// <summary>
    ///     Create a client from other client.
    /// </summary>
    /// <param name="other">Other client.</param>
    protected BaseNekosClient(BaseNekosClient other)
    {
        IsLoggingAllowed = other.IsLoggingAllowed;
    }

    /// <summary>
    ///     Decides if you want to log the execution.
    /// </summary>
    /// <param name="allowLogging">true if logging is allowed, false otherwise.</param>
    protected BaseNekosClient(bool allowLogging = true)
    {
        IsLoggingAllowed = allowLogging;
    }

    /// <summary>
    ///     Decides if you want to log the execution.
    /// </summary>
    /// <param name="allowLogging">true if logging is allowed, false otherwise.</param>
    /// <returns>Post-configured client.</returns>
    public BaseNekosClient AllowLogging(bool allowLogging)
    {
        IsLoggingAllowed = allowLogging;
        return this;
    }

    /// <summary>
    ///     Override currently used logger with a new logger.
    /// </summary>
    /// <param name="logger">An instance of Microsoft.Extensions.Logging.ILogger.</param>
    /// <returns>Post-configured client.</returns>
    public BaseNekosClient SetLogger(ILogger logger)
    {
        Logger = logger;
        return this;
    }
    
    /// <summary>
    ///     Send the request asynchronously.
    /// </summary>
    /// <param name="destination">Full destination URl</param>
    /// <typeparam name="T">Class to deserialize from JSON.</typeparam>
    /// <returns>JSON-deserialized class.</returns>
    protected async Task<T> GetResponseV2<T>(string destination)
    {
        using var httpClient = new HttpClient();
        var req = new HttpRequestMessage(HttpMethod.Get, destination);
        var res = await httpClient.SendAsync(req);

        if (!res.IsSuccessStatusCode)
            if (IsLoggingAllowed)
                Logger.LogError($"{destination} returned status code: {res.StatusCode}");

        var response = await res.Content.ReadAsStringAsync();

        if (IsLoggingAllowed)
            Logger.LogDebug($"{destination} returned: {response}".Replace('\n', '\0'));

        return JsonConvert.DeserializeObject<T>(response);
    }
}