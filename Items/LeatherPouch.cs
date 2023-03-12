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
	public class LeatherPouch : BaseBundle
	{
		override protected int maxCapacity() => BundlesConfig.Instance.capacityLeatherPouch;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leather Pouch");
		}
		public override string Texture => "Bundles/Items/Pouch";
		public override void SetDefaults()
		{
			Item.color = Color.Sienna;
			base.SetDefaults();
		}

		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enableLeatherPouchRecipe)
			{
				Recipe Bundle = CreateRecipe(1);
				Bundle.AddIngredient(ItemID.Leather, BundlesConfig.Instance.amountLeatherPouch);
				if (BundlesConfig.Instance.enableLeatherPouchRecipeWorkBench)
				{
					Bundle.AddTile(TileID.WorkBenches);
				}
				if (BundlesConfig.Instance.enableLeatherPouchRecipeLoom)
				{
					Bundle.AddTile(TileID.Loom);
				}
				Bundle.Register();
			}
		}
		
	}
}