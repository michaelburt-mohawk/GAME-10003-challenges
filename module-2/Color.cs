using System;

public struct Color
{
    private byte r;
    private byte g;
    private byte b;
    private byte a;

    /// <summary>
    ///     Red colour channel.
    /// </summary>
    public int R
    {
        readonly get => r;
        set => r = ConstrainAsByte(value);
    }
    /// <summary>
    ///     Green colour channel.
    /// </summary>
    public int G
    {
        readonly get => g;
        set => g = ConstrainAsByte(value);
    }
    /// <summary>
    ///     Blue colour channel.
    /// </summary>
    public int B
    {
        readonly get => b;
        set => b = ConstrainAsByte(value);
    }
    /// <summary>
    ///     Alpha colour channel.
    /// </summary>
    public int A
    {
        readonly get => a;
        set => a = ConstrainAsByte(value);
    }

    // CONSTRUCTORS
    public Color()
    {
        r = g = b = 0;
        a = 255;
    }
    public Color(int intensity)
    {
        r = g = b = ConstrainAsByte(intensity);
        a = 255;
    }
    public Color(int intensity, int opacity)
    {
        r = g = b = ConstrainAsByte(intensity);
        A = opacity;
    }
    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
        a = 255;
    }
    public Color(int r, int g, int b, int a)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    // Shades
    public static readonly Color Black = new(0);
    public static readonly Color DarkGray = new(64);
    public static readonly Color Gray = new(128);
    public static readonly Color LightGray = new(196);
    public static readonly Color White = new(255);
    public static readonly Color Blank = new(0, 0);
    // Colors
    public static readonly Color Red = new(255, 0, 0);
    public static readonly Color Yellow = new(255, 255, 0);
    public static readonly Color Green = new(0, 255, 0);
    public static readonly Color Cyan = new(0, 255, 255);
    public static readonly Color Blue = new(0, 0, 255);
    public static readonly Color Magenta = new(255, 0, 255);


    private static byte ConstrainAsByte(int value)
    {
        byte byteValue = (byte)Math.Clamp(value, 0, 255);
        return byteValue;
    }

    public static implicit operator Raylib_cs.Color(Color color)
    {
        Raylib_cs.Color raylibColor = new(color.r, color.g, color.b, color.a);
        return raylibColor;
    }
}