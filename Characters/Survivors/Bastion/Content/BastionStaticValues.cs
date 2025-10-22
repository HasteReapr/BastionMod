using System;
using BastionMod.Survivors.Bastion.SkillStates;
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

        internal static SkillDef assaultToRecon;
        //Artillery has 2 skills because Assault and Bombard are interhchangable.
        internal static SkillDef artilleryToAssault;
        internal static SkillDef artilleryUtilityBombard;
        internal static SkillDef bombardUtility;

        internal static SkillDef artilleryToRecon;
        internal static SkillDef assaultToArtillery;
        internal static SkillDef bombardSpecial;

        internal static BastionStateDef AssaultDef = new BastionStateDef
        {
            primary = assaultPrimary,
            utility = assaultToRecon,
            special = assaultToArtillery
        };
        
        internal static BastionStateDef ArtilleryDef = new BastionStateDef
        {
            primary = artilleryPrimary,
            utility = artilleryToAssault,
            special = artilleryToRecon
        };
    }
}