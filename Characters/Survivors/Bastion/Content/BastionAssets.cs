using RoR2;
using UnityEngine;
using BastionMod.Modules;
using System;
using RoR2.Projectile;
using UnityEngine.AddressableAssets;
using R2API;
using UnityEngine.Networking;

namespace BastionMod.Survivors.Bastion
{
    public static class BastionAssets
    {
        private static AssetBundle _assetBundle;

        public static void Init(AssetBundle assetBundle)
        {
            _assetBundle = assetBundle;

            CreateEffects();

            CreateProjectiles();
        }

        #region effects
        private static void CreateEffects()
        {

        }
        #endregion effects

        #region projectiles
        private static void CreateProjectiles()
        {

        }
        #endregion projectiles
    }
}
