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
		override protected int GetMaxCapacity() => BundlesConfig.Instance.capacityDoubleScabbard;
		protected override bool ValidContainedItem(Item item)
		{
			return item.maxStack == 1 && item.damage > 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Double Scabbard");
			Tooltip.SetDefault("Capable of holding tools and weapons.");
		}
		
		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enableDoubleScabbardRecipe)
			{
				CreateRecipe(1)
				.AddIngredient(ItemID.Leather, 10)
				.AddTile(TileID.Loom)
				.Register();
			}
		}
		
	}
}