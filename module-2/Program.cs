/*////////////////////////////////////////////////////////////////////////
 * Raylib-CS Template
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 * 
 * Written by:
 *      Raphaël Tétreault
 * History:
 *      2024/05/26: Initial version
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

        Raylib.InitWindow(game.screenWidth, game.screenHeight, game.title);
        Raylib.InitAudioDevice();
        Raylib.SetTargetFPS(game.targetFps);
        Text.Initialize();

        game.Setup();
        while (!Raylib.WindowShouldClose())
        {
            Raylib.SetWindowSize(game.screenWidth, game.screenHeight);
            Raylib.BeginDrawing();
            Raylib.ClearBackground(game.backgroundColor);
            game.Update();
            Raylib.EndDrawing();
        }

        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }
}