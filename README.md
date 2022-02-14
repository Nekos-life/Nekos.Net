# :tada: Welcome to `Nekos.Net` repository

> "A project made for nekos" - Swyrin

![GH_UserCount](https://badgen.net/github/dependents-repo/Swyreee/Nekos.Net)
![NG_LatestVersion](https://badgen.net/nuget/v/Nekos.Net/latest)
![NG_DLCount](https://badgen.net/nuget/dt/Nekos.Net)
![Discord_MemberCount](https://badgen.net/discord/members/BARzYz8)

`Nekos.Net` is an asynchronous library to interact with [nekos.life](https://nekos.life) API, currently
supporting both v2 and v3 API. If you love this repo, consider giving it a star :star:
-------------------------------------------------------------------------------------------------
# :question: How to use
### Version 2
```c#
namespace Hello.There.Nekos;

public class Test
{
    public async Task ExecuteMeAsync()
    {
        NekosV2Client client = new NekosV2Client();
        NekoOwoify owo = await client.OwOifyAsync("Hello world");
        Console.WriteLine(owo.owo);
    }
}
```
### Version 3
> :warning: This API version is still in development phase by the owners so this code snippet *might* change in the future
```c#
namespace Hello.There.Nekos;

public class Test
{
    public async Task ExecuteMeAsync()
    {
        NekosV3Client client = new NekosV3Client();
        NekosSingleResponse res = await client.WithSfwImgEndpoint(SfwImgEndpoint.Neko).GetSingle();
        Console.WriteLine(res.Data.Response.Url);
    }
}
```
-------------------------------------------------------------------------------------------------
# Want to join us?
- Discord: https://discord.com/invite/BARzYz8
- Patreon: https://patreon.com/nekos_life
- GitHub: https://github.com/Nekos-life