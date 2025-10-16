using EntityStates;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    public class ArtilleryToRecon : BaseSkillState
    {
        //This state only serves to play the transition animation and to replace the skills.
        public static float Duration = 0.55f;

        public override void OnEnter()
        {
            base.OnEnter();

            PlayAnimation("FullBody, Override", "ArtilleryToRecon");
            PlayAnimation("AimPitch", "PitchControl");
            PlayAnimation("AimYaw", "YawControl");

            //Override the recon skills with the assault skills, should be pretty simple
            if (base.skillLocator.primary != null)
            {
                base.skillLocator.primary.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (base.skillLocator.utility != null)
            {
                base.skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryUtilityAssault, GenericSkill.SkillOverridePriority.Network);
            }

            if (base.skillLocator.special != null)
            {
                base.skillLocator.special.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryUnset, GenericSkill.SkillOverridePriority.Network);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (fixedAge >= Duration)
            {
                outer.SetNextStateToMain();
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Artillery, 0);
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Frozen;
        }
    }
}
