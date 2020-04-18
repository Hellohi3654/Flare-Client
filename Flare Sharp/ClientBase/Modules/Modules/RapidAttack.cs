﻿using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using System;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class RapidAttack: Module
    {
        byte[] defaultBytes = { 0x41, 0x80, 0x38, 0x00, 0x74, 0x76 };
        byte[] newBytes = { 0x41, 0x80, 0x38, 0x01, 0x74, 0x76 };
        public RapidAttack() : base("Rapid-Click", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            UInt64 facing = Minecraft.clientInstance.localPlayer.level.lookingEntity.addr;
            if(facing <= 0)
            {
                MCM.writeBaseBytes(Statics.rapidPlace, newBytes);
            } else
            {
                MCM.writeBaseBytes(Statics.rapidPlace, defaultBytes);
            }
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseBytes(Statics.rapidPlace, defaultBytes);
        }
    }
}
