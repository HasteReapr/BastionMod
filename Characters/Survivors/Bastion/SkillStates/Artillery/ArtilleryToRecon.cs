using BastionMod.Modules;
using EntityStates;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    public class ArtilleryToRecon : ShiftingSkill
    {
        //This state only serves to play the transition animation and to replace the skills.
        public static float Duration = 0.55f;

        public override void OnEnter()
        {
            base.OnEnter();

            PlayAnimation("FullBody, Override", "ArtilleryToRecon");

            Skills.UnsetStateSkills(this.skillLocator, BastionStaticValues.ArtilleryDef);
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

            PlayAnimation("AimPitch", "PitchControl");
            PlayAnimation("AimYaw", "YawControl");
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Yaw, 1);
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Pitch, 1);
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Frozen;
        }
    }
}
