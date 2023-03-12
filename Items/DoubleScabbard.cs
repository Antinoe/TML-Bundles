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
	public class DoubleScabbard : BaseBundle
	{
		override protected int maxCapacity() => BundlesConfig.Instance.capacityDoubleScabbard;
		protected override bool ValidContainedItem(Item item)
		{
			return item.maxStack == 1 && item.damage > 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Double Scabbard");
			Tooltip.SetDefault("Capable of holding tools and weapons.");
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
}