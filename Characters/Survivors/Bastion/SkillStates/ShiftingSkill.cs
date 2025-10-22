using EntityStates;
using RoR2;
using UnityEngine;

namespace BastionMod.Survivors.Bastion.SkillStates
{
    public class ShiftingSkill : BaseSkillState
    {
        public void SetToRecon()
        {
            if (skillLocator.primary != null) { 
                skillLocator.primary.UnsetSkillOverride(gameObject, BastionStaticValues.assaultPrimary, GenericSkill.SkillOverridePriority.Network);
                skillLocator.primary.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (skillLocator.utility != null)
            {
                skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.assaultPrimary, GenericSkill.SkillOverridePriority.Network);
                skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (skillLocator.special != null)
            {
                skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.assaultToArtillery, GenericSkill.SkillOverridePriority.Network);
                skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryToRecon, GenericSkill.SkillOverridePriority.Network);
            }
        }

        public void SetToAssault()
        {
            if (skillLocator.primary != null)
            {
                skillLocator.primary.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryPrimary, GenericSkill.SkillOverridePriority.Network);

                skillLocator.primary.SetSkillOverride(gameObject, BastionStaticValues.assaultPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (skillLocator.utility != null)
            {
                skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryPrimary, GenericSkill.SkillOverridePriority.Network);

                skillLocator.utility.SetSkillOverride(gameObject, BastionStaticValues.assaultPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (skillLocator.special != null)
            {
                skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.artilleryToRecon, GenericSkill.SkillOverridePriority.Network);

                skillLocator.utility.SetSkillOverride(gameObject, BastionStaticValues.assaultToArtillery, GenericSkill.SkillOverridePriority.Network);
            }
        }

        public void SetToArtillery()
        {
            if (skillLocator.primary != null)
            {
                skillLocator.primary.UnsetSkillOverride(gameObject, BastionStaticValues.assaultPrimary, GenericSkill.SkillOverridePriority.Network);

                skillLocator.primary.SetSkillOverride(gameObject, BastionStaticValues.artilleryPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (skillLocator.utility != null)
            {
                skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.assaultPrimary, GenericSkill.SkillOverridePriority.Network);

                skillLocator.utility.SetSkillOverride(gameObject, BastionStaticValues.artilleryPrimary, GenericSkill.SkillOverridePriority.Network);
            }

            if (skillLocator.special != null)
            {
                skillLocator.utility.UnsetSkillOverride(gameObject, BastionStaticValues.assaultToArtillery, GenericSkill.SkillOverridePriority.Network);

                skillLocator.utility.SetSkillOverride(gameObject, BastionStaticValues.artilleryToRecon, GenericSkill.SkillOverridePriority.Network);
            }
        }
    }
}
