using Terraria.Audio;

namespace Bundles
{
	public static partial class Sounds
	{
		public static class Item
		{
			public static readonly SoundStyle BundleInsert = new($"{nameof(Bundles)}/Sounds/BundleInsert", 3)
			{
				Volume = 0.5f,
				PitchVariance = 0.25f,
				MaxInstances = 12
			};
			public static readonly SoundStyle BundleExtract = new($"{nameof(Bundles)}/Sounds/BundleExtract", 3)
			{
				Volume = 0.5f,
				PitchVariance = 0.25f,
				MaxInstances = 12
			};
			public static readonly SoundStyle BundleDump = new($"{nameof(Bundles)}/Sounds/BundleDump", 3)
			{
				Volume = 0.5f,
				PitchVariance = 0.25f,
				MaxInstances = 12
			};
		}
	}
}
