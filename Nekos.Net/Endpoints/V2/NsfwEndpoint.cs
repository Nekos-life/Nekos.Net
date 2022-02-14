using System;

namespace Nekos.Net.Endpoints.V2;

/// <summary>
///     List of NSFW endpoints
/// </summary>
[Flags]
public enum NsfwEndpoint : ulong
{
    /// <summary>
    ///     Everything except for Random.
    /// </summary>
    All = 0,

    /// <summary>
    ///     A random thing.
    ///     Use this if you don't know what to pick.
    /// </summary>
    Random = 1 << 0,

    /// <summary>
    ///     A NSFW neko girl image.
    /// </summary>
    Lewd = 1 << 1,

    /// <summary>
    ///     A lewd neko girl GIF.
    /// </summary>
    Eron = 1 << 2,

    /// <summary>
    ///     A NSFW neko girl GIF.
    /// </summary>
    NSFW_Neko_GIF = 1 << 3,

    /// <summary>
    ///     A NSFW fox girl image.
    /// </summary>
    LewdK = 1 << 4,

    /// <summary>
    ///     A lewd fox girl image.
    /// </summary>
    EroK = 1 << 5,

    /// <summary>
    ///     A NSFW holo image.
    ///     Holo from "Spice and Wolf", not hologrammed girl.
    /// </summary>
    HoloLewd = 1 << 6,

    /// <summary>
    ///     A lewd holo image.
    ///     Holo from "Spice and Wolf", not hologrammed girl.
    /// </summary>
    HoloEro = 1 << 7,

    /// <summary>
    ///     A lewd image.
    /// </summary>
    Ero = 1 << 8,

    /// <summary>
    ///     A NSFW feet image.
    /// </summary>
    Feet = 1 << 9,

    /// <summary>
    ///     A lewd feet image.
    /// </summary>
    EroFeet = 1 << 10,

    /// <summary>
    ///     A NSFW gasm image.
    /// </summary>
    Gasm = 1 << 11,

    /// <summary>
    ///     A NSFW solo girl image.
    /// </summary>
    Solo = 1 << 12,

    /// <summary>
    ///     A NSFW tits image.
    /// </summary>
    Tits = 1 << 13,

    /// <summary>
    ///     A NSFW yuri image.
    /// </summary>
    Yuri = 1 << 14,

    /// <summary>
    ///     A lewd yuri image.
    /// </summary>
    EroYuri = 1 << 15,

    /// <summary>
    ///     A NSFW hentai image.
    /// </summary>
    Hentai = 1 << 16,

    /// <summary>
    ///     A NSFW cum image. I don't the reason why this is JPEG?
    /// </summary>
    Cum_JPG = 1 << 17,

    /// <summary>
    ///     A NSFW femdom image.
    /// </summary>
    Femdom = 1 << 18,

    /// <summary>
    ///     A NSFW trap image.
    /// </summary>
    Trap = 1 << 19,

    /// <summary>
    ///     A NSFW pussy image. I don't the reason why this is JPEG?
    /// </summary>
    Pussy_JPG = 1 << 20,

    /// <summary>
    ///     A NSFW futa image.
    /// </summary>
    Futanari = 1 << 21,

    /// <summary>
    ///     A NSFW cum GIF.
    /// </summary>
    Cum = 1 << 22,

    /// <summary>
    ///     A NSFW solo girl GIF.
    /// </summary>
    SoloG = 1 << 23,

    /// <summary>
    ///     A NSFW spank GIF.
    /// </summary>
    Spank = 1 << 24,

    /// <summary>
    ///     A NSFW lesbians GIF.
    /// </summary>
    Les = 1 << 25,

    /// <summary>
    ///     A NSFW blowjob GIF.
    /// </summary>
    BJ = 1 << 26,

    /// <summary>
    ///     A NSFW pussy wank GIF.
    /// </summary>
    PWankG = 1 << 27,

    /// <summary>
    ///     A NSFW pussy GIF.
    /// </summary>
    Pussy = 1 << 28,

    /// <summary>
    ///     A NSFW hentai GIF.
    /// </summary>
    Random_Hentai_Gif = 1 << 29,

    /// <summary>
    ///     A NSFW feet GIF.
    /// </summary>
    FeetG = 1 << 30,

    /// <summary>
    ///     A NSFW pussy lick GIF.
    /// </summary>
    Kuni = (ulong) 1 << 31,

    /// <summary>
    ///     A NSFW classic GIF.
    /// </summary>
    Classic = (ulong) 1 << 32,

    /// <summary>
    ///     A NSFW boobs GIF.
    /// </summary>
    Boobs = (ulong) 1 << 33,

    /// <summary>
    ///     A NSFW anal GIF.
    /// </summary>
    Anal = (ulong) 1 << 34
}