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
	public class SilkPouch : BaseBundle
	{
		override protected int GetMaxCapacity() => BundlesConfig.Instance.capacitySilkPouch;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silk Pouch");
		}
		
		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enableSilkPouchRecipe)
			{
				CreateRecipe(1)
				.AddIngredient(ItemID.Silk, 5)
				.AddTile(TileID.Loom)
				.Register();
			}
		}
		
	}
}