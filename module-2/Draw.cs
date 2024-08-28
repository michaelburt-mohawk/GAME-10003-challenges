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
 */


using Raylib_cs;
using System;
using System.Numerics;
using System.Threading;

/// <summary>
///     A static wrapper to standardize raylib's draw API.
/// </summary>
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


    // DRAW LINE

    /// <summary>
    ///     Draw a line from <paramref name="start"/> to <paramref name="end"/> 
    ///     using <see cref="LineSize"/> and <see cref="LineColor"/>.
    /// </summary>
    /// <param name="start">Line start position.</param>
    /// <param name="end">Line end position.</param>
    public static void Line(Vector2 start, Vector2 end)
        => Line(start, end, LineSize, LineColor);
    /// <summary>
    ///     Draw a line from (<paramref name="x0"/>, <paramref name="y0"/>) to
    ///     (<paramref name="x1"/>, <paramref name="y1"/>) using <see cref="LineSize"/>
    ///     and <see cref="LineColor"/>.
    /// </summary>
    /// <param name="x0">Line start position X.</param>
    /// <param name="y0">Line start position Y.</param>
    /// <param name="x1">Line end position X.</param>
    /// <param name="y1">Line end position Y.</param>
    public static void Line(float x0, float y0, float x1, float y1)
        => Line(x0, y0, x1, y1, LineSize, LineColor);
    /// <summary>
    ///     Draw a line from <paramref name="start"/> to <paramref name="end"/> 
    ///     using <paramref name="lineThickness"/> and <paramref name="lineColor"/>.
    /// </summary>
    /// <param name="start">Line start position.</param>
    /// <param name="end">Line end position.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void Line(Vector2 start, Vector2 end, float lineThickness, Color lineColor)
    {
        Raylib.DrawLineEx(start, end, lineThickness, lineColor);
    }
    /// <summary>
    ///     Draw a line from (<paramref name="x0"/>, <paramref name="y0"/>) to
    ///     (<paramref name="x1"/>, <paramref name="y1"/>) using <paramref name="lineThickness"/>
    ///     and <paramref name="lineColor"/>.
    /// </summary>
    /// <param name="x0">Line start position X.</param>
    /// <param name="y0">Line start position Y.</param>
    /// <param name="x1">Line end position X.</param>
    /// <param name="y1">Line end position Y.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void Line(float x0, float y0, float x1, float y1, float lineThickness, Color lineColor)
    {
        Vector2 point0 = new Vector2(x0, y0);
        Vector2 point1 = new Vector2(x1, y1);
        Raylib.DrawLineEx(point0, point1, lineThickness, lineColor);
    }

    /// <summary>
    ///     Draw a line with rounded ends from <paramref name="start"/> to <paramref name="end"/> 
    ///     using <see cref="LineSize"/> and <see cref="LineColor"/>.
    /// </summary>
    /// <param name="start">Line start position.</param>
    /// <param name="end">Line end position.</param>
    public static void RoundedLine(Vector2 start, Vector2 end)
        => RoundedLine(start, end, LineSize, LineColor);
    /// <summary>
    ///     Draw a line with rounded ends from (<paramref name="x0"/>, <paramref name="y0"/>) to
    ///     (<paramref name="x1"/>, <paramref name="y1"/>) using <see cref="LineSize"/> and
    ///     <see cref="LineColor"/>.
    /// </summary>
    /// <param name="x0">Line start position X.</param>
    /// <param name="y0">Line start position Y.</param>
    /// <param name="x1">Line end position X.</param>
    /// <param name="y1">Line end position Y.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void RoundedLine(float x0, float y0, float x1, float y1)
        => RoundedLine(x0, y0, x1, y1, LineSize, LineColor);
    /// <summary>
    ///     Draw a line with rounded ends from <paramref name="start"/> to <paramref name="end"/> 
    ///     using <paramref name="lineThickness"/> and <paramref name="lineColor"/>.
    /// </summary>
    /// <param name="start">Line start position.</param>
    /// <param name="end">Line end position.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void RoundedLine(Vector2 start, Vector2 end, float lineThickness, Color lineColor)
    {
        Raylib.DrawLineEx(start, end, lineThickness, lineColor);
        // Draw circles at each point to smooth ends
        float circleRadius = lineThickness / 2f;
        Raylib.DrawCircleV(start, circleRadius, lineColor);
        Raylib.DrawCircleV(end, circleRadius, lineColor);
    }
    /// <summary>
    ///     Draw a line with rounded ends from (<paramref name="x0"/>, <paramref name="y0"/>) to
    ///     (<paramref name="x1"/>, <paramref name="y1"/>) using <paramref name="lineThickness"/>
    ///     and <paramref name="lineColor"/>.
    /// </summary>
    /// <param name="x0">Line start position X.</param>
    /// <param name="y0">Line start position Y.</param>
    /// <param name="x1">Line end position X.</param>
    /// <param name="y1">Line end position Y.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void RoundedLine(float x0, float y0, float x1, float y1, float lineThickness, Color lineColor)
    {
        Vector2 point0 = new Vector2(x0, y0);
        Vector2 point1 = new Vector2(x1, y1);
        RoundedLine(point0, point1, lineThickness, lineColor);
    }


    // DRAW RECTANGLE

    /// <summary>
    ///     Draw a filled rectangle at <paramref name="position"/> expanding right and down
    ///     to <paramref name="size"/> using <see cref="FillColor"/>.
    /// </summary>
    /// <param name="position">The rectangle position, defines the upper-left corner.</param>
    /// <param name="size">The size of the rectangle.</param>
    public static void Rectangle(Vector2 position, Vector2 size)
        => Rectangle(position, size, FillColor);
    /// <summary>
    ///     Draw a filled rectangle at position (<paramref name="x"/>, <paramref name="y"/>)
    ///     expanding right and down to size (<paramref name="w"/>, <paramref name="h"/>)
    ///     using <see cref="FillColor"/>.
    /// </summary>
    /// <param name="x">The rectangle's X position, defines the left edge.</param>
    /// <param name="y">The rectangle's Y position, defines the top edge.</param>
    /// <param name="w">The rectangle's width.</param>
    /// <param name="h">The rectangle's height.</param>
    public static void Rectangle(float x, float y, float w, float h)
        => Rectangle(x, y, w, h, FillColor);
    /// <summary>
    ///     Draw a filled rectangle at <paramref name="position"/> expanding right and down
    ///     to <paramref name="size"/> using <paramref name="fillColor"/>.
    /// </summary>
    /// <param name="position">The rectangle position, defines the upper-left corner.</param>
    /// <param name="size">The size of the rectangle.</param>
    /// <param name="fillColor">Colour of the rectangle.</param>
    public static void Rectangle(Vector2 position, Vector2 size, Color fillColor)
    {
        int ix = (int)Math.Round(position.X, MidpointRounding.ToEven);
        int iy = (int)Math.Round(position.Y, MidpointRounding.ToEven);
        int iw = (int)Math.Round(size.X, MidpointRounding.ToEven);
        int ih = (int)Math.Round(size.Y, MidpointRounding.ToEven);
        Raylib.DrawRectangle(ix, iy, iw, ih, fillColor);
    }
    /// <summary>
    ///     Draw a filled rectangle at position (<paramref name="x"/>, <paramref name="y"/>)
    ///     expanding right and down to size (<paramref name="w"/>, <paramref name="h"/>)
    ///     using <paramref name="fillColor"/>.
    /// </summary>
    /// <param name="x">The rectangle's X position, defines the left edge.</param>
    /// <param name="y">The rectangle's Y position, defines the top edge.</param>
    /// <param name="w">The rectangle's width.</param>
    /// <param name="h">The rectangle's height.</param>
    /// <param name="fillColor">Colour of the rectangle.</param>
    public static void Rectangle(float x, float y, float w, float h, Color fillColor)
    {
        Vector2 position = new Vector2(x, y);
        Vector2 size = new Vector2(w, h);
        Rectangle(position, size, fillColor);
    }

    /// <summary>
    ///     Draw a rectangle outline at <paramref name="position"/> expanding right and down to
    ///     <paramref name="size"/> using <see cref="LineSize"/> and <see cref="LineColor"/>.
    /// </summary>
    /// <param name="position">The rectangle position, defines the upper-left corner.</param>
    /// <param name="size">The size of the rectangle.</param>
    public static void RectangleOutline(Vector2 position, Vector2 size)
        => RectangleOutline(position, size, LineSize, LineColor);
    /// <summary>
    ///     Draw a rectangle outline at position (<paramref name="x"/>, <paramref name="y"/>)
    ///     expanding right and down to size (<paramref name="w"/>, <paramref name="h"/>)
    ///     using using <see cref="LineSize"/> and <see cref="LineColor"/>.
    /// </summary>
    /// <param name="x">The rectangle's X position, defines the left edge.</param>
    /// <param name="y">The rectangle's Y position, defines the top edge.</param>
    /// <param name="w">The rectangle's width.</param>
    /// <param name="h">The rectangle's height.</param>
    public static void RectangleOutline(float x, float y, float w, float h)
        => RectangleOutline(x, y, w, h, LineSize, LineColor);
    /// <summary>
    ///     Draw a rectangle outline at <paramref name="position"/> expanding right and down to
    ///     <paramref name="size"/> using <paramref name="lineThickness"/> and <paramref name="lineColor"/>.
    /// </summary>
    /// <param name="position">The rectangle position, defines the upper-left corner.</param>
    /// <param name="size">The size of the rectangle.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void RectangleOutline(Vector2 position, Vector2 size, float lineThickness, Color lineColor)
    {
        int x = (int)Math.Round(position.X, MidpointRounding.ToEven);
        int y = (int)Math.Round(position.Y, MidpointRounding.ToEven);
        int w = (int)Math.Round(size.X, MidpointRounding.ToEven);
        int h = (int)Math.Round(size.Y, MidpointRounding.ToEven);
        Rectangle rectangle = new Rectangle(x, y, w, h);
        Raylib.DrawRectangleLinesEx(rectangle, lineThickness, lineColor);
    }
    /// <summary>
    ///     Draw a rectangle outline at position (<paramref name="x"/>, <paramref name="y"/>)
    ///     expanding right and down to size (<paramref name="w"/>, <paramref name="h"/>)
    ///     using <paramref name="lineThickness"/> and <paramref name="lineColor"/>.
    /// </summary>
    /// <param name="x">The rectangle's X position, defines the left edge.</param>
    /// <param name="y">The rectangle's Y position, defines the top edge.</param>
    /// <param name="w">The rectangle's width.</param>
    /// <param name="h">The rectangle's height.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void RectangleOutline(float x, float y, float w, float h, float lineThickness, Color lineColor)
    {
        RectangleOutline(x, y, w, h, lineThickness, lineColor);
    }

    /// <summary>
    ///     Draw a filled and outlined rectangle at <paramref name="position"/> expanding
    ///     right and down to <paramref name="size"/> using <see cref="LineSize"/> for
    ///     the outline thickness, <see cref="LineColor"/> for the line's Color, and
    ///     <see cref="FillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="position">The rectangle position, defines the upper-left corner.</param>
    /// <param name="size">The size of the rectangle.</param>
    public static void RectangleBordered(Vector2 position, Vector2 size)
        => RectangleBordered(position, size, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined rectangle at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding right and down to size (<paramref name="w"/>, 
    ///     <paramref name="h"/>) using <see cref="LineSize"/> for
    ///     the outline thickness, <see cref="LineColor"/> for the line's Color, and
    ///     <see cref="FillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="x">The rectangle's X position, defines the left edge.</param>
    /// <param name="y">The rectangle's Y position, defines the top edge.</param>
    /// <param name="w">The rectangle's width.</param>
    /// <param name="h">The rectangle's height.</param>
    public static void RectangleBordered(float x, float y, float w, float h)
        => RectangleBordered(x, y, w, h, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined rectangle at <paramref name="position"/> expanding
    ///     right and down to <paramref name="size"/> using <paramref name="lineThickness"/> for
    ///     the outline thickness, <paramref name="lineColor"/> for the line's Color, and
    ///     <paramref name="fillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="position">The rectangle position, defines the upper-left corner.</param>
    /// <param name="size">The size of the rectangle.</param>
    /// <param name="fillColor">Colour of the rectangle fill.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void RectangleBordered(Vector2 position, Vector2 size, Color fillColor, float lineThickness, Color lineColor)
    {
        //int left = (int)Math.Round(position.X, MidpointRounding.ToEven);
        //int top = (int)Math.Round(position.Y, MidpointRounding.ToEven);
        //Vector2 roundedPosition = new Vector2(left, top);

        // Draw rectangle inner fill area
        Rectangle(position, size, fillColor);
        RectangleOutline(position, size, lineThickness, lineColor);
    }
    /// <summary>
    ///     Draw a filled and outlined rectangle at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding right and down to size (<paramref name="w"/>, 
    ///     <paramref name="h"/>) using <paramref name="lineThickness"/> for the
    ///     outline thickness, <paramref name="lineColor"/> for the line's Color,
    ///     and <paramref name="fillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="x">The rectangle's X position, defines the left edge.</param>
    /// <param name="y">The rectangle's Y position, defines the top edge.</param>
    /// <param name="w">The rectangle's width.</param>
    /// <param name="h">The rectangle's height.</param>
    /// <param name="fillColor">Colour of the rectangle fill.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void RectangleBordered(float x, float y, float w, float h, Color fillColor, float lineThickness, Color lineColor)
    {
        Vector2 position = new Vector2(x, y);
        Vector2 size = new Vector2(w, h);
        RectangleBordered(position, size, fillColor, lineThickness, lineColor);
    }

    /// <summary>
    ///     Draw a filled and outlined rectangle at <paramref name="position"/> expanding
    ///     right and down to <paramref name="size"/> using <see cref="LineSize"/> for
    ///     the outline thickness, <see cref="LineColor"/> for the line's Color, and
    ///     <see cref="FillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="position">The rectangle position, defines the centre point.</param>
    /// <param name="size">The size of the rectangle.</param>
    public static void BorderedRectangleCentered(Vector2 position, Vector2 size)
        => BorderedRectangleCentered(position, size, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined rectangle at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding right and down to (<paramref name="w"/>, 
    ///     <paramref name="h"/>) using <see cref="LineSize"/> for
    ///     the outline thickness, <see cref="LineColor"/> for the line's Color, and
    ///     <see cref="FillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="x">The rectangle's X position, defines the horizontal centre.</param>
    /// <param name="y">The rectangle's Y position, defines the vertical centre.</param>
    /// <param name="w">The rectangle's width.</param>
    /// <param name="h">The rectangle's height.</param>
    public static void BorderedRectangleCentered(float x, float y, float w, float h)
        => BorderedRectangleCentered(x, y, w, h, FillColor, LineSize, LineColor);
    /// <summary>
    ///     Draw a filled and outlined rectangle at <paramref name="position"/> expanding
    ///     right and down to <paramref name="size"/> using <paramref name="lineThickness"/> for
    ///     the outline thickness, <paramref name="lineColor"/> for the line's Color, and
    ///     <paramref name="fillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="position">The rectangle position, defines the centre point.</param>
    /// <param name="size">The size of the rectangle.</param>
    /// <param name="fillColor">Colour of the rectangle fill.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void BorderedRectangleCentered(Vector2 position, Vector2 size, Color fillColor, float lineThickness, Color lineColor)
    {
        BorderedRectangleCentered(position.X, position.Y, size.X, size.Y, fillColor, lineThickness, lineColor);
    }
    /// <summary>
    ///     Draw a filled and outlined rectangle at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding right and down to (<paramref name="w"/>, 
    ///     <paramref name="h"/>) using <paramref name="lineThickness"/> for the
    ///     outline thickness, <paramref name="lineColor"/> for the line's Color,
    ///     and <paramref name="fillColor"/> for the rectangle's fill Color.
    /// </summary>
    /// <param name="x">The rectangle's X position, defines the horizontal centre.</param>
    /// <param name="y">The rectangle's Y position, defines the vertical centre.</param>
    /// <param name="w">The rectangle's width.</param>
    /// <param name="h">The rectangle's height.</param>
    /// <param name="fillColor">Colour of the rectangle fill.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void BorderedRectangleCentered(float x, float y, float w, float h, Color fillColor, float lineThickness, Color lineColor)
    {
        // Offset x and y by half the width and height, respectively.
        float cx = x - w / 2;
        float cy = y - h / 2;
        RectangleBordered(cx, cy, w, h, fillColor, lineThickness, lineColor);
    }


    // DRAW ELLIPSE
    //TODO: use default state

    /// <summary>
    ///     Draw a filled ellipse at <paramref name="position"/> expanding outward to
    ///     <paramref name="size"/> using <paramref name="fillColor"/>.
    /// </summary>
    /// <param name="position">The ellipse's position, defines the centre point.</param>
    /// <param name="size">The size of the ellipse.</param>
    /// <param name="fillColor">Colour of the ellipse.</param>
    public static void Ellipse(Vector2 position, Vector2 size, Color fillColor)
    {
        Ellipse(position.X, position.Y, size.X, size.Y, fillColor);
    }
    /// <summary>
    ///     Draw a filled ellipse at position (<paramref name="x"/>, <paramref name="y"/>)
    ///     expanding outward to size (<paramref name="w"/>, <paramref name="h"/>)
    ///     using <paramref name="fillColor"/>.
    /// </summary>
    /// <param name="x">The ellipse's X position, defines the horizontal centre.</param>
    /// <param name="y">The ellipse's Y position, defines the vertical centre.</param>
    /// <param name="w">The ellipse's width.</param>
    /// <param name="h">The ellipse's height.</param>
    /// <param name="fillColor">Colour of the ellipse.</param>
    public static void Ellipse(float x, float y, float w, float h, Color fillColor)
    {
        // Do gradeschool math rounding. Ex: 0.499f rounds down to 0, 0.500f rounds up to 1.
        int ix = (int)Math.Round(x, MidpointRounding.ToEven);
        int iy = (int)Math.Round(y, MidpointRounding.ToEven);
        float halfWidth = w / 2f;
        float halfHeight = h / 2f;
        Raylib.DrawEllipse(ix, iy, halfWidth, halfHeight, fillColor);
    }

    /// <summary>
    ///     Draw an ellipse outline at <paramref name="position"/> expanding outward to
    ///     <paramref name="size"/> using <paramref name="lineThickness"/> and <paramref name="lineColor"/>.
    /// </summary>
    /// <param name="position">The ellipse's position, defines the centre point.</param>
    /// <param name="size">The size of the ellipse.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void EllipseOutline(Vector2 position, Vector2 size, float lineThickness, Color lineColor)
    {
        EllipseOutline(position.X, position.Y, size.X, size.Y, lineThickness, lineColor);
    }
    /// <summary>
    ///     Draw an ellipse outline at position (<paramref name="x"/>, <paramref name="y"/>)
    ///     expanding outward to size (<paramref name="w"/>, <paramref name="h"/>)
    ///     using <paramref name="lineThickness"/> and <paramref name="lineColor"/>.
    /// </summary>
    /// <param name="x">The ellipse's X position, defines the horizontal centre.</param>
    /// <param name="y">The ellipse's Y position, defines the vertical centre.</param>
    /// <param name="w">The ellipse's width.</param>
    /// <param name="h">The ellipse's height.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void EllipseOutline(float x, float y, float w, float h, float lineThickness, Color lineColor)
    {
        int ix = (int)Math.Round(x, MidpointRounding.ToEven);
        int iy = (int)Math.Round(y, MidpointRounding.ToEven);
        float halfWidth = w / 2f;
        float halfHeight = h / 2f;
        // Draw border/outline
        // Hacky, eh?
        // Draw ellipse lines from all possible edges of rectangle to approximate outline.
        for (int i = 0; i < lineThickness; i++)
        {
            for (int j = 0; j < lineThickness; j++)
            {
                float borderWidth = halfWidth - i;
                float borderHeight = halfHeight - j;
                Raylib.DrawEllipseLines(ix, iy, borderWidth, borderHeight, lineColor);
            }
        }
    }

    /// <summary>
    ///     Draw a filled and outlined ellipse at <paramref name="position"/> expanding
    ///     outward to <paramref name="size"/> using <paramref name="lineThickness"/> for
    ///     the outline thickness, <paramref name="lineColor"/> for the line's Color, and
    ///     <paramref name="fillColor"/> for the ellipse's fill Color.
    /// </summary>
    /// <param name="position">The ellipse position, defines the centre point.</param>
    /// <param name="size">The size of the ellipse.</param>
    /// <param name="fillColor">Colour of the ellipse fill.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void EllipseBordered(Vector2 position, Vector2 size, Color fillColor, float lineThickness, Color lineColor)
    {
        EllipseBordered(position.X, position.Y, size.X, size.Y, fillColor, lineThickness, lineColor);
    }
    /// <summary>
    ///     Draw a filled and outlined ellipse at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding outward to size (<paramref name="w"/>, 
    ///     <paramref name="h"/>) using <paramref name="lineThickness"/> for the
    ///     outline thickness, <paramref name="lineColor"/> for the line's Color,
    ///     and <paramref name="fillColor"/> for the ellipse's fill Color.
    /// </summary>
    /// <param name="x">The ellipse's X position, defines the horizontal centre.</param>
    /// <param name="y">The ellipse's Y position, defines the vertical centre.</param>
    /// <param name="w">The ellipse's width.</param>
    /// <param name="h">The ellipse's height.</param>
    /// <param name="fillColor">Colour of the ellipse fill.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void EllipseBordered(float x, float y, float w, float h, Color fillColor, float lineThickness, Color lineColor)
    {
        Ellipse(x, y, w, h, fillColor);
        EllipseOutline(x, y, w, h, lineThickness, lineColor);
    }


    // DRAW CIRCLE
    // TODO: use default state

    /// <summary>
    ///     Draw a filled circle at <paramref name="position"/> expanding outward to
    ///     <paramref name="radius"/> using <paramref name="fillColor"/>.
    /// </summary>
    /// <param name="position">The circle position, defines the upper-left corner.</param>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="fillColor">Colour of the circle.</param>
    public static void Circle(Vector2 position, float radius, Color fillColor)
    {
        Raylib.DrawCircleV(position, radius, fillColor);
    }
    /// <summary>
    ///     Draw a filled circle at position (<paramref name="x"/>, <paramref name="y"/>)
    ///     expanding outward to size (<paramref name="w"/>, <paramref name="h"/>)
    ///     using <paramref name="fillColor"/>.
    /// </summary>
    /// <param name="x">The circle's X position, defines the horizontal centre.</param>
    /// <param name="y">The circle's Y position, defines the vertical centre.</param>
    /// <param name="radius">The circle radius.</param>
    /// <param name="fillColor">The circle Color.</param>
    public static void Circle(float x, float y, float radius, Color fillColor)
    {
        Vector2 position = new Vector2(x, y);
        Circle(position, radius, fillColor);
    }

    /// <summary>
    ///     Draw an circle outline at <paramref name="position"/> expanding outward to
    ///     <paramref name="radius"/> using <paramref name="lineThickness"/> and
    ///     <paramref name="lineColor"/>.
    /// </summary>
    /// <param name="position">The circle's position, defines the centre point.</param>
    /// <param name="radius">The circle radius.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void CircleOutline(Vector2 position, float radius, float lineThickness, Color lineColor)
    {
        float innerRadius = radius - lineThickness;
        float outerRadius = radius;
        int segments = (int)(radius * 4);
        Raylib.DrawRing(position, innerRadius, outerRadius, 0, 360, segments, lineColor);
    }
    /// <summary>
    ///     Draw a circle outline at position (<paramref name="x"/>, <paramref name="y"/>)
    ///     expanding outward to <paramref name="radius"/> using <paramref name="lineThickness"/>
    ///     and <paramref name="lineColor"/>.
    /// </summary>
    /// <param name="x">The circle's X position, defines the horizontal centre.</param>
    /// <param name="y">The circle's Y position, defines the vertical centre.</param>
    /// <param name="radius">The circle radius.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void CircleOutline(float x, float y, float radius, float lineThickness, Color lineColor)
    {
        Vector2 position = new Vector2(x, y);
        CircleOutline(position, radius, lineThickness, lineColor);
    }

    /// <summary>
    ///     Draw a filled and outlined circle at <paramref name="position"/> expanding
    ///     outward to <paramref name="radius"/> using <paramref name="lineThickness"/> for
    ///     the outline thickness, <paramref name="lineColor"/> for the line's Color, and
    ///     <paramref name="fillColor"/> for the circle's fill Color.
    /// </summary>
    /// <param name="position">The circle position, defines the centre point.</param>
    /// <param name="radius">The circle radius.</param>
    /// <param name="fillColor">Colour of the circle fill.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void CircleBordered(Vector2 position, float radius, Color fillColor, float lineThickness, Color lineColor)
    {
        Circle(position, radius, fillColor);
        CircleOutline(position, radius, lineThickness, lineColor);
    }
    /// <summary>
    ///     Draw a filled and outlined circle at position (<paramref name="x"/>, 
    ///     <paramref name="y"/>) expanding outward to <paramref name="radius"/>
    ///     using <paramref name="lineThickness"/> for the outline thickness,
    ///     <paramref name="lineColor"/> for the line's Color, and
    ///     <paramref name="fillColor"/> for the circle's fill Color.
    /// </summary>
    /// <param name="x">The circle's X position, defines the horizontal centre.</param>
    /// <param name="y">The circle's Y position, defines the vertical centre.</param>
    /// <param name="radius">The circle radius.</param>
    /// <param name="fillColor">Colour of the circle fill.</param>
    /// <param name="lineThickness">How thick the line is.</param>
    /// <param name="lineColor">Colour of the line.</param>
    public static void CircleBordered(float x, float y, float radius, Color fillColor, float lineThickness, Color lineColor)
    {
        Vector2 position = new Vector2(x, y);
        CircleBordered(position, radius, fillColor, lineThickness, lineColor);
    }

}
