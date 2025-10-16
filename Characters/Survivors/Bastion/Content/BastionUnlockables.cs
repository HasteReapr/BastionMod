using BastionMod.Survivors.Bastion.Achievements;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion
{
    public static class BastionUnlockables
    {
        public static UnlockableDef characterUnlockableDef = null;
        public static UnlockableDef masterySkinUnlockableDef = null;

        public static void Init()
        {
            /*masterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                BastionMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(BastionMasteryAchievement.identifier),
                BastionSurvivor.instance.assetBundle.LoadAsset<Sprite>("texMasteryAchievement"));*/
        }
    }
}
