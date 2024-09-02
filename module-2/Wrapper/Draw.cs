/* 
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 * 
 * Written by:
 *      Raphaël Tétreault
 * History:
 *      2023/01/04: Initial draft
 *      2023/10/10: First complete pass
 *      2024/05/30: Bring over to new template project
 *      2024/08/31: Delete state-less functions, add comments to all functions, add missing functions
 */


using Raylib_cs;
using System.Numerics;

/// <summary>
///     Access drawing functions.
/// </summary>
/// <remarks>
///     A static wrapper to standardize raylib's draw API.
/// </remarks>
public static class Draw
{
    // Development notes
    // CONSIDER: only rounded lines?
    // TODO: draw text (underlying fonts)
    // TODO: draw lines Vector2[]

    // Global state
    public static Color FillColor { get; set; } = Color.Black;
    public static Color LineColor { get; set; } = Color.Blank;
    public static float LineSize { get; set; } = 1f;

    private const float degreesToRadians = 57.2957795131f;

    // DRAW LINE
    /// <summary>
    ///     Draw a line from <paramref name="start"/> to <paramref name="end"/> 
    ///     using <see cref="Draw.LineSize"/> and <see cref="Draw.LineColor"/>.
    /// </summary>
    /// <param name="start">Line start position.</param>
    /// <param name="end">Line end position.</param>
    public static void Line(Vector2 start, Vector2 end)
        => Line(start, end, LineSize, LineColor);
    /// <summary>
    ///     Draw a line from (<paramref name="x0"/>, <paramref name="y0"/>) to
    ///     (<paramref name="x1"/>, <paramref name="y1"/>) using <see cref="Draw.LineSize"/>
    ///     and <see cref="Draw.LineColor"/>.
    /// </summary>
    /// <param name="x0">Line start position X.</param>
    /// <param name="y0">Line start position Y.</param>
    /// <param name="x1">Line end position X.</param>
    /// <param name="y1">Line end position Y.</param>
    public static void Line(float x0, float y0, float x1, float y1)
        => Line(new(x0, y0), new(x1, y1), LineSize, LineColor);
    //
    private static void Line(Vector2 start, Vector2 end, float lineSize, Color lineColor)
    {
        Raylib.DrawLineEx(start, end, lineSize, lineColor);
    }


