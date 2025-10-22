using EntityStates;
using RoR2;
using RoR2.Skills;
using UnityEngine;
using static BastionMod.Survivors.Bastion.SkillStates.TransformationDef;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    internal class TransformationDef : SkillDef
    {
        public string entryAnimState;
        public string exitAnimState;
        public string formName;
        public enum TransformationStates
        {
            recon = 0,
            assault = 1,
            bombard = 2,
            artillery = 3
        }

        public class InstanceData : BaseSkillInstanceData
        {
            public TransformationStates currentState;
        }

        public interface ISetTransformState
        {
            void SetState(TransformationStates state);
        }

        public override BaseSkillInstanceData OnAssigned(GenericSkill skillSlot)
        {
            return new InstanceData
            {
                currentState = TransformationStates.recon
            };
        }

        public override void OnUnassigned(GenericSkill skillSlot)
        {
            base.OnUnassigned(skillSlot);
        }
    }

    public class BastionStateDef
    {
        public SkillDef primary;
        public SkillDef utility;
        public SkillDef special;
    }

    internal class BaseTransformState : BaseSkillState
    {
        public BastionStateDef stateDef;

        public override void OnEnter()
        {
            base.OnEnter();
            ///We want to override OnEnter to set the next state in the skill. We do not override Update or Exit, as these arer things that wilkl happen automatically.
        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}