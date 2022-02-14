// ReSharper disable InconsistentNaming

namespace Nekos.Net.Endpoints.V3;

/// <summary>
///     Represents for v3 SFW endpoints
/// </summary>
public class SfwEndpointV3
{
    public SfwGifEndpoint Gif;
    public SfwImgEndpoint Img;
}

public enum SfwImgEndpoint
{
    Lizard,
    _8ball,
    Cat,
    Neko,
    No_Tag_Avatar,
    Nekos_Avatars_Avatar,
    Wallpaper,
    Kitsune,
    Kiminonawa,
    Waifu,
    Keta_Avatar,
    Gecg,
    Shinobu,
    Holo_Avatar,
    Smug,
    Holo
}

public enum SfwGifEndpoint
{
    Baka,
    Tickle,
    Feed,
    Neko,
    Poke,
    Pat,
    Kiss,
    Hug,
    Cuddle,
    Slap,
    Smug
}