﻿using Discord.Commands;
using Discord.Commands.Permissions.Levels;
using Discord.Modules;

namespace Stormbot.Bot.Core.Modules
{
    public class TestModule : IModule
    {
        void IModule.Install(ModuleManager manager)
        {
            manager.CreateCommands("test", group =>
            {
                group.MinPermissions((int) PermissionLevel.BotOwner);

                group.CreateCommand("callback")
                    .Parameter("value", ParameterType.Unparsed)
                    .Do(async e =>
                    {
                        await e.Message.Delete();
                        await e.Channel.SafeSendMessage(e.GetArg("value"));
                    });
            });
        }
    }
}