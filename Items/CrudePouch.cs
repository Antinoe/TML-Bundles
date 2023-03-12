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
	public class CrudePouch : BaseBundle
	{
		override protected int maxCapacity() => BundlesConfig.Instance.capacityCrudePouch;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crude Pouch");
		}
		public override string Texture => "Bundles/Items/Pouch";
		public override void SetDefaults()
		{
			Item.color = Color.GhostWhite;
			base.SetDefaults();
		}

		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enableCrudePouchRecipe)
			{
				Recipe Bundle = CreateRecipe(1);
				Bundle.AddIngredient(ItemID.Cobweb, BundlesConfig.Instance.amountCrudePouch);
				if (BundlesConfig.Instance.enableCrudePouchRecipeWorkBench)
				{
					Bundle.AddTile(TileID.WorkBenches);
				}
				if (BundlesConfig.Instance.enableCrudePouchRecipeLoom)
				{
					Bundle.AddTile(TileID.Loom);
				}
				Bundle.Register();
			}
		}

	}
}