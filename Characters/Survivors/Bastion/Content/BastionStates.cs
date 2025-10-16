using BastionMod.Survivors.Bastion.SkillStates;

namespace BastionMod.Survivors.Bastion
{
    public static class BastionStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(Primary));
        }
    }
}
