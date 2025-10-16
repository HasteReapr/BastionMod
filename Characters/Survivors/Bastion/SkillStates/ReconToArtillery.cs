using EntityStates;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    public class ReconToArtillery : BaseSkillState
    {
        //This state only serves to play the transition animation and to replace the skills.
        public static float baseDuration = 0.35f; //0.1 slower than the animation is just to give some breathing room.

        public override void OnEnter()
        {
            base.OnEnter();

            PlayAnimation("FullBody, Override", "ReconToArtillery");

            //Override the recon skills with the assault skills, should be pretty simple
            if (base.skillLocator.primary != null)
            {
                base.skillLocator.primary.SetSkillOverride(gameObject, BastionStaticValues.artilleryPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (base.skillLocator.utility != null)
            {
                base.skillLocator.utility.SetSkillOverride(gameObject, BastionStaticValues.artilleryUtilityAssault, GenericSkill.SkillOverridePriority.Network);
            }

            if (base.skillLocator.special != null)
            {
                base.skillLocator.special.SetSkillOverride(gameObject, BastionStaticValues.artilleryUnset, GenericSkill.SkillOverridePriority.Network);
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
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Artillery, 1);
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Frozen;
        }
    }
}
