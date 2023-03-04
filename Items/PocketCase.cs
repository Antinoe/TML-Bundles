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
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pocket Case");
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
}