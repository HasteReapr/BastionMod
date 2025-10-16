using BastionMod.Survivors.Bastion.SkillStates;

namespace BastionMod.Survivors.Bastion
{
    public static class BastionStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(Primary));
            Modules.Content.AddEntityState(typeof(ReconToArtillery));
            Modules.Content.AddEntityState(typeof(ReconToAssault));

            Modules.Content.AddEntityState(typeof(AssaultPrimary));
            Modules.Content.AddEntityState(typeof(AssaultToArtillery));
            Modules.Content.AddEntityState(typeof(AssaultToRecon));

            Modules.Content.AddEntityState(typeof(ArtilleryPrimary));
            Modules.Content.AddEntityState(typeof(ArtilleryToAssault));
            Modules.Content.AddEntityState(typeof(ArtilleryToRecon));
        }
    }
}
