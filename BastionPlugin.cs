using BepInEx;
using BastionMod.Survivors.Bastion;
using R2API.Utils;
using RoR2;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace BastionMod
{
    //[BepInDependency("com.rune580.riskofoptions", BepInDependency.DependencyFlags.SoftDependency)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    public class BastionPlugin : BaseUnityPlugin
    {
        public const string MODUID = "com.HasteReapr.BastionMod";
        public const string MODNAME = "BastionMod";
        public const string MODVERSION = "0.0.1";

        public const string DEVELOPER_PREFIX = "HASTEREAPR";

        public static BastionPlugin instance;

        void Awake()
        {
            instance = this;

            Log.Init(Logger);

            Modules.Language.Init();

            new BastionSurvivor().Initialize();

            new Modules.ContentPacks().Initialize();

            Hook();
        }

        private void Hook()
        {
            
        }
    }
}
