### Nekos.Net
A C# library to interact with nekos.life API targetting .NET Core.

Available via NuGet.


### Example code snippet
```cs
using Nekos.Net;
using Nekos.Net.Responses;
using System.Threading.Tasks;

class Program
{ 
    // Assuming Main() method is created

    static async Task GetNekoStuffs()
    {
        NekosImage image = await NekosClient.GetRandomSfwAsync();
        Console.WriteLine(image.FileUrl);
    }
}
```

### Join nekos.life family
- Discord server: https://discord.gg/r4Ju6TJ
- Patreon: https://patreon.com/nekos_life
- nekos.life GitHub: https://github.com/Nekos-life