﻿/*////////////////////////////////////////////////////////////////////////
 * Raylib-CS Template
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 * 
 * Written by:
 *      Raphaël Tétreault
 *      Michael Burt
 * History:
 *      2024/05/26: Initial version
 *      2024/08/31: Minimal working example of a spritesheet
 *      
 * Attribution:
 *      Fantasy Knight - by aamatniekss on itch.io
 *      sprites in assets/ folder
 *      https://aamatniekss.itch.io/fantasy-knight-free-pixelart-animated-character
 *////////////////////////////////////////////////////////////////////////

using Raylib_cs;
using System;
using System.IO;

public class Program
{
    public static Font monospaceFont;

    static void Main()
    {
        // Create game instance
        Game game = new();

        // this is an advanced "post-processing" feature
        // https://en.wikipedia.org/wiki/Multisample_anti-aliasing
        Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);

        Raylib.InitWindow(game.ScreenWidth, game.ScreenHeight, game.Title);
        Raylib.InitAudioDevice();
        Raylib.SetTargetFPS(game.TargetFps);

        game.Setup();
        while (!Raylib.WindowShouldClose())
        {
            Raylib.SetWindowSize(game.ScreenWidth, game.ScreenHeight);
            Raylib.BeginDrawing();
            Raylib.ClearBackground(game.BackgroundColor);
            game.Update();
            Raylib.EndDrawing();
        }

        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }
}