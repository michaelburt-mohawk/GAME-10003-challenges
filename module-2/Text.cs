/* 
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 * 
 * Written by:
 *      Raphaël Tétreault
 * History:
 *      2024/05/30: Initial draft
 */

using Raylib_cs;
using System;
using System.IO;
using System.Numerics;

/// <summary>
///     TBD
/// </summary>
public static class Text
{
    // State
    public static Color Color { get; set; } = Color.Black;
    public static int Size { get; set; } = 32;
    public static Font DefaultFont { get; set; }
    public static Font MonospaceFont { get; set; }
    public static string MonoSpacedFontName { get; private set; } = string.Empty;


    public static void Initialize()
    {
        DefaultFont = Raylib.GetFontDefault();

        string monospacedFontPath = GetOsDefaultMonospacedFontPath();
        MonoSpacedFontName = Path.GetFileName(monospacedFontPath);
        MonospaceFont = Raylib.LoadFont(monospacedFontPath);
    }

    public static void Draw(string text, Vector2 position)
    {
        float spacing = Size / 16f;
        Raylib.DrawTextPro(DefaultFont, text, position, Vector2.Zero, 0, Size, spacing, Color);
    }

    public static void Draw(string text, Font font, Color color, Vector2 position, float rotation, float kerning, float fontSize)
    {
        Raylib.DrawTextPro(font, text, position, Vector2.Zero, rotation, fontSize, kerning, color);
    }

    private static string GetOsDefaultMonospacedFontPath()
    {
        string[] fontFileNames = GetOsDefaultMonospacedFontNames();
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

    private static string[] GetOsDefaultMonospacedFontNames()
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