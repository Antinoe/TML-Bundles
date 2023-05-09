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
	public class PocketCase : BaseBundle
	{
		override protected int maxCapacity() => BundlesConfig.Instance.capacityPocketCase;
		public override string Texture => "Bundles/Items/PocketCase";
		public override void SetDefaults()
		{
			Item.color = Color.BurlyWood;
			base.SetDefaults();
		}
		
		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enablePocketCaseRecipe)
			{
				Recipe Bundle = CreateRecipe(1);
				Bundle.AddRecipeGroup(RecipeGroupID.Wood, BundlesConfig.Instance.amountPocketCase);
				if (BundlesConfig.Instance.enablePocketCaseRecipeWorkBench)
				{
					Bundle.AddTile(TileID.WorkBenches);
				}
				Bundle.Register();
			}
		}
	}
	public class ApparelCase : BaseBundle
	{
		override protected int maxCapacity() => BundlesConfig.Instance.capacityApparelCase;
		protected override bool ValidContainedItem(Item item)
        {
			return item.defense > 0 || item.accessory || item.vanity;
		}

		public override string Texture => "Bundles/Items/ApparelCase";
		public override void SetDefaults()
		{
			Item.color = Color.BurlyWood;
			base.SetDefaults();
		}
		
		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enableApparelCaseRecipe)
			{
				Recipe Bundle = CreateRecipe(1);
				Bundle.AddRecipeGroup(RecipeGroupID.Wood, BundlesConfig.Instance.amountApparelCaseWood);
				Bundle.AddIngredient(ItemID.Leather, BundlesConfig.Instance.amountApparelCaseLeather);
				if (BundlesConfig.Instance.enableApparelCaseRecipeWorkBench)
				{
					Bundle.AddTile(TileID.WorkBenches);
				}
				if (BundlesConfig.Instance.enableApparelCaseRecipeLoom)
				{
					Bundle.AddTile(TileID.Loom);
				}
				Bundle.Register();
			}
		}
	}
	public class DoubleScabbard : BaseBundle
	{
		override protected int maxCapacity() => BundlesConfig.Instance.capacityDoubleScabbard;
		protected override bool ValidContainedItem(Item item)
		{
			return item.maxStack == 1 && item.damage > 0;
		}

		public override string Texture => "Bundles/Items/DoubleScabbard";
		public override void SetDefaults()
		{
			Item.color = Color.Peru;
			base.SetDefaults();
		}
		
		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enableDoubleScabbardRecipe)
			{
				Recipe Bundle = CreateRecipe(1);
				Bundle.AddIngredient(ItemID.Leather, BundlesConfig.Instance.amountDoubleScabbard);
				if (BundlesConfig.Instance.enableDoubleScabbardRecipeWorkBench)
				{
					Bundle.AddTile(TileID.WorkBenches);
				}
				if (BundlesConfig.Instance.enableDoubleScabbardRecipeLoom)
				{
					Bundle.AddTile(TileID.Loom);
				}
				Bundle.Register();
			}
		}
	}
	public class CheatBundle : BaseBundle
	{
		override protected int maxCapacity() => BundlesConfig.Instance.capacityCheatBundle;
		public override void SetDefaults()
		{
			Item.color = Color.Magenta;
			base.SetDefaults();
		}
	}
}