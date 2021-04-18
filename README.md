### Welcome to Nekos.Net GitHub
A library to interact with nekos.life API. Currently working on v3 API support.

Made with C# and love ❤

[![GitHub license](https://img.shields.io/github/license/Nekos-life/Nekos.Net?style=flat-square)](https://github.com/Nekos-life/Nekos.Net/blob/master/LICENSE.md)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Nekos.Net?style=flat-square)

## Table of content:
- [Examples](#examples)
- [What's new](#whats-new)
- [Migration Guide](#migration-guide---oh-no-i-am-drowning-in-red-squiggles)
- [Join nekos.life family](#join-nekoslife-family)

### Examples
Available in [Nekos.Net.Examples](https://github.com/Nekos-life/Nekos.Net/tree/master/Nekos.Net.Examples) project

## What's new?
### 2.0.0 (TBA)
- Added v3 API support.

## Migration Guide - "Oh no, I am drowning in red squiggles"
### From 1.0.2 to 2.0.0
- `NekosClient` is now separated into 2 different clients: `NekosV2Client` and `NekosV3Client`
- In according to that, `NekosClient` (old) methods are moved to `NekosV2Client` class and _**no longer being static**_
- Enum name changes:
  + `NsfwEndpoint` (old) -> `NsfwEndpointV2` (applies to `SfwEndpoint`)
- Namespace changes:
  + `Nekos.Net.Responses` (old) -> `Nekos.Net.Responses.Version2`
  + `Nekos.Net.Endpoints` (old) -> `Nekos.Net.Endpoints.Version2`

### Join nekos.life family
- Discord server: https://discord.gg/r4Ju6TJ
- Patreon: https://patreon.com/nekos_life
- GitHub: https://github.com/Nekos-life


