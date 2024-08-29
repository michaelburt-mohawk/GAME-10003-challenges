using Raylib_cs;
using System;
using System.Numerics;

// MODULE 2 CHALLENGE

// Create a graphic design using basic shapes and text
// Some inspiration here:
// https://thumbs.dreamstime.com/z/neo-modernism-artwork-pattern-made-abstract-vector-geometric-shapes-forms-simple-form-bold-graphic-design-useful-web-234531432.jpg?w=992

// HARD CHALLENGE
// Get some input from the user, like mouse clicks, button presses, and change some visual aspect
// of those basic shapes. Maybe change the color, or position, or even trigger an animation!

public class Game
{
    private const int V = 0;

    // Variables needed to set up raylib
    public string Title = "Game Title";
    public int ScreenWidth = 800;
    public int ScreenHeight = 600;
    public int TargetFps = 60;
    public Color BackgroundColor = new Color(250, 200, 210, 255);

    // Place your variables here
    Font font;

    // you can use something as simple as Microsoft Paint to play around with colors and get their values
    Color firstColor = new Color(92, 81, 156, 255);
    Color secondColor = new Color(235, 98, 103, 255);
    Color thirdColor = new Color(133, 58, 108, 255);

    // i used the DebugMouseCoords() utility function to work out these values
    float firstRadius = 100.0f;
    int firstX = 400;
    int firstY = 300;

    // Setup runs once before the game loop begins.
    public void Setup()
    {
        font = Raylib.LoadFontEx("Fonts/RAVIE.ttf", 50, null, 0);

    }

    public void DebugMouseCoords()
    {
        int mouseX = Raylib.GetMouseX();
        int mouseY = Raylib.GetMouseY();
        Raylib.DrawTextEx(font, $"{mouseX}, {mouseY}", new(20, 20), 20, 3.0f, Color.Black);

    }

    // Update runs every frame.
    public void Update()
    {
        // try uncommenting this!
        //DebugMouseCoords();
        
        Raylib.DrawTextEx(font, "Causal Patterns", new(120, 70), 50, 3.0f, Color.Black);

        Raylib.DrawCircle(firstX, firstY, firstRadius, firstColor);

        float secondRadius = firstRadius / 2;

        // this is called a "cast". we are forcing the float to be an int
        int secondX = firstX + (int)secondRadius;
        
        Raylib.DrawCircle(secondX, firstY, secondRadius, secondColor);

        float thirdRadius = secondRadius / 2;
        int thirdX = secondX + (int)thirdRadius;

        Raylib.DrawCircle(thirdX, firstY, thirdRadius, thirdColor);

        // HARD CHALLENGE.. how to animate this graphic?

        // get the time since the window was initialized
        double t = Raylib.GetTime();

        // we'll learn about the cosine and sin functions later
        firstRadius = 100.0f + 20.0f * (float)Math.Sin(3.0 * t);
    }
}
