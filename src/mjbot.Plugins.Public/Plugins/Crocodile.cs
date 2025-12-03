/*
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/.
 *
 * Copyright (c) 2025 BJMANIA
 */

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

using Microsoft.Extensions.Logging;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using MilkiBotFramework.Messaging;
using MilkiBotFramework.Plugining;
using MilkiBotFramework.Plugining.Attributes;
using MilkiBotFramework.Plugining.Configuration;
using mjbot.Configurations;
using System.ComponentModel;
using System.Text;
using System.Text.Json;

namespace mjbot.Plugins;

[PluginIdentifier("CD18B6F0-A703-7A7D-98DA-1BCBE5585890", Index = 1, Authors = "isaax", Scope = "game")]
class Crocodile(ILogger<DemoPlugin> logger,
    IConfiguration<TestConfiguration> configuration,
    IRichMessageConverter richMessageConverter,
    PluginManager pluginManager) : BasicPlugin
{
    [CommandHandler("goose", AllowedMessageType = MessageType.Channel)]
    public IResponse Group([Argument] string content)
    {
        byte[] bytes = Encoding.GetEncoding(51932).GetBytes(ChineseConverter.Convert(content, ChineseConversionDirection.SimplifiedToTraditional));
        string result = Encoding.GetEncoding(936).GetString(bytes);
        string text = "";
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] == '?' || content[i] == '，' || content[i] == '《' || content[i] == '》' || content[i] == '！' || content[i] == '？' || content[i] == '“' || content[i] == '”' || content[i] == '：' || content[i] == '；' || content[i] == '‘' || content[i] == '’' || content[i] == '【' || content[i] == '】' || content[i] == '…' || content[i] == '（' || content[i] == '）')
            {
                text += content[i];
            }
            else
            {
                text += result[i];
            }
        }
        return Reply(text);
    }

}