using System;
using RoR2.Skills;

namespace BastionMod.Survivors.Bastion
{
    public static class BastionStaticValues
    {
        //normals
        public const float primaryCoef = 0.7f;
        public const float grenadeCoef = 2.5f;
        public const float cannonCoef = 3.25f;
        public const float artilleryCoef = 50f;

        internal static SkillDef primary;
        internal static SkillDef assaultPrimary;
        internal static SkillDef artilleryPrimary;
        internal static SkillDef bombardPrimary;

        internal static SkillDef utility;
        internal static SkillDef assaultUtility;
        internal static SkillDef artilleryUtility;
        internal static SkillDef bombardUtility;
    }
}