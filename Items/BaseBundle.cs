using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework; //	Text Colors.
using Microsoft.Xna.Framework.Input; //	Allows Left Shift to be detected.


namespace Bundles.Items
{
	public class BaseBundle : ModItem
	{
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
		
		public override void SetDefaults()
		{
			Item.maxStack = 1;
			Item.consumable = false;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.rare = ItemRarityID.Blue;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.autoReuse = true;
			Item.width = 20;
			Item.height = 20;
		}
		
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
			
			TooltipLine ShowControls = new TooltipLine(Mod, "ShowControls", "Right-Click with items in hand to stow them." + "\nRight-Click with an empty hand to withdraw items." + "\nShift-Right-Click to withdraw in reverse order.");
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
		
		public override bool? UseItem(Player player)
		{
			if (this.bundleList.Count != 0)
			{
				BundleDump();
				return true;
			}
			else
			{
				return false;
			}
		}
		
		//	Prevents the item from vanishing upon stowing items.
		public override bool ConsumeItem(Player player)
		{
			return false;
		}
		
		//	RightClick functions (inserting/extracting) cannot work without this.
		public override bool CanRightClick()
		{
			return true;
		}
		
		public override void RightClick(Player player)
		{
			int currentCapacity = 0;
			foreach (var Item in bundleList)
			{
				currentCapacity += Item.stack;
			}
			
			if (player.whoAmI == Main.myPlayer)
			{
				//	Inserting
				if (!Main.mouseItem.IsAir)
				{
					if (Main.mouseItem.stack <= maxCapacity() - currentCapacity)
					{
						if (this.ValidContainedItem(Main.mouseItem)) // Check if item is valid for this bundle
						{
							BundleInsert();
						}
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
			
			SoundEngine.PlaySound(Sounds.Item.BundleInsert, player.position);
			this.bundleList.Add(Main.mouseItem.Clone());
			Main.mouseItem.TurnToAir();
		}
		
		public void BundleExtract()
		{
			var player = Main.LocalPlayer;
			
			SoundEngine.PlaySound(Sounds.Item.BundleExtract, player.position);
			if (Main.keyState.IsKeyDown(Keys.LeftShift))
			{
				Item item = Enumerable.First<Item>(this.bundleList);
				Main.mouseItem = item.Clone();
				this.bundleList.Remove(item);
			}
			else
			{
				Item item = Enumerable.Last<Item>(this.bundleList);
				Main.mouseItem = item.Clone();
				this.bundleList.Remove(item);
			}
		}
		
		public void BundleDump()
		{
			var player = Main.LocalPlayer;
			var source = player.GetSource_OpenItem(Type);
			
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