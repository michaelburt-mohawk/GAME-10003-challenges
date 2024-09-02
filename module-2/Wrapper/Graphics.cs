using Raylib_cs;
using System.Numerics;

/// <summary>
///     Access graphics-related functions.
/// </summary>
public static class Graphics
{
    // TODO: wrap Texture2D like Font

    public static float Rotation { get; set; } = 0;
    public static float Scale { get; set; } = 1;
    public static Color Tint { get; set; } = Color.White;

    /// <summary>
    ///     Loads texture at <paramref name="filePath"/> into GPU memory.
    /// </summary>
    /// <remarks>
    ///     This is slow and reads from disk. Reuse the resulting <see cref="Texture2D"/> 
    ///     where possible rather than laoding again from disk.
    /// </remarks>
    /// <param name="filePath">The texture file path.</param>
    /// <returns>
    ///     Returns the loaded texture.
    /// </returns>
    public static Texture2D LoadTexture(string filePath)
    {
        var texture = Raylib.LoadTexture(filePath);
        return texture;
    }

    /// <summary>
    ///     Unloads <paramref name="texture"/> from GPU memory.
    /// </summary>
    /// <param name="texture">The texture to unload from GPU memory.</param>
    public static void UnoadTexture(Texture2D texture)
    {
        Raylib.UnloadTexture(texture);
    }

    public static void Draw(Texture2D texture, Vector2 position)
    {
        Raylib.DrawTextureEx(texture, position, Rotation, Scale, Tint);
    }

    public static void Draw(Texture2D texture, float x, float y)
        => Draw(texture, new Vector2(x, y));

    public static void DrawSubset(Texture2D texture, Vector2 position, Vector2 subsetOrigin, Vector2 subsetSize, Vector2 rotationOrigin)
    {
        // Source in texture/spritesheet/atlas
        var source = new Rectangle()
        {
            Position = subsetOrigin,
            Size = subsetSize,
        };
        // destination on screen
        var destination = new Rectangle()
        {
            Position = position,
            Size = subsetSize * Scale,
        };
        Raylib.DrawTexturePro(texture, source, destination, -rotationOrigin, Rotation, Tint);
    }

    // w/o rotation origin
    public static void DrawSubset(Texture2D texture, Vector2 position, Vector2 subsetOrigin, Vector2 subsetSize)
        => DrawSubset(texture, position, subsetOrigin, subsetSize, Vector2.Zero);
}