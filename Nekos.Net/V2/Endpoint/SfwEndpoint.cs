using System;

namespace Nekos.Net.V2.Endpoint;

/// <summary>
///     List of SFW endpoints
/// </summary>
[Flags]
public enum SfwEndpoint : ulong
{
    /// <summary>
    ///     Everything except for Random.
    /// </summary>
    /// <seealso cref="Random"/>
    All = 1 << 0,

    /// <summary>
    ///     A random thing.
    ///     Use this if you don't know what to pick.
    /// </summary>
    /// <remarks>May cause infinite loop issue if your luck is terrible.</remarks>
    Random = 1 << 1,

    /// <summary>
    ///     A neko girl image.
    /// </summary>
    Neko = 1 << 2,

    /// <summary>
    ///     A neko girl GIF.
    /// </summary>
    Ngif = 1 << 3,

    /// <summary>
    ///     A fox girl image.
    /// </summary>
    Fox_Girl = 1 << 4,

    /// <summary>
    ///     A holo image.
    ///     Holo from "Spice and Wolf", not hologrammed girl.
    /// </summary>
    Holo = 1 << 5,

    /// <summary>
    ///     A pat GIF.
    /// </summary>
    Pat = 1 << 6,

    /// <summary>
    ///     A poke GIF.
    /// </summary>
    Poke = 1 << 7,

    /// <summary>
    ///     A hug GIF.
    /// </summary>
    Hug = 1 << 8,

    /// <summary>
    ///     A cuddle GIF.
    /// </summary>
    Cuddle = 1 << 9,

    /// <summary>
    ///     A kiss GIF.
    /// </summary>
    Kiss = 1 << 10,

    /// <summary>
    ///     A feed GIF.
    /// </summary>
    Feed = 1 << 11,

    /// <summary>
    ///     A tickle GIF.
    /// </summary>
    Tickle = 1 << 12,

    /// <summary>
    ///     A smug GIF.
    /// </summary>
    Smug = 1 << 13,

    /// <summary>
    ///     A baka GIF.
    ///     You know, most tsunderes do it when you don't get their hints.
    /// </summary>
    Baka = 1 << 14,

    /// <summary>
    ///     A slap GIF.
    /// </summary>
    Slap = 1 << 15,

    /// <summary>
    ///     A real dog image.
    /// </summary>
    Woof = 1 << 16,

    /// <summary>
    ///     A real cat image.
    /// </summary>
    Meow = 1 << 17,

    /// <summary>
    ///     A real lizard image.
    /// </summary>
    Lizard = 1 << 18,

    /// <summary>
    ///     A real goose image.
    /// </summary>
    Goose = 1 << 19,
    
    /// <summary>
    ///     A generate waifu image.
    ///     Sadly the quality is not enough.
    /// </summary>
    Waifu = 1 << 20
}