    // DRAW POLY-LINES
    /// <summary>
    ///     Draw lines between all <paramref name="points"/> using <see cref="Draw.LineSize"/>
    ///     and <see cref="Draw.LineColor"/>
    /// </summary>
    /// <param name="points"></param>
    public static void PolyLine(Vector2[] points)
        => PolyLine(points, LineSize, LineColor);
    //
    private static void PolyLine(Vector2[] points, float lineSize, Color lineColor)
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            Vector2 start = points[i + 0];
            Vector2 end = points[i + 1];
            LineRounded(start, end, lineSize, lineColor);
        }
    }


    // DRAW LINE ROUNDED
    /// <summary>
    ///     Draw a line with rounded ends from <paramref name="start"/> to <paramref name="end"/> 
    ///     using <see cref="Draw.LineSize"/> and <see cref="Draw.LineColor"/>.
    /// </summary>
    /// <param name="start">Line start position.</param>
    /// <param name="end">Line end position.</param>
    public static void LineRounded(Vector2 start, Vector2 end)
        => LineRounded(start, end, LineSize, LineColor);
    /// <summary>
    ///     Draw a line with rounded ends from (<paramref name="x0"/>, <paramref name="y0"/>) to
    ///     (<paramref name="x1"/>, <paramref name="y1"/>) using <see cref="Draw.LineSize"/> and
    ///     <see cref="Draw.LineColor"/>.
    /// </summary>
    /// <param name="x0">Line start position X.</param>
    /// <param name="y0">Line start position Y.</param>
    /// <param name="x1">Line end position X.</param>
    /// <param name="y1">Line end position Y.</param>
    public static void LineRounded(float x0, float y0, float x1, float y1)
        => LineRounded(new(x0, y0), new(x1, y1), LineSize, LineColor);
    //
    private static void LineRounded(Vector2 start, Vector2 end, float lineSize, Color lineColor)
    {
        Raylib.DrawLineEx(start, end, lineSize, lineColor);
        // Draw circles at each point to smooth ends
        float circleRadius = lineSize / 2f;
        Raylib.DrawCircleV(start, circleRadius, lineColor);
        Raylib.DrawCircleV(end, circleRadius, lineColor);
    }


    // DRAW RECTANGLE
    /// <summary>
    ///     Draw a filled and outlined rectangle at <paramref name="position"/> expanding
    ///     right and down to <paramref name="size"/> using <see cref="Draw.LineSize"/> for
    ///     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="position">The rectangle position, defines the upper-left corner.</param>
    /// <param name="size">The size of the rectangle.</param>
    public static void Rectangle(Vector2 position, Vector2 size)
        => Rectangle(position.X, position.Y, size.X, size.Y, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined rectangle at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding right and down to size (<paramref name="w"/>, 
    ///     <paramref name="h"/>) using <see cref="Draw.LineSize"/> for
    ///     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="x">The rectangle's X position, defines the left edge.</param>
    /// <param name="y">The rectangle's Y position, defines the top edge.</param>
    /// <param name="w">The rectangle's width.</param>
    /// <param name="h">The rectangle's height.</param>
    public static void Rectangle(float x, float y, float w, float h)
        => Rectangle(x, y, w, h, FillColor, LineSize, LineColor);
    //
    private static void Rectangle(float x, float y, float w, float h, Color fillColor, float lineSize, Color lineColor)
    {
        Vector2 position = new Vector2(x, y);
        Vector2 size = new Vector2(w, h);
        RectangleFill(position, size, fillColor);
        RectangleOutline(position, size, lineSize, lineColor);
    }
    private static void RectangleFill(Vector2 position, Vector2 size, Color fillColor)
    {
        int ix = (int)Math.Round(position.X, MidpointRounding.ToEven);
        int iy = (int)Math.Round(position.Y, MidpointRounding.ToEven);
        int iw = (int)Math.Round(size.X, MidpointRounding.ToEven);
        int ih = (int)Math.Round(size.Y, MidpointRounding.ToEven);
        Raylib.DrawRectangle(ix, iy, iw, ih, fillColor);
    }
    private static void RectangleOutline(Vector2 position, Vector2 size, float lineSize, Color lineColor)
    {
        int x = (int)Math.Round(position.X, MidpointRounding.ToEven);
        int y = (int)Math.Round(position.Y, MidpointRounding.ToEven);
        int w = (int)Math.Round(size.X, MidpointRounding.ToEven);
        int h = (int)Math.Round(size.Y, MidpointRounding.ToEven);
        Rectangle rectangle = new Rectangle(x, y, w, h);
        Raylib.DrawRectangleLinesEx(rectangle, lineSize, lineColor);
    }


    // DRAW SQUARE
    /// <summary>
    ///     Draw a filled and outlined square at <paramref name="position"/> expanding
    ///     right and down to <paramref name="size"/> using <see cref="Draw.LineSize"/> for
    ///     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the square's fill Color.
    /// </summary>
    /// <param name="position">The square position, defines the upper-left corner.</param>
    /// <param name="size">The square's width and height.</param>
    public static void Square(Vector2 position, float size)
        => Square(position.X, position.Y, size, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined square at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding right and down to size (<paramref name="w"/>, 
    ///     <paramref name="h"/>) using <see cref="Draw.LineSize"/> for
    ///     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the square's fill Color.
    /// </summary>
    /// <param name="x">The square's X position, defines the left edge.</param>
    /// <param name="y">The square's Y position, defines the top edge.</param>
    /// <param name="size">The square's width and height.</param>
    public static void Square(float x, float y, float size)
        => Square(x, y, size, FillColor, LineSize, LineColor);
    //
    private static void Square(float x, float y, float size, Color fillColor, float lineSize, Color lineColor)
        => Rectangle(x, y, size, size, fillColor, lineSize, lineColor);


    //// DRAW RECTANGLE CENTERED
    ///// <summary>
    /////     Draw a filled and outlined rectangle at <paramref name="position"/> expanding
    /////     right and down to <paramref name="size"/> using <see cref="Draw.LineSize"/> for
    /////     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    /////     <see cref="Draw.FillColor"/> for the rectangle's fill Color.
    ///// </summary>
    ///// <param name="position">The rectangle position, defines the centre point.</param>
    ///// <param name="size">The size of the rectangle.</param>
    //public static void RectangleCentered(Vector2 position, Vector2 size)
    //    => RectangleCentered(position.X, position.Y, size.X, size.Y, FillColor, LineSize, LineColor);
    ///// <summary>
    /////     Draw a filled and outlined rectangle at position (<paramref name="x"/>, 
    /////     <paramref name="y"/>) expanding right and down to (<paramref name="w"/>, 
    /////     <paramref name="h"/>) using <see cref="Draw.LineSize"/> for
    /////     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    /////     <see cref="Draw.FillColor"/> for the rectangle's fill Color.
    ///// </summary>
    ///// <param name="x">The rectangle's X position, defines the horizontal centre.</param>
    ///// <param name="y">The rectangle's Y position, defines the vertical centre.</param>
    ///// <param name="w">The rectangle's width.</param>
    ///// <param name="h">The rectangle's height.</param>
    //public static void RectangleCentered(float x, float y, float w, float h)
    //    => RectangleCentered(x, y, w, h, FillColor, LineSize, LineColor);
    ////
    //private static void RectangleCentered(float x, float y, float w, float h, Color fillColor, float lineSize, Color lineColor)
    //{
    //    // Offset x and y by half the width and height, respectively.
    //    float cx = x - w / 2;
    //    float cy = y - h / 2;
    //    Rectangle(cx, cy, w, h, fillColor, lineSize, lineColor);
    //}


    // DRAW ELLIPSE
    /// <summary>
    ///     Draw a filled and outlined ellipse at <paramref name="position"/> expanding
    ///     outward to <paramref name="size"/> using <see cref="Draw.LineSize"/> for
    ///     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the ellipse's fill Color.
    /// </summary>
    /// <param name="position">The ellipse position, defines the centre point.</param>
    /// <param name="size">The size of the ellipse.</param>
    public static void Ellipse(Vector2 position, Vector2 size)
        => Ellipse(position.X, position.Y, size.X, size.Y, LineColor, LineSize, FillColor);
    /// <summary>
    ///     Draw a filled and outlined ellipse at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding outward to size (<paramref name="w"/>, 
    ///     <paramref name="h"/>) using <see cref="Draw.LineSize"/> for the
    ///     outline thickness, <see cref="Draw.LineColor"/> for the line's color,
    ///     and <see cref="Draw.FillColor"/> for the ellipse's fill Color.
    /// </summary>
    /// <param name="x">The ellipse's X position, defines the horizontal centre.</param>
    /// <param name="y">The ellipse's Y position, defines the vertical centre.</param>
    /// <param name="w">The ellipse's width.</param>
    /// <param name="h">The ellipse's height.</param>
    public static void Ellipse(float x, float y, float w, float h)
        => Ellipse(x, y, w, h, LineColor, LineSize, FillColor);
    // 
    private static void Ellipse(float x, float y, float w, float h, Color fillColor, float lineSize, Color lineColor)
    {
        EllipseFill(x, y, w, h, fillColor);
        EllipseOutline(x, y, w, h, lineSize, lineColor);
    }
    private static void EllipseFill(float x, float y, float w, float h, Color fillColor)
    {
        // Do gradeschool math rounding. Ex: 0.499f rounds down to 0, 0.500f rounds up to 1.
        int ix = (int)Math.Round(x, MidpointRounding.ToEven);
        int iy = (int)Math.Round(y, MidpointRounding.ToEven);
        float halfWidth = w / 2f;
        float halfHeight = h / 2f;
        Raylib.DrawEllipse(ix, iy, halfWidth, halfHeight, fillColor);
    }
    private static void EllipseOutline(float x, float y, float w, float h, float lineSize, Color lineColor)
    {
        int ix = (int)Math.Round(x, MidpointRounding.ToEven);
        int iy = (int)Math.Round(y, MidpointRounding.ToEven);
        float halfWidth = w / 2f;
        float halfHeight = h / 2f;
        // Draw border/outline
        // Hacky, eh?
        // Draw ellipse lines from all possible edges of rectangle to approximate outline.
        for (int i = 0; i < lineSize; i++)
        {
            for (int j = 0; j < lineSize; j++)
            {
                float borderWidth = halfWidth - i;
                float borderHeight = halfHeight - j;
                Raylib.DrawEllipseLines(ix, iy, borderWidth, borderHeight, lineColor);
            }
        }
    }


    // DRAW CIRCLE
    /// <summary>
    ///     Draw a filled and outlined circle at <paramref name="position"/> expanding
    ///     outward to <paramref name="radius"/> using <see cref="Draw.LineSize"/> for
    ///     the outline thickness, <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the circle's fill color.
    /// </summary>
    /// <param name="position">The circle position, defines the centre point.</param>
    /// <param name="radius">The circle radius.</param>
    public static void Circle(Vector2 position, float radius)
        => Circle(position, radius, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined circle at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding outward to <paramref name="radius"/>
    ///     using <see cref="Draw.LineSize"/> for the outline thickness,
    ///     <see cref="Draw.LineColor"/> for the line's color, and
    ///     <see cref="Draw.FillColor"/> for the circle's fill color.
    /// </summary>
    /// <param name="x">The circle's X position, defines the horizontal centre.</param>
    /// <param name="y">The circle's Y position, defines the vertical centre.</param>
    /// <param name="radius">The circle radius.</param>
    public static void Circle(float x, float y, float radius)
        => Circle(new Vector2(x, y), radius, FillColor, LineSize, LineColor);
    //
    private static void Circle(Vector2 position, float radius, Color fillColor, float lineSize, Color lineColor)
    {
        CircleFill(position, radius, fillColor);
        CircleOutline(position, radius, lineSize, lineColor);
    }
    private static void CircleFill(Vector2 position, float radius, Color fillColor)
    {
        Raylib.DrawCircleV(position, radius, fillColor);
    }
    private static void CircleOutline(Vector2 position, float radius, float lineSize, Color lineColor)
    {
        float innerRadius = radius - lineSize;
        float outerRadius = radius;
        int segments = (int)(radius * 4);
        Raylib.DrawRing(position, innerRadius, outerRadius, 0, 360, segments, lineColor);
    }


    // TRIANGLE
    /// <summary>
    /// 
    /// </summary>
    /// <param name="position"></param>
    /// <param name="sideLength"></param>
    /// <param name="angleDegrees"></param>
    public static void Triangle(Vector2 position, float sideLength, float angleDegrees = 0)
        => Triangle(position, sideLength, angleDegrees, LineColor, LineSize, LineColor);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="sideLength"></param>
    /// <param name="angleDegrees"></param>
    public static void Triangle(float x, float y, float sideLength, float angleDegrees = 0)
        => Triangle(new Vector2(x, y), sideLength, angleDegrees, LineColor, LineSize, LineColor);
    //
    private static void Triangle(Vector2 position, float sideLength, float angleDegrees, Color fillColor, float lineSize, Color lineColor)
    {
        TriangleFill(position, sideLength, angleDegrees, fillColor);
        TriangleOutline(position, sideLength, angleDegrees, lineSize, lineColor);
    }
    private static void TriangleFill(Vector2 position, float sideLength, float angleDegrees, Color fillColor)
    {
        float angleRadiansV1 = (angleDegrees + 0) / degreesToRadians;
        float angleRadiansV2 = (angleDegrees + 60) / degreesToRadians;
        Vector2 v0 = position;
        Vector2 v1 = position + new Vector2(MathF.Cos(angleRadiansV1), -MathF.Sin(angleRadiansV1)) * sideLength;
        Vector2 v2 = position + new Vector2(MathF.Cos(angleRadiansV2), -MathF.Sin(angleRadiansV2)) * sideLength;
        Raylib.DrawTriangle(v0, v1, v2, fillColor);
    }
    private static void TriangleOutline(Vector2 position, float sideLength, float angleDegrees, float lineSize, Color lineColor)
    {
        float angleRadiansV1 = (angleDegrees + 0) / degreesToRadians;
        float angleRadiansV2 = (angleDegrees + 60) / degreesToRadians;
        Vector2 v0 = position;
        Vector2 v1 = position + new Vector2(MathF.Cos(angleRadiansV1), -MathF.Sin(angleRadiansV1)) * sideLength;
        Vector2 v2 = position + new Vector2(MathF.Cos(angleRadiansV2), -MathF.Sin(angleRadiansV2)) * sideLength;
        PolyLine([ v0, v1, v2, v0 ], lineSize, lineColor);
    }

}
