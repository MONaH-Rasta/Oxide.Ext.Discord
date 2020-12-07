using System;

namespace Oxide.Ext.Discord.DiscordObjects
{
    [Flags]
    public enum ActivityFlags
    {
        Instance =	1 << 0,
        Join =	1 << 1,
        Spectate =	1 << 2,
        JoinRequest =	1 << 3,
        Sync =	1 << 4,
        Play =	1 << 5
    }
}