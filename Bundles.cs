using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.Audio;
using Terraria.ID;

namespace Bundles
{
	public class Bundles : Mod
	{
        public override void Load()
        {
            base.Load();
            BundlesConfig.Instance = ModContent.GetInstance<BundlesConfig>();
        }
    }
}