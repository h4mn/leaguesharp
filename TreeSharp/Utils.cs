using LeagueSharp.Common;

namespace TreeSharp
{
    internal static class Utils
    {
        public static void AddBool(this Menu menu, string name, string displayName, bool value = true)
        {
            menu.AddItem(new MenuItem(name, displayName).SetValue(value));
        }

        public static Menu AddMenu(this Menu menu, string name, string displayName)
        {
            return menu.AddSubMenu(new Menu(displayName, name));
        }
    }
}