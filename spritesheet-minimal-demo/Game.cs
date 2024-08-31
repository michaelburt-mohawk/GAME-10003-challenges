using Raylib_cs;
using System;
using System.Numerics;

// minimal working spritesheet demo

public class Game
{
    // Variables needed to set up raylib
    public string Title = "Game Title";
    public int ScreenWidth = 800;
    public int ScreenHeight = 600;
    public int TargetFps = 60;
    public Color BackgroundColor = new Color(200, 240, 210, 255);

    // sprite textures and size - which is the same for all spritesheets here
    // (not always the case)
    private Texture2D idle;
    private Texture2D attack;
    private readonly Vector2 spriteSize = new(120, 80);

    // variables needed to set up animation framing
    private double animTime = 0.0;
    private int frameIndex = 0;
    private int frameCount = 10;

    // how many animation frames per second?
    // effectively sets the speed of the animation
    private int animFps = 10;

    // this gets calculated in Setup()
    private double animSecondsPerFrame = 0.0;

    // this animation system will always revert to the 
    // default animation, unless a different animation is set
    // by setting nextAnim
    private Texture2D defaultAnim;
    private Texture2D nextAnim;

    // Setup runs once before the game loop begins.
    public void Setup()
    {
        animSecondsPerFrame = 1.0 / animFps;

        idle = Raylib.LoadTexture("assets/_Idle.png");
        attack = Raylib.LoadTexture("assets/_Attack.png");

        defaultAnim = idle;
        nextAnim = idle;
    }

    // Update runs every frame.
    public void Update()
    {
        // Your game code run each frame here

        // increment the animTime until it equals the number of
        // seconds we want for the animation
        animTime += Raylib.GetFrameTime();
        if (animTime >= animSecondsPerFrame)
        {
            // then reset the time to zero
            animTime = 0.0;

            // bump to the next animation frame
            frameIndex++;

            // if the frame is over the max, then we go back to zero
            if (frameIndex >= frameCount)
            {
                frameIndex = 0;
                
                // once we play all the frames of a particular animation
                // revert to the default
                nextAnim = defaultAnim;
                frameCount = 10;
            }
        }

        // what are the problems with this approach?
        // notice that the idle animation and attack animation
        // have different frame counts... it becomes difficult to
        // keep track of all this information.
        if (Raylib.IsKeyPressed(KeyboardKey.F)) {
            frameIndex = 0;
            frameCount = 4;
            nextAnim = attack;
        }

        // set idle as the default anim
        Texture2D spriteTexture = nextAnim;

        Vector2 spritePosition = new(300, 300);
        Rectangle spriteSheetCrop = new(spriteSize.X * frameIndex, 0, spriteSize);
        Raylib.DrawTextureRec(spriteTexture, spriteSheetCrop, spritePosition, Color.White);
    }
}
