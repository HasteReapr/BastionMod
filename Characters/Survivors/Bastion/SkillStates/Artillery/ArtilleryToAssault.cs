using EntityStates;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    public class ArtilleryToAssault : BaseSkillState
    {
        //This state only serves to play the transition animation and to replace the skills.
        public static float Duration = 0.55f;

        public override void OnEnter()
        {
            base.OnEnter();

            PlayAnimation("FullBody, Override", "ArtilleryToAssault");
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Assault, 1);
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Artillery, 0);

            //Override the recon skills with the assault skills, should be pretty simple
            if (base.skillLocator.primary != null)
            {
                base.skillLocator.primary.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryPrimary, GenericSkill.SkillOverridePriority.Network);

                base.skillLocator.primary.SetSkillOverride(gameObject, BastionStaticValues.assaultPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (base.skillLocator.utility != null)
            {
                base.skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryUtilityAssault, GenericSkill.SkillOverridePriority.Network);

                base.skillLocator.utility.SetSkillOverride(gameObject, BastionStaticValues.assaultUtility, GenericSkill.SkillOverridePriority.Network);
            }

            if (base.skillLocator.special != null)
            {
                base.skillLocator.special.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryUnset, GenericSkill.SkillOverridePriority.Network);

                base.skillLocator.special.SetSkillOverride(gameObject, BastionStaticValues.assaultSpecial, GenericSkill.SkillOverridePriority.Network);
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
