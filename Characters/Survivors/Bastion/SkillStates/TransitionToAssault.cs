using EntityStates;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    public class TransitionToAssault : BaseSkillState
    {
        //This state only serves to play the transition animation and to replace the skills.
        public static float baseDuration = 0.65f; //0.1 slower than the animation is just to give some breathing room.

        public override void OnEnter()
        {
            base.OnEnter();

            PlayAnimation("FullBody, Override", "ReconToAssault");
            PlayAnimation("AimPitch", "PitchControl Assault");
            PlayAnimation("AimYaw", "YawControl Assault");

            //Override the recon skills with the assault skills, should be pretty simple
            if (base.skillLocator.primary != null)
            {
                base.skillLocator.primary.SetSkillOverride(gameObject, BastionStaticValues.assaultPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (base.skillLocator.utility != null)
            {
                base.skillLocator.utility.SetSkillOverride(gameObject, BastionStaticValues.assaultUtility, GenericSkill.SkillOverridePriority.Network);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if(fixedAge >= baseDuration)
            {
                outer.SetNextStateToMain();
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Assault, 1);
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Frozen;
        }
    }
}
