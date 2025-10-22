using BastionMod.Modules;
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
            PlayAnimation("AimPitch", "PitchControl");
            PlayAnimation("AimYaw", "YawControl");

            Skills.UnsetStateSkills(this.skillLocator, BastionStaticValues.AssaultDef);
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
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Frozen;
        }
    }
}
