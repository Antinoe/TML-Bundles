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
	public class ApparelCase : BaseBundle
	{
		override protected int GetMaxCapacity() => BundlesConfig.Instance.capacityApparelCase;
		protected override bool ValidContainedItem(Item item)
        {
			return item.defense > 0 || item.accessory || item.vanity;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apparel Case");
			Tooltip.SetDefault("Capable of holding clothing, accessories and armor.");
		}
		
		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enableApparelCaseRecipe)
			{
				CreateRecipe(1)
				.AddRecipeGroup(RecipeGroupID.IronBar, 2)
				.AddRecipeGroup(RecipeGroupID.Wood, 10)
				.AddTile(TileID.WorkBenches)
				.Register();
			}
		}
		
	}
}