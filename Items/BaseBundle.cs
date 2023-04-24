using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework; //	Colors, for both Text and Bundle Color.
using Microsoft.Xna.Framework.Input; //	Allows Left Shift to be detected.


namespace Bundles.Items
{
	public class BaseBundle : ModItem
	{
		protected int colorDelay = 0;
		protected bool isBundle = true;
		//	Properties changed by the other bundles
		protected virtual int maxCapacity() => 999;
		virtual protected bool ValidContainedItem(Item item)
        {
			return item.maxStack > 1; //	If the item isn't unstackable.
        }

		private List<Item> bundleList = new List<Item>();
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Base Bundle");
		}
		public override string Texture => "Bundles/Items/Bundle";
		
		public override void SetDefaults()
		{
			Item.maxStack = 1;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.rare = ItemRarityID.Blue;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.autoReuse = true;
			Item.width = 20;
			Item.height = 20;
		}
		
		public override bool? UseItem(Player player)
		{
			if (this.bundleList.Count != 0)
			{
				BundleDump();
				return true;
			}
			return false;
		}
		
		//	Prevents the item from vanishing upon stowing items.
		public override bool ConsumeItem(Player player)	{	return false;	}
		//	RightClick functions (inserting/extracting) cannot work without this.
		public override bool CanRightClick()	{	return true;	}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
            Player player = Main.player[Main.myPlayer]; //	This is here so we can detect if the Player is using certain controls.
			
			int currentCapacity = 0;
			foreach (var item in bundleList)
			{
				currentCapacity += item.stack;
			}
			TooltipLine CurrentCapacity = new TooltipLine(Mod, "CurrentCapacity", $"Capacity: {currentCapacity}/{maxCapacity()}"); //	Displays the Current Capacity of the Bundle.
			tooltips.Add(CurrentCapacity);
			CurrentCapacity.OverrideColor = Color.Cyan; //	Color of the Capacity.
			
			TooltipLine ShowControls = new TooltipLine(Mod, "ShowControls", "Right-Click with items in hand to stow them.\nRight-Click with an empty hand to withdraw items.\nShift-Right-Click to withdraw in reverse order.\nPress S while holding Shift to cycle between colors.");
			ShowControls.OverrideColor = Color.Orange; //	Color of the Controls Preview.
			
			if (player.controlUp) //	If holding Up.
			{
				tooltips.Add(ShowControls);
			}
			
			foreach (Item item in Enumerable.Reverse<Item>(this.bundleList))
			{
				tooltips.Add(new TooltipLine(Mod, "ItemInfo", item.HoverName)); //	Displays each item in the Item List.
			}
		}
		public override void UpdateInventory(Player player)
		{
			if (!Main.mouseItem.IsAir && Main.mouseItem.ModItem is BaseBundle)
			{
				if (colorDelay > 0) {	colorDelay--;	}
				if (colorDelay <= 0 && player.controlDown && Main.keyState.IsKeyDown(Keys.LeftShift))
				{
					colorDelay = 15;
					switch (Main.rand.Next(5))
					{
						case 1:	Main.mouseItem.color = Color.DarkOliveGreen;	break;
						case 2:	Main.mouseItem.color = Color.CornflowerBlue;	break;
						case 3:	Main.mouseItem.color = Color.DarkViolet;	break;
						case 4:	Main.mouseItem.color = Color.Firebrick;	break;
						case 5:	Main.mouseItem.color = Color.DarkOrange;	break;
						case 6:	Main.mouseItem.color = Color.Gold;	break;
					}
					//	Old chance-based system..
					/*
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.DarkGreen;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.Green;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.LightGreen;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.DarkBlue;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.Blue;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.LightBlue;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.Purple;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.Pink;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.LightPink;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.DarkRed;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.Red;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.DarkOrange;	}
					if (Main.rand.Next(4) == 0)	{	Main.mouseItem.color = Color.Orange;	}
					*/
				}
			}
		}
		
		public override void RightClick(Player player)
		{
			int currentCapacity = 0;
			foreach (var Item in bundleList)
			{
				currentCapacity += Item.stack;
			}
			var spareCapacity = maxCapacity() - currentCapacity;
			
			if (player.whoAmI == Main.myPlayer)
			{
				//	Inserting
				if (!Main.mouseItem.IsAir)
				{
					if (this.ValidContainedItem(Main.mouseItem)) //	Check if item is valid for this bundle
					{
						//	If Item Stack is less than or equal to Spare Capacity.
						if (Main.mouseItem.stack <= spareCapacity)
						{
							BundleInsert();
						}
						//	Disabling this for now until I get it working correctly.
						//	If Item Stack is greater than Spare Capacity.
						/*if (Main.mouseItem.stack > spareCapacity)
						{
							BundleInsertPartial();
						}*/
					}
				}
				//	Extracting
				else
				{
					if (this.bundleList.Count != 0)
					{
						BundleExtract();
					}
				}
			}
		}
		
		public void BundleInsert()
		{
			var player = Main.LocalPlayer;
			
			if (BundlesConfig.Instance.enableDebugInfo)
			{
				Main.NewText("BundleInsert");
			}
			SoundEngine.PlaySound(Sounds.Item.BundleInsert, player.position);
			this.bundleList.Add(Main.mouseItem.Clone());
			Main.mouseItem.TurnToAir();
		}

		public void BundleInsertPartial()
		{
			var player = Main.LocalPlayer;
			//var item = Main.mouseItem;
			int currentCapacity = 0;
			foreach (var Item in this.bundleList)	{	currentCapacity += Item.stack;	}
			var spareCapacity = maxCapacity() - currentCapacity;
			var insertedStack = spareCapacity;
			var spareStack = Main.mouseItem.stack - insertedStack;
			
			if (BundlesConfig.Instance.enableDebugInfo)
			{
				Main.NewText("BundleInsertPartial");
			}
			//	Forgot what this logic does, but it seems destructive, so I'll worry about it later.
			/*if (Main.mouseItem.stack > spareCapacity)
			{
				insertedStack = spareCapacity;
			}
			else
			{
				Main.mouseItem.TurnToAir();
			}*/
			currentCapacity += insertedStack;
			Main.mouseItem.stack = spareStack;
			SoundEngine.PlaySound(Sounds.Item.BundleInsert, player.position);
			this.bundleList.Add(Main.mouseItem.Clone());
			//Main.mouseItem.TurnToAir();
		}
		
		public void BundleExtract()
		{
			var player = Main.LocalPlayer;
			
			if (BundlesConfig.Instance.enableDebugInfo)
			{
				Main.NewText("BundleExtract");
			}
			SoundEngine.PlaySound(Sounds.Item.BundleExtract, player.position);
			if (Main.keyState.IsKeyDown(Keys.LeftShift))
			{
				var item = Enumerable.First<Item>(this.bundleList);
				Main.mouseItem = item.Clone();
				this.bundleList.Remove(item);
			}
			else
			{
				var item = Enumerable.Last<Item>(this.bundleList);
				Main.mouseItem = item.Clone();
				this.bundleList.Remove(item);
			}
		}
		
		public void BundleDump()
		{
			var player = Main.LocalPlayer;
			var source = player.GetSource_OpenItem(Type);
			
			if (BundlesConfig.Instance.enableDebugInfo)
			{
				Main.NewText("BundleDump");
			}
			SoundEngine.PlaySound(Sounds.Item.BundleDump, player.position);
			Item item = Enumerable.Last<Item>(this.bundleList);
			//	@TODO: Probably .Clone() is redundant should be cloned by the spawn function
			player.QuickSpawnClonedItem(source, item.Clone(), item.stack);
			this.bundleList.Remove(item);
		}
		
		//	Start: Code that disallows the "Universal Item List" bug.
		public override void OnCreate(ItemCreationContext context)
        {
			bundleList = new List<Item>();
        }
		
        public override ModItem Clone(Item Item)
        {
            BaseBundle clone = (BaseBundle)base.Clone(Item);
            clone.bundleList = bundleList.Select(Item => Item.Clone()).ToList();
            return clone;
        }
		//	End: Code that disallows the "Universal Item List" bug.
		
		//	Start: Save/Load Data stuff.
		public override void SaveData(TagCompound tag)
		{
			List<TagCompound> bundleList = new List<TagCompound>();
			foreach (Item item in this.bundleList)
			{
				bundleList.Add(ItemIO.Save(item));
			}
			tag.Add("bundleList", bundleList);
		}

		public override void LoadData(TagCompound tag)
		{
			this.bundleList.Clear();
			foreach (TagCompound tag2 in Enumerable.ToList<TagCompound>(tag.GetList<TagCompound>("bundleList")))
			{
				this.bundleList.Add(ItemIO.Load(tag2));
			}
		}

		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(this.bundleList.Count);
			foreach (Item item in this.bundleList)
			{
				ItemIO.Send(item, writer, true, false);
			}
		}

		public override void NetReceive(BinaryReader reader)
		{
			this.bundleList.Clear();
			int count = reader.ReadInt32();
			for (int i = 0; i < count; i++)
			{
				this.bundleList.Add(ItemIO.Receive(reader, true, false));
			}
		}
		//	End: Save/Load Data stuff.
	}
}
