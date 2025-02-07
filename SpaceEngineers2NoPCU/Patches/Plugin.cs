using HarmonyLib;
using Keen.Game2.Simulation.GameSystems.PCU;
using Keen.Game2.Simulation.GameSystems.Ownership;
using System.Reflection;

namespace SpaceEngineers2NoPCU
{
    [HarmonyPatch(typeof(PCUSessionComponent), "HasPCU")]
    public class PCUSessionComponent_hasPCU_patch
    {
        public static bool Prefix(ref bool __result, PCUSessionComponent __instance, IdentityId owner, int requiredPCU)
        {
            
            __result = true;

            
            var maxGlobalPCUField = typeof(PCUSessionComponent).GetField("_maxGlobalPCU", BindingFlags.NonPublic | BindingFlags.Instance);
            if (maxGlobalPCUField != null)
            {
                maxGlobalPCUField.SetValue(__instance, 999999999);
            }

            
            var globalPCUField = typeof(PCUSessionComponent).GetField("_globalPCU", BindingFlags.NonPublic | BindingFlags.Instance);
            if (globalPCUField != null)
            {
                globalPCUField.SetValue(__instance, 0);
            }

            
            var playerPCUField = typeof(PCUSessionComponent).GetField("_playerPCU", BindingFlags.NonPublic | BindingFlags.Instance);
            if (playerPCUField != null)
            {
                var playerPCU = playerPCUField.GetValue(__instance) as PCUPerPlayerData;
                if (playerPCU != null)
                {
                    
                    var maxPlayerPCUField = typeof(PCUPerPlayerData).GetField("_maxPCU", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (maxPlayerPCUField != null)
                    {
                        maxPlayerPCUField.SetValue(playerPCU, 999999999);
                    }

                    
                    var playerPCUUsageField = typeof(PCUPerPlayerData).GetField("_pCU", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (playerPCUUsageField != null)
                    {
                        playerPCUUsageField.SetValue(playerPCU, 0);
                    }
                }
            }

            return false; 
        }
    }
}
