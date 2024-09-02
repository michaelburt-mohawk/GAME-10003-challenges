// TODO: C#13 Alias Raylib.Font => Font
public readonly record struct Font
{
    public Raylib_cs.Font RaylibData { get; init; }

    public static implicit operator Font(Raylib_cs.Font raylibFont)
    {
        var font = new Font()
        {
            RaylibData = raylibFont,
        };
        return font;
    }
}