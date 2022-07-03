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
		
        [Label("[i:Bundles/CrudePouch] Crude Pouch Capacity")]
        [Tooltip("How many items the Crude Pouch can hold.\n[Default: 10]")]
        [Slider]
        [DefaultValue(10)]
        [Range(5, 200)]
        [Increment(5)]
        public int capacityCrudePouch {get; set;}
		
        [Label("[i:Bundles/CrudeBundle] Crude Bundle Capacity")]
        [Tooltip("How many items the Crude Bundle can hold.\n[Default: 30]")]
        [Slider]
        [DefaultValue(30)]
        [Range(5, 200)]
        [Increment(5)]
        public int capacityCrudeBundle {get; set;}
		
        [Label("[i:Bundles/SilkPouch] Silk Pouch Capacity")]
        [Tooltip("How many items the Silk Pouch can hold.\n[Default: 25]")]
        [Slider]
        [DefaultValue(25)]
        [Range(5, 200)]
        [Increment(5)]
        public int capacitySilkPouch {get; set;}
		
        [Label("[i:Bundles/SilkBundle] Silk Bundle Capacity")]
        [Tooltip("How many items the Silk Bundle can hold.\n[Default: 50]")]
        [Slider]
        [DefaultValue(50)]
        [Range(5, 200)]
        [Increment(5)]
        public int capacitySilkBundle {get; set;}
		
        [Label("[i:Bundles/LeatherPouch] Leather Pouch Capacity")]
        [Tooltip("How many items the Leather Pouch can hold.\n[Default: 35]")]
        [Slider]
        [DefaultValue(35)]
        [Range(5, 200)]
        [Increment(5)]
        public int capacityLeatherPouch {get; set;}

        [Label("[i:Bundles/LeatherBundle] Leather Bundle Capacity")]
        [Tooltip("How many items the Leather Bundle can hold.\n[Default: 75]")]
        [Slider]
        [DefaultValue(75)]
        [Range(5, 200)]
        [Increment(5)]
        public int capacityLeatherBundle { get; set; }
		
        [Label("[i:Bundles/ApparelCase] Apparel Case Capacity")]
        [Tooltip("How many items the Apparel Case can hold.\n[Default: 5]")]
        [Slider]
        [DefaultValue(5)]
        [Range(1, 10)]
        [Increment(1)]
        public int capacityApparelCase {get; set;}
		
        [Label("[i:Bundles/DoubleScabbard] Double Scabbard Capacity")]
        [Tooltip("How many items the Double Scabbard can hold.\n[Default: 3]")]
        [Slider]
        [DefaultValue(3)]
        [Range(1, 10)]
        [Increment(1)]
        public int capacityDoubleScabbard {get; set;}
		
        [Label("[i:Bundles/CheatBundle] Cheat Bundle Capacity")]
        [Tooltip("How many items the Cheat Bundle can hold.\n[Default: 999]")]
        [Slider]
        [DefaultValue(999)]
        [Range(1, 9999)]
        [Increment(100)]
        public int capacityCheatBundle {get; set;}
		
        [Header("Recipes")]
		
        [Label("[i:Bundles/CrudePouch] Enable Crude Pouch Recipe")]
        [Tooltip("If false, Players cannot craft Crude Pouches.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool enableCrudePouchRecipe {get; set;}
		
        [Label("[i:Bundles/CrudeBundle] Enable Crude Bundle Recipe")]
        [Tooltip("If false, Players cannot craft Crude Bundles.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool enableCrudeBundleRecipe {get; set;}
		
        [Label("[i:Bundles/SilkPouch] Enable Silk Pouch Recipe")]
        [Tooltip("If false, Players cannot craft Silk Pouches.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool enableSilkPouchRecipe {get; set;}
		
        [Label("[i:Bundles/SilkBundle] Enable Silk Bundle Recipe")]
        [Tooltip("If false, Players cannot craft Silk Bundles.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool enableSilkBundleRecipe {get; set;}
		
        [Label("[i:Bundles/LeatherPouch] Enable Leather Pouch Recipe")]
        [Tooltip("If false, Players cannot craft Leather Pouches.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool enableLeatherPouchRecipe {get; set;}
		
        [Label("[i:Bundles/LeatherBundle] Enable Leather Bundle Recipe")]
        [Tooltip("If false, Players cannot craft Leather Bundles.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool enableLeatherBundleRecipe {get; set;}
		
        [Label("[i:Bundles/ApparelCase] Enable Apparel Case Recipe")]
        [Tooltip("If false, Players cannot craft Apparel Cases.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool enableApparelCaseRecipe {get; set;}
		
        [Label("[i:Bundles/DoubleScabbard] Enable Double Scabbard Recipe")]
        [Tooltip("If false, Players cannot craft Double Scabbards.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool enableDoubleScabbardRecipe {get; set;}
    }
}