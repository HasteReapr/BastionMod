using EntityStates;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    public class AssaultToArtillery : BaseSkillState
    {
        //This state only serves to play the transition animation and to replace the skills.
        public static float Duration = 0.55f;

        public override void OnEnter()
        {
            base.OnEnter();

            PlayAnimation("FullBody, Override", "AssaultToArtillery");
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Assault, 0);
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Artillery, 1);

            //Override the recon skills with the assault skills, should be pretty simple
            if (base.skillLocator.primary != null)
            {
                base.skillLocator.primary.UnsetSkillOverride(gameObject, BastionStaticValues.assaultPrimary, GenericSkill.SkillOverridePriority.Network);

                base.skillLocator.primary.SetSkillOverride(gameObject, BastionStaticValues.artilleryPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (base.skillLocator.utility != null)
            {
                base.skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.assaultUtility, GenericSkill.SkillOverridePriority.Network);

                base.skillLocator.utility.SetSkillOverride(gameObject, BastionStaticValues.artilleryUtilityAssault, GenericSkill.SkillOverridePriority.Network);
            }

            if (base.skillLocator.special != null)
            {
                //We go back to Recon skills
                base.skillLocator.special.UnsetSkillOverride(gameObject, BastionStaticValues.assaultSpecial, GenericSkill.SkillOverridePriority.Network);
                //Then after Recon, set to artillery
                base.skillLocator.special.SetSkillOverride(gameObject, BastionStaticValues.artilleryUnset, GenericSkill.SkillOverridePriority.Network);
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
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Frozen;
        }
    }
}
