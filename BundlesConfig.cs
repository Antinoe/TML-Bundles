using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Bundles
{
	[Label("Server Config")]
	public class BundlesConfig : ModConfig
	{
		//This is here for the Config to work at all.
		public override ConfigScope Mode => ConfigScope.ServerSide;

		public static BundlesConfig Instance;
		
	[Header("General")]
		
		[Label("[i:Bundles/PocketCase] Pocket Case Capacity")]
		[Tooltip("How many items this can hold.\n[Default: 5]")]
		[Slider]
		[DefaultValue(5)]
		[Range(5, 200)]
		[Increment(5)]
		public int capacityPocketCase {get; set;}
		
		[Label("[i:Bundles/CrudePouch] Crude Pouch Capacity")]
		[Tooltip("How many items this can hold.\n[Default: 15]")]
		[Slider]
		[DefaultValue(15)]
		[Range(5, 200)]
		[Increment(5)]
		public int capacityCrudePouch {get; set;}
		
		[Label("[i:Bundles/CrudeBundle] Crude Bundle Capacity")]
		[Tooltip("How many items this can hold.\n[Default: 45]")]
		[Slider]
		[DefaultValue(45)]
		[Range(5, 200)]
		[Increment(5)]
		public int capacityCrudeBundle {get; set;}
		
		[Label("[i:Bundles/SilkPouch] Silk Pouch Capacity")]
		[Tooltip("How many items this can hold.\n[Default: 35]")]
		[Slider]
		[DefaultValue(35)]
		[Range(5, 200)]
		[Increment(5)]
		public int capacitySilkPouch {get; set;}
		
		[Label("[i:Bundles/SilkBundle] Silk Bundle Capacity")]
		[Tooltip("How many items this can hold.\n[Default: 75]")]
		[Slider]
		[DefaultValue(75)]
		[Range(5, 200)]
		[Increment(5)]
		public int capacitySilkBundle {get; set;}
		
		[Label("[i:Bundles/LeatherPouch] Leather Pouch Capacity")]
		[Tooltip("How many items this can hold.\n[Default: 50]")]
		[Slider]
		[DefaultValue(50)]
		[Range(5, 200)]
		[Increment(5)]
		public int capacityLeatherPouch {get; set;}

		[Label("[i:Bundles/LeatherBundle] Leather Bundle Capacity")]
		[Tooltip("How many items this can hold.\n[Default: 110]")]
		[Slider]
		[DefaultValue(110)]
		[Range(5, 200)]
		[Increment(5)]
		public int capacityLeatherBundle { get; set; }
		
		[Label("[i:Bundles/ApparelCase] Apparel Case Capacity")]
		[Tooltip("How many items this can hold.\n[Default: 5]")]
		[Slider]
		[DefaultValue(5)]
		[Range(1, 20)]
		[Increment(1)]
		public int capacityApparelCase {get; set;}
		
		[Label("[i:Bundles/DoubleScabbard] Double Scabbard Capacity")]
		[Tooltip("How many items this can hold.\n[Default: 3]")]
		[Slider]
		[DefaultValue(3)]
		[Range(1, 20)]
		[Increment(1)]
		public int capacityDoubleScabbard {get; set;}
		
		[Label("[i:Bundles/CheatBundle] Cheat Bundle Capacity")]
		[Tooltip("How many items this can hold.\n[Default: 999]")]
		[Slider]
		[DefaultValue(999)]
		[Range(1, 9999)]
		[Increment(100)]
		public int capacityCheatBundle {get; set;}
		
	[Header("Recipes")]
		
		[Label("[i:Bundles/PocketCase] Enable Pocket Case Recipe")]
		[Tooltip("If false, Players cannot craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enablePocketCaseRecipe {get; set;}
		
		[Label("[i:Bundles/PocketCase][i:WorkBench] Pocket Case at WorkBench")]
		[Tooltip("If true, a nearby WorkBench is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enablePocketCaseRecipeWorkBench {get; set;}
		
		[Label("[i:Bundles/PocketCase][i:Wood] Pocket Case Amount")]
		[Tooltip("How many materials are required to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: 5]")]
		[Slider]
		[DefaultValue(5)]
		[Range(1, 100)]
		[Increment(1)]
		public int amountPocketCase {get; set;}
		
		[Label("[i:Bundles/CrudePouch] Enable Crude Pouch Recipe")]
		[Tooltip("If false, Players cannot craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableCrudePouchRecipe {get; set;}
		
		[Label("[i:Bundles/CrudePouch][i:WorkBench] Crude Pouch at WorkBench")]
		[Tooltip("If true, a nearby WorkBench is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: Off]")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool enableCrudePouchRecipeWorkBench {get; set;}
		
		[Label("[i:Bundles/CrudePouch][i:Loom] Crude Pouch at Loom")]
		[Tooltip("If true, a nearby Loom is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: Off]")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool enableCrudePouchRecipeLoom {get; set;}
		
		[Label("[i:Bundles/CrudePouch][i:Cobweb] Crude Pouch Amount")]
		[Tooltip("How many materials are required to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: 15]")]
		[Slider]
		[DefaultValue(15)]
		[Range(1, 100)]
		[Increment(1)]
		public int amountCrudePouch {get; set;}
		
		[Label("[i:Bundles/CrudeBundle] Enable Crude Bundle Recipe")]
		[Tooltip("If false, Players cannot craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableCrudeBundleRecipe {get; set;}
		
		[Label("[i:Bundles/CrudePouch][i:WorkBench] Crude Bundle at WorkBench")]
		[Tooltip("If true, a nearby WorkBench is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: Off]")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool enableCrudeBundleRecipeWorkBench {get; set;}
		
		[Label("[i:Bundles/CrudePouch][i:Loom] Crude Bundle at Loom")]
		[Tooltip("If true, a nearby Loom is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: Off]")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool enableCrudeBundleRecipeLoom {get; set;}
		
		[Label("[i:Bundles/CrudeBundle][i:Cobweb] Crude Bundle Amount")]
		[Tooltip("How many materials are required to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: 30]")]
		[Slider]
		[DefaultValue(30)]
		[Range(1, 100)]
		[Increment(1)]
		public int amountCrudeBundle {get; set;}
		
		[Label("[i:Bundles/SilkPouch] Enable Silk Pouch Recipe")]
		[Tooltip("If false, Players cannot craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableSilkPouchRecipe {get; set;}
		
		[Label("[i:Bundles/SilkPouch][i:WorkBench] Silk Pouch at WorkBench")]
		[Tooltip("If true, a nearby WorkBench is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableSilkPouchRecipeWorkBench {get; set;}
		
		[Label("[i:Bundles/SilkPouch][i:Loom] Silk Pouch at Loom")]
		[Tooltip("If true, a nearby Loom is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: Off]")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool enableSilkPouchRecipeLoom {get; set;}
		
		[Label("[i:Bundles/SilkPouch][i:Silk] Silk Pouch Amount")]
		[Tooltip("How many materials are required to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: 2]")]
		[Slider]
		[DefaultValue(2)]
		[Range(1, 100)]
		[Increment(1)]
		public int amountSilkPouch {get; set;}
		
		[Label("[i:Bundles/SilkBundle] Enable Silk Bundle Recipe")]
		[Tooltip("If false, Players cannot craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableSilkBundleRecipe {get; set;}
		
		[Label("[i:Bundles/SilkBundle][i:WorkBench] Silk Bundle at WorkBench")]
		[Tooltip("If true, a nearby WorkBench is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableSilkBundleRecipeWorkBench {get; set;}
		
		[Label("[i:Bundles/SilkBundle][i:Loom] Silk Bundle at Loom")]
		[Tooltip("If true, a nearby Loom is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: Off]")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool enableSilkBundleRecipeLoom {get; set;}
		
		[Label("[i:Bundles/SilkBundle][i:Silk] Silk Bundle Amount")]
		[Tooltip("How many materials are required to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: 4]")]
		[Slider]
		[DefaultValue(4)]
		[Range(1, 100)]
		[Increment(1)]
		public int amountSilkBundle {get; set;}
		
		[Label("[i:Bundles/LeatherPouch] Enable Leather Pouch Recipe")]
		[Tooltip("If false, Players cannot craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableLeatherPouchRecipe {get; set;}
		
		[Label("[i:Bundles/LeatherPouch][i:WorkBench] Leather Pouch at WorkBench")]
		[Tooltip("If true, a nearby WorkBench is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: Off]")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool enableLeatherPouchRecipeWorkBench {get; set;}
		
		[Label("[i:Bundles/LeatherPouch][i:Loom] Leather Pouch at Loom")]
		[Tooltip("If true, a nearby Loom is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableLeatherPouchRecipeLoom {get; set;}
		
		[Label("[i:Bundles/LeatherPouch][i:Leather] Leather Pouch Amount")]
		[Tooltip("How many materials are required to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: 2]")]
		[Slider]
		[DefaultValue(2)]
		[Range(1, 100)]
		[Increment(1)]
		public int amountLeatherPouch {get; set;}
		
		[Label("[i:Bundles/LeatherBundle] Enable Leather Bundle Recipe")]
		[Tooltip("If false, Players cannot craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableLeatherBundleRecipe {get; set;}
		
		[Label("[i:Bundles/LeatherBundle][i:WorkBench] Leather Bundle at WorkBench")]
		[Tooltip("If true, a nearby WorkBench is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: Off]")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool enableLeatherBundleRecipeWorkBench {get; set;}
		
		[Label("[i:Bundles/LeatherBundle][i:Loom] Leather Bundle at Loom")]
		[Tooltip("If true, a nearby Loom is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableLeatherBundleRecipeLoom {get; set;}
		
		[Label("[i:Bundles/LeatherBundle][i:Leather] Leather Bundle Amount")]
		[Tooltip("How many materials are required to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: 4]")]
		[Slider]
		[DefaultValue(4)]
		[Range(1, 100)]
		[Increment(1)]
		public int amountLeatherBundle {get; set;}
		
		[Label("[i:Bundles/ApparelCase] Enable Apparel Case Recipe")]
		[Tooltip("If false, Players cannot craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableApparelCaseRecipe {get; set;}
		
		[Label("[i:Bundles/ApparelCase][i:WorkBench] Apparel Case at WorkBench")]
		[Tooltip("If true, a nearby WorkBench is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableApparelCaseRecipeWorkBench {get; set;}
		
		[Label("[i:Bundles/ApparelCase][i:Loom] Apparel Case at Loom")]
		[Tooltip("If true, a nearby Loom is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: Off]")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool enableApparelCaseRecipeLoom {get; set;}
		
		[Label("[i:Bundles/ApparelCase][i:Wood] Apparel Case Wood Amount")]
		[Tooltip("How much Wood is required to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: 10]")]
		[Slider]
		[DefaultValue(10)]
		[Range(1, 100)]
		[Increment(1)]
		public int amountApparelCaseWood {get; set;}
		
		[Label("[i:Bundles/ApparelCase][i:Leather] Apparel Case Leather Amount")]
		[Tooltip("How much Leather is required to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: 5]")]
		[Slider]
		[DefaultValue(5)]
		[Range(1, 100)]
		[Increment(1)]
		public int amountApparelCaseLeather {get; set;}
		
		[Label("[i:Bundles/DoubleScabbard] Enable Double Scabbard Recipe")]
		[Tooltip("If false, Players cannot craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableDoubleScabbardRecipe {get; set;}
		
		[Label("[i:Bundles/DoubleScabbard][i:WorkBench] Double Scabbard at WorkBench")]
		[Tooltip("If true, a nearby WorkBench is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool enableDoubleScabbardRecipeWorkBench {get; set;}
		
		[Label("[i:Bundles/DoubleScabbard][i:Loom] Double Scabbard at Loom")]
		[Tooltip("If true, a nearby Loom is require to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: Off]")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool enableDoubleScabbardRecipeLoom {get; set;}
		
		[Label("[i:Bundles/DoubleScabbard][i:Leather] Double Scabbard Amount")]
		[Tooltip("How many materials are required to craft this.\n(REQUIRES MOD RELOAD.)\n[Default: 10]")]
		[Slider]
		[DefaultValue(10)]
		[Range(1, 100)]
		[Increment(1)]
		public int amountDoubleScabbard {get; set;}
	}
}