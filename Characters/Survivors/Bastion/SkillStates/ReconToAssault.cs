using BastionMod.Modules;
using EntityStates;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    public class ReconToAssault : BaseSkillState
    {
        //This state only serves to play the transition animation and to replace the skills.
        public static float baseDuration = 0.65f; //0.1 slower than the animation is just to give some breathing room.

        public override void OnEnter()
        {
            base.OnEnter();

            PlayAnimation("FullBody, Override", "ReconToAssault");
            PlayAnimation("AimPitch", "PitchControl Assault");
            PlayAnimation("AimYaw", "YawControl Assault");

            Skills.SetStateSkills(this.skillLocator, BastionStaticValues.AssaultDef);
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
