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
	public class LeatherBundle : BaseBundle
	{
		override protected int GetMaxCapacity() => BundlesConfig.Instance.capacityLeatherBundle;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leather Bundle");
		}
		
		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enableLeatherBundleRecipe)
			{
				CreateRecipe(1)
				.AddIngredient(ItemID.Leather, 15)
				.AddTile(TileID.Loom)
				.Register();
			}
		}

	}
}