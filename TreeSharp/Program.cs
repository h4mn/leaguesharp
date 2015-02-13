#region

using System;
using System.IO;
using System.Media;
using LeagueSharp.Common;
using TreeSharp.Properties;

#endregion

namespace TreeSharp
{
    internal class Program
    {
        public static Menu Menu;

        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            Menu = new Menu("TreeSharp", "TreeSharp", true);

            var alerts = Menu.AddMenu("Alert", "Alert Settings");
            alerts.AddBool("Trinket", "Alert No Trinket");

            var misc = Menu.AddMenu("Misc", "Misc Settings");
            var sounds = misc.AddMenu("Sound", "Sound Settings");
            sounds.AddBool("Load", "Play Load Sound");

            Menu.AddToMainMenu();

            if (sounds.Item("Load").IsActive())
            {
                new SoundObject(Resources.Load).Play();
            }
        }
    }


    internal class SoundObject
    {
        public static float LastPlayed;
        private static SoundPlayer _sound;

        public SoundObject(Stream sound)
        {
            LastPlayed = 0;
            _sound = new SoundPlayer(sound);
        }

        public void Play()
        {
            _sound.Play();
        }
    }
}