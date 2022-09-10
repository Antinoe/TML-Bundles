using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework; //Text Colors.
using Microsoft.Xna.Framework.Input; //Allows Left Shift to be detected.


namespace Bundles.Items
{
	public class CheatBundle : BaseBundle
	{
		override protected int GetMaxCapacity() => BundlesConfig.Instance.capacityCheatBundle;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cheat Bundle");
		}
	}
}