using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace module_2
{
    public static class MohawkGameWrapper
    {
        public static void RunGame()
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(Game.ScreenWidth, Game.ScreenHeight, Game.Title);

            // Set the target frames-per-second (FPS)
            Raylib.SetTargetFPS(Game.TargetFps);

            // Setup your game. This is a function YOU define.
            Game.Setup();

            // Loop so long as window should not close
            while (!Raylib.WindowShouldClose())
            {
                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();
                // Clear the canvas with one color
                Raylib.ClearBackground(Color.RayWhite);
                // Your game code here. This is a function YOU define.
                Game.Update();
                // Stop drawing to the canvas, begin displaying the frame
                Raylib.EndDrawing();
            }
            // Close the window
            Raylib.CloseWindow();
        }

    }
}
