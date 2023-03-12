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
	public class LeatherBundle : BaseBundle
	{
		override protected int maxCapacity() => BundlesConfig.Instance.capacityLeatherBundle;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leather Bundle");
		}
		public override void SetDefaults()
		{
			Item.color = Color.Sienna;
			base.SetDefaults();
		}
		
		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enableLeatherBundleRecipe)
			{
				Recipe Bundle = CreateRecipe(1);
				Bundle.AddIngredient(ItemID.Leather, BundlesConfig.Instance.amountLeatherBundle);
				if (BundlesConfig.Instance.enableLeatherBundleRecipeWorkBench)
				{
					Bundle.AddTile(TileID.WorkBenches);
				}
				if (BundlesConfig.Instance.enableLeatherBundleRecipeLoom)
				{
					Bundle.AddTile(TileID.Loom);
				}
				Bundle.Register();
			}
		}

	}
}