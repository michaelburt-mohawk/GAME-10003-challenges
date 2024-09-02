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
    // Variables needed to set up raylib
    public string title = "Module 2 Challenge: Graphic Design";
    public int screenWidth = 800;
    public int screenHeight = 600;

    // Place your variables here
    
    // load a custom font
    Font font;

    public Color backgroundColor = new Color(250, 200, 210, 255);

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
        font = Text.LoadFont("Fonts/RAVIE.ttf");
    }

    public void DebugMouseCoords()
    {
        int mouseX = Raylib.GetMouseX();
        int mouseY = Raylib.GetMouseY();

        Text.Size = 20;
        Text.Color = Color.Black;
        Text.Kerning = 3;
        Text.Font = font;
        Text.Rotation = 0;
        Text.Draw($"{mouseX}, {mouseY}", new(20, 20));
    }

    // Update runs every frame.
    public void Update()
    {
        Raylib.ClearBackground(backgroundColor);

        // try uncommenting this!
        DebugMouseCoords();

        Text.Size = 50;
        Text.Draw("Causal Patterns", new(120, 70));

        Text.Size = 15;
        Text.Draw("Left click to see an animation!", new(120, 140));

        Draw.FillColor = firstColor;
        Draw.Circle(firstX, firstY, firstRadius);

        float secondRadius = firstRadius / 2;

        // this is called a "cast". we are forcing the float to be an int
        int secondX = firstX + (int)secondRadius;

        Draw.FillColor = secondColor;
        Draw.Circle(secondX, firstY, secondRadius);

        float thirdRadius = secondRadius / 2;
        int thirdX = secondX + (int)thirdRadius;

        Draw.FillColor = thirdColor;
        Draw.Circle(thirdX, firstY, thirdRadius);

        // HARD CHALLENGE.. how to interact and animate this graphic?
        if (Raylib.IsMouseButtonDown((Raylib_cs.MouseButton)MouseButton.Left))
        {
            // we'll learn about the cosine and sin functions later
            firstRadius = 100.0f + 20.0f * (float)Math.Sin(3.0 * Time.Elapsed);
        }
    }
}
