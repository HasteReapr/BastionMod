using System;
using BastionMod.Modules;
using BastionMod.Survivors.Bastion.Achievements;

namespace BastionMod.Survivors.Bastion
{
    public static class BastionTokens
    {
        public static void Init()
        {
            AddBastionTokens();

            ////uncomment this to spit out a lanuage file with all the above tokens that people can translate
            ////make sure you set Language.usingLanguageFolder and printingEnabled to true
            //Language.PrintOutput("Bastion.txt");
            ////refer to guide on how to build and distribute your mod with the proper folders
        }

        public static void AddBastionTokens()
        {
            string prefix = BastionSurvivor.Bastion_PREFIX;

            string desc = "Sol Bastion is a tough bruiser character who specializes in close range combat.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > Volcanic Viper!" + Environment.NewLine + Environment.NewLine
             + "< ! > Volcanic Viper!" + Environment.NewLine + Environment.NewLine
             + "< ! > Fafnir!" + Environment.NewLine + Environment.NewLine
             + "< ! > Volcanic Viper!" + Environment.NewLine + Environment.NewLine;

            string outro = "..and so he left, searching for a new identity.";
            string outroFailure = "..and so he vanished, forever a blank slate.";

            Language.Add(prefix + "NAME", "BAS-10");
            Language.Add(prefix + "DESCRIPTION", desc);
            Language.Add(prefix + "SUBTITLE", "The Flame of Corruption");
            Language.Add(prefix + "LORE", "sample lore");
            Language.Add(prefix + "OUTRO_FLAVOR", outro);
            Language.Add(prefix + "OUTRO_FAILURE", outroFailure);


            Language.Add("KEYWORD_COOLDOWN", "Items affecting Cooldown increase Tension gained.");
            Language.Add("KEYWORD_SPEED", "Items affecting attack speed instead translate to extra hits on all of The Prototype Gear's abilities.");
            Language.Add("KEYWORD_BIND", "P/K GunflameMelee" +
                "\nGrounded P/S Volcanic Viper" +
                "\nGrounded P/H Night Raid Vortex" +
                "\nK/S Bandit Revolver" +
                "\nK/H Bandit Bringer" +
                "\nGrounded S/H Fafnir" +
                "\nAerial P/S Break" +
                "\n P/K/S/H Dragon Install");

            #region Skins
            Language.Add(prefix + "MASTERY_SKIN_NAME", "Alternate");
            #endregion

            #region Passive
            Language.Add(prefix + "PASSIVE_NAME", "No Mercy");
            Language.Add(prefix + "PASSIVE_DESCRIPTION", "The Prototype Gear's basic abilities have no cooldowns, nor are they affected by attack speed. Hits with The Prototype Gear's abilities build the [Tension] Gauge. Items affecting ability stocks increase the capacity of the Tension Gauge.");
            #endregion

            #region Primary
            Language.Add(prefix + "PUNCH_NAME", "Gun");
            Language.Add(prefix + "PUNCH_DESC", Tokens.agilePrefix + $"Generic gun move. Deals <style=cIsDamage>{100f * BastionStaticValues.primaryCoef}% damage</style>.");
            #endregion

            #region Secondary
            Language.Add(prefix + "KICK_NAME", "Heal");
            Language.Add(prefix + "KICK_DESC", $"A lunging kick that can hit aerial enemies. Deals <style=cIsDamage>{100f * BastionStaticValues.primaryCoef}% damage</style> and builds a moderate amount of tension.");
            #endregion

            #region Utility
            Language.Add(prefix + "ASSAULT_NAME", "Configuration : Assault");
            Language.Add(prefix + "ASSAULT_DESC", $"gun go brrr");
            Language.Add(prefix + "SLASH_NAME", "Bombard");
            Language.Add(prefix + "SLASH_DESC", $"A wide reaching sword swipe in front. Deals <style=cIsDamage>{100f * BastionStaticValues.primaryCoef}% damage</style> and builds a medium amount of tension.");
            #endregion

            #region Special
            Language.Add(prefix + "HEAVY_NAME", "Configuration : Artillery");
            Language.Add(prefix + "HEAVY_DESC", $"Configure into Artillery mode. Replaces primary with a devastating airstrike.");
            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(BastionMasteryAchievement.identifier), "Bastion: Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(BastionMasteryAchievement.identifier), "As Bastion, beat the game or obliterate on Monsoon.");
            #endregion
        }
    }
}
