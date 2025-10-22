using EntityStates;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    public class ArtilleryPrimary : BaseSkillState
    {
        public float baseDuration = 0.1f;
        public float procCoef = 1;
        public float damageCoef = BastionStaticValues.assaultCoef;

        private float duration;
        private float recoil = 0.75f;
        private float range = 1024;
        private bool hasFired = false;
        public static GameObject tracerEffectPrefab = LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/Tracers/TracerGoldGat");

        private string muzzleString = "ArtilleryMuzzle";

        public override void OnEnter()
        {
            base.OnEnter();
            duration = baseDuration / attackSpeedStat;

            PlayAnimation("FullBody, Override", "ArtilleryIdle");
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (!hasFired)
                Fire();

            if (fixedAge > duration && isAuthority && hasFired)
            {
                outer.SetNextStateToMain();
                return;
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }

        private void Fire()
        {
            if (!hasFired)
            {
                hasFired = true;

                Chat.AddMessage("One big boom");

                characterBody.AddSpreadBloom(1.5f);
                EffectManager.SimpleMuzzleFlash(EntityStates.Commando.CommandoWeapon.FirePistol2.muzzleEffectPrefab, gameObject, muzzleString, false);

                if (isAuthority)
                {
                    AddRecoil(-1f * recoil, -2f * recoil, -0.5f * recoil, 0.5f * recoil);

                    EffectData tracerData = new EffectData();
                    tracerData.origin = GetModelChildLocator().FindChild(muzzleString).position + new Vector3(0, 999, 0);
                    tracerData.start = GetModelChildLocator().FindChild(muzzleString).position;

                    EffectManager.SpawnEffect(tracerEffectPrefab, tracerData, true);
                }
            }
        }
    }
}
