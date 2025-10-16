using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion
{
    public static class BastionBuffs
    {
        // armor buff gained during roll
        public static BuffDef turretArmorBuff;
        public static void Init(AssetBundle assetBundle)
        {
            turretArmorBuff = Modules.Content.CreateAndAddBuff("BastionTurretBuff",
                LegacyResourcesAPI.Load<BuffDef>("BuffDefs/HiddenInvincibility").iconSprite,
                Color.red,
                false,
                false);
        }
    }
}
