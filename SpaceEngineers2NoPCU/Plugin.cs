using HarmonyLib;
using Keen.Game2.Game.Plugins;
using Keen.Game2.Simulation.GameSystems.PCU;
using Keen.VRage.Library.Diagnostics;
using System.Reflection;

namespace SpaceEngineers2NoPCU
{
    public class Plugin : IPlugin
    {
        public const string Name = "Space Engineers 2 - NO PCU";

        public Plugin()
        {
            Log.Default.WriteLine($"[{Name}] loaded...");
#if DEBUG
            Harmony.DEBUG = true;
#endif
            Harmony harmony = new Harmony(Name);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            Log.Default.WriteLine($"[{Name}] applied...");
        }
    }
}
