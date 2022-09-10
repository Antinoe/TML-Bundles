using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
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
				Recipe Bundle = CreateRecipe(1);
				Bundle.AddIngredient(ItemID.Silk, BundlesConfig.Instance.amountSilkPouch);
				if (BundlesConfig.Instance.enableSilkPouchRecipeWorkBench)
				{
					Bundle.AddTile(TileID.WorkBenches);
				}
				if (BundlesConfig.Instance.enableSilkPouchRecipeLoom)
				{
					Bundle.AddTile(TileID.Loom);
				}
				Bundle.Register();
			}
		}
		
	}
}