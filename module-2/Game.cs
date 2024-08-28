using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_2
{
    internal static class Game
    {
        // If you need variables in the Program class (outside functions), you must mark them as static
        public static string Title = "Game Title"; // Window title
        public static int ScreenWidth = 800; // Screen width
        public static int ScreenHeight = 800; // Screen height
        public static int TargetFps = 60; // Target frames-per-second

        public static void Setup()
        {
            // Game setup code goes here
        }

        public static void Update()
        {
            // Code that runs on every frame goes here

            Raylib.DrawCircle(100, 100, 25, Color.Red);
        }
    }
}
