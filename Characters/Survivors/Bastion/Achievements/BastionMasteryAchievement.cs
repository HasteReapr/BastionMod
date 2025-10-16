﻿using RoR2;
using BastionMod.Modules.Achievements;

namespace BastionMod.Survivors.Bastion.Achievements
{
    //automatically creates language tokens "ACHIEVMENT_{identifier.ToUpper()}_NAME" and "ACHIEVMENT_{identifier.ToUpper()}_DESCRIPTION" 
    [RegisterAchievement(identifier, unlockableIdentifier, null, 10, null)]
    public class BastionMasteryAchievement : BaseMasteryAchievement
    {
        public const string identifier = BastionSurvivor.Bastion_PREFIX + "masteryAchievement";
        public const string unlockableIdentifier = BastionSurvivor.Bastion_PREFIX + "masteryUnlockable";

        public override string RequiredCharacterBody => BastionSurvivor.instance.bodyName;

        //difficulty coeff 3 is monsoon. 3.5 is typhoon for grandmastery skins
        public override float RequiredDifficultyCoefficient => 3;
    }
}