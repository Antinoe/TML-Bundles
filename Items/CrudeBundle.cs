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
	public class CrudeBundle : BaseBundle
	{
		override protected int maxCapacity() => BundlesConfig.Instance.capacityCrudeBundle;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crude Bundle");
		}
		public override void SetDefaults()
		{
			Item.color = Color.GhostWhite;
			base.SetDefaults();
		}

		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enableCrudeBundleRecipe)
			{
				Recipe Bundle = CreateRecipe(1);
				Bundle.AddIngredient(ItemID.Cobweb, BundlesConfig.Instance.amountCrudeBundle);
				if (BundlesConfig.Instance.enableCrudeBundleRecipeWorkBench)
				{
					Bundle.AddTile(TileID.WorkBenches);
				}
				if (BundlesConfig.Instance.enableCrudeBundleRecipeLoom)
				{
					Bundle.AddTile(TileID.Loom);
				}
				Bundle.Register();
			}
		}

	}
}