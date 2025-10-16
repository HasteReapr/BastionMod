using BepInEx.Configuration;
using BastionMod.Modules;

namespace BastionMod.Survivors.Bastion
{
    public static class BastionConfig
    {
        public static ConfigEntry<float> inputLeniency;
        public static ConfigEntry<float> airdashTime;

        public static void Init()
        {
            string section = "Bastion";

            inputLeniency = Config.BindAndOptions(
                section,
                "Input Leniency",
                0.15f,
                "How precise you need to be to input special moves." +
                "\nThe time the game holds onto an input.");//blank description will default to just the name
            
            airdashTime= Config.BindAndOptions(
                section,
                "Airdash Leniency",
                0.25f,
                "Note : Do not go below 0.25 seconds, it will make you instantly airdash if you jump while sprinting." +
                "\nThe time between leaving the ground and when an airdash can be performed.");//blank description will default to just the name
        }
    }
}
