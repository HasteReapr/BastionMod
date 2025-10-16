using EntityStates;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    public class HealSelf : BaseSkillState
    {
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Pain;
        }
    }
}
