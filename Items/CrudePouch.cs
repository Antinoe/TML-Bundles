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
	public class CrudePouch : BaseBundle
	{
		override protected int GetMaxCapacity() => BundlesConfig.Instance.capacityCrudePouch;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crude Pouch");
		}

		public override void AddRecipes()
		{
			if (BundlesConfig.Instance.enableCrudePouchRecipe)
			{
				CreateRecipe(1)
				.AddIngredient(ItemID.Cobweb, 10)
				.Register();
			}
		}

	}
}