/*
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/.
 *
 * Copyright (c) 2025 BJMANIA
 */

using System.ComponentModel;
using MilkiBotFramework.Plugining.Configuration;

namespace mjbot.Configurations;

public class TestConfiguration : ConfigurationBase
{
    [Description("Testing for comment in config file!")]
    public string Key1 { get; set; } = "";

    [Description("这是一条注释，这是个数字！")]
    public int Key2 { get; set; }
}