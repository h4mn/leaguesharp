using System;
using LeagueSharp;
using LeagueSharp.Common;

namespace TreeSharp
{
    internal static class Alerts
    {
        public static bool DisplayTrinketAlert = true;

        static Alerts()
        {
            Game.OnGameUpdate += Game_OnGameUpdate;
        }

        private static void Game_OnGameUpdate(EventArgs args)
        {
            if (ObjectManager.Player.InFountain() || ObjectManager.Player.InShop())
            {
                DisplayTrinketAlert = true;
                return;
            }

            if (!DisplayTrinketAlert)
            {
                return;
            }

            var spell = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Trinket);

            if (spell == null || spell.Slot == SpellSlot.Unknown)
            {
                Game.PrintChat("You forgot a trinket!");
                DisplayTrinketAlert = false;
            }
        }
    }
}