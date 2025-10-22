using BastionMod.Modules;
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

            Skills.SetStateSkills(this.skillLocator, BastionStaticValues.ArtilleryDef);
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
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Yaw, 0);
            GetModelAnimator().SetLayerWeight((int)BastionSurvivor.BodyAnimatorLayer.Pitch, 0);
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Frozen;
        }
    }
}
