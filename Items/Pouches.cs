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
	public class SilkPouch : BaseBundle
	{
		override protected int maxCapacity() => BundlesConfig.Instance.capacitySilkPouch;
		public override string Texture => "Bundles/Items/Pouch";
		public override void SetDefaults()
		{
			Item.color = Color.SteelBlue;
			base.SetDefaults();
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
	public class LeatherPouch : BaseBundle
	{
		override protected int maxCapacity() => BundlesConfig.Instance.capacityLeatherPouch;
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