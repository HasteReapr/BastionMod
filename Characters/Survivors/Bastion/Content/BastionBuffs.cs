using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion
{
    public static class BastionBuffs
    {
        // armor buff gained during roll
        public static BuffDef installBuff;
        public static BuffDef uninstallBuff;
        public static void Init(AssetBundle assetBundle)
        {
            installBuff = Modules.Content.CreateAndAddBuff("BastionDragonBuff",
                LegacyResourcesAPI.Load<BuffDef>("BuffDefs/HiddenInvincibility").iconSprite,
                Color.red,
                false,
                false);

            uninstallBuff = Modules.Content.CreateAndAddBuff("BastionRecoverDebuff",
                LegacyResourcesAPI.Load<BuffDef>("BuffDefs/HiddenInvincibility").iconSprite,
                Color.gray,
                false,
                true);
        }
    }
}
