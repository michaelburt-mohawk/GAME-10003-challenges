/* 
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 * 
 * Written by:
 *      Raphaël Tétreault
 * History:
 *      2024/05/30: Initial draft
 *      2024/09/01: Add state, add proper Draw functions, add proper Font handling
 */

using Raylib_cs;
using System.Numerics;

/// <summary>
///     Access text drawing functions.
/// </summary>
/// <remarks>
///     A static wrapper to standardize raylib's text API.
/// </remarks>
public static class Text
{
    // STATIC STATE

    /// <summary>
    ///     Text color.
    /// </summary>
    public static Color Color { get; set; } = Color.Black;
    /// <summary>
    ///     Text size in pixels.
    /// </summary>
    public static int Size { get; set; } = 32;
    /// <summary>
    ///     Text kerning (space between letters) in pixels.
    ///     Default is 0px.
    /// </summary>
    public static int Kerning { get; set; } = 0;
    /// <summary>
    ///     Text rotation in degrees (0-360).
    /// </summary>
    public static float Rotation { get; set; } = 35;
    /// <summary>
    ///     Text font.
    /// </summary>
    public static Font Font { get; set; }
    /// <summary>
    ///     Default monospace font.
    /// </summary>
    public static Font MonospaceFont { get; private set; }
    /// <summary>
    ///     Name of <see cref="Text.Font"/>.
    /// </summary>
    public static string FontName { get; private set; } = string.Empty;
    /// <summary>
    ///     Name of <see cref="Text.MonospaceFont"/>.
    /// </summary>
    public static string MonospaceFontName { get; private set; } = string.Empty;

    /// <summary>
    ///     Loads teh inital fonts.
    /// </summary>
    public static void Initialize()
    {
        // Load platform-dependant monospace font
        string monospaceFontPath = GetOsDefaultMonospaceFontPath();
        MonospaceFontName = Path.GetFileName(monospaceFontPath);
        MonospaceFont = Raylib.LoadFont(monospaceFontPath);
        ResetFont();
    }

    /// <summary>
    ///     Resets <see cref="Text.Font"/> to the default font.
    /// </summary>
    public static void ResetFont()
    {
        // Set main as the monospace font
        FontName = MonospaceFontName;
        Font = MonospaceFont;
    }

    /// <summary>
    ///     Draws <paramref name="text"/> at <paramref name="position"/> on screen.
    /// </summary>
    /// <param name="text">The text to draw.</param>
    /// <param name="position">The position to draw text at.</param>
    public static void Draw(string text, Vector2 position)
        => Draw(text, position, Font);

    /// <summary>
    ///     Draws <paramref name="text"/> at <paramref name="position"/> on screen.
    /// </summary>
    /// <param name="text">The text to draw.</param>
    /// <param name="position">The position to draw text at.</param>
    /// <param name="font">The font to draw with.</param>
    public static void Draw(string text, Vector2 position, Font font)
    {
        Raylib.DrawTextPro(font.RaylibData, text, position, Vector2.Zero, -Rotation, Size, Kerning, Color);
    }

    /// <summary>
    ///     Loads the typeface specified at <paramref name="filePath"/>.
    /// </summary>
    /// <param name="filePath">The path to the font file.</param>
    /// <returns>
    ///     Returns the loaded <see cref="global::Font"/>.
    /// </returns>
    /// <exception cref="FileNotFoundException">
    ///     Error thrown if the font file could not be found.
    /// </exception>
    public static Font LoadFont(string filePath)
    {
        bool success = File.Exists(filePath);
        if (success)
        {
            var font = Raylib.LoadFont(filePath);
            return font;
        }
        else
        {
            string msg = $"FONT: failed to find font {filePath}.";
            throw new FileNotFoundException(msg);
        }
    }

    /// <summary>
    ///     Loads the typeface with <paramref name="filename"/> and 
    ///     <paramref name="extension"/> in the user's system font directory (folder).
    /// </summary>
    /// <param name="filename">The font's file name.</param>
    /// <param name="extension">The font's extension.</param>
    /// <returns>
    ///     Returns the loaded <see cref="global::Font"/>.
    /// </returns>
    /// <exception cref="FileNotFoundException">
    ///     Error thrown if the font file could not be found.
    /// </exception>
    public static Font LoadFont(string filename, string extension)
    {
        string fontPath = GetOsFontPath(filename, extension);
        Font font = LoadFont(fontPath);
        return font;
    }


    // PRIVATE METHODS
    private static string GetOsDefaultMonospaceFontPath()
    {
        string[] fontFileNames = GetOsDefaultMonospaceFontNames();
        string[] extensions = [ "ttf", "otf" ];

        foreach (string fileName in fontFileNames)
        {
            foreach (string extension in extensions)
            {
                string filePath = GetOsFontPath(fileName, extension);
                if (File.Exists(filePath))
                {
                    return filePath;
                }
            }
        }
        
        // If failed, then return empty string.
        return string.Empty;
    }

    private static string[] GetOsDefaultMonospaceFontNames()
    {
        string[] fontFileName = Environment.OSVersion.Platform switch
        {
            // Windows
            PlatformID.Win32S or
            PlatformID.Win32Windows or
            PlatformID.Win32NT or
            PlatformID.WinCE => [ "Consola", "lucon", "cour"],
            // macOS
            PlatformID.MacOSX => [ "SFMono-Regular", "Menlo-Regular", "Monaco-Regular" ],
            // Assume Linux
            PlatformID.Unix => [ "DejaVu Sans Mono" ],
            // All others
            _ => throw new Exception("Unknown platform."),
        };
        return fontFileName;
    }

    private static string GetOsFontPath(string fontName, string type)
    {
        string fontsDir = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
        string fontPath = $"{fontsDir}/{fontName}.{type}";
        return fontPath;
    }
}