using EntityStates;
using RoR2;
using UnityEngine;
using BastionMod.Modules;

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
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Artillery, 0);

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

            //Then we go to assault
            PlayAnimation("AimPitch", "PitchControl Assault");
            PlayAnimation("AimYaw", "YawControl Assault");

            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Assault, 1);
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Yaw, 1);
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Pitch, 1);

            Skills.SetStateSkills(this.skillLocator, BastionStaticValues.AssaultDef);
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Frozen;
        }
    }
}
