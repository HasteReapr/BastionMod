using EntityStates;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    public class AssaultToRecon : BaseSkillState
    {
        //This state only serves to play the transition animation and to replace the skills.
        public static float Duration = 0.3f; 

        public override void OnEnter()
        {
            base.OnEnter();

            PlayAnimation("FullBody, Override", "AssaultToRecon");

            //Override the recon skills with the assault skills, should be pretty simple
            if (base.skillLocator.primary != null)
            {
                base.skillLocator.primary.UnsetSkillOverride(gameObject, BastionStaticValues.assaultPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (base.skillLocator.utility != null)
            {
                base.skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.assaultUtility, GenericSkill.SkillOverridePriority.Network);
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
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Assault, 0);
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.AssaultPitch, 0);
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Frozen;
        }
    }
}
