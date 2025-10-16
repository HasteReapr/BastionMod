using System;
using RoR2.Skills;

namespace BastionMod.Survivors.Bastion
{
    public static class BastionStaticValues
    {
        //normals
        public const float primaryCoef = 0.7f;
        public const float assaultCoef = 1.1f;

        public const float healPerSecond = 10;
        public const float healPerLevel = 3;

        public const float grenadeCoef = 2.5f;
        public const float cannonCoef = 3.25f;
        public const float artilleryCoef = 50f;

        internal static SkillDef assaultPrimary;
        internal static SkillDef artilleryPrimary;
        internal static SkillDef bombardPrimary;

        internal static SkillDef assaultUtility;
        //Artillery has 2 skills because Assault and Bombard are interhchangable.
        internal static SkillDef artilleryUtilityAssault;
        internal static SkillDef artilleryUtilityBombard;
        internal static SkillDef bombardUtility;

        internal static SkillDef artilleryUnset;
        internal static SkillDef assaultSpecial;
        internal static SkillDef bombardSpecial;
    }
}