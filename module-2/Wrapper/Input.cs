using Raylib_cs;
using System.Numerics;

/// <summary>
///     Access player input functions.
/// </summary>
/// <remarks>
///     A static wrapper to standardize raylib's gamepad API.
/// </remarks>
public static class Input
{
    // Keyboard
    public static bool IsKeyboardKeyPressed(KeyboardKey key) => Raylib.IsKeyPressed((Raylib_cs.KeyboardKey)key);
    public static bool IsKeyboardKeyReleased(KeyboardKey key) =>  Raylib.IsKeyReleased((Raylib_cs.KeyboardKey)key);
    public static bool IsKeyboardKeyUp(KeyboardKey key) =>  Raylib.IsKeyUp((Raylib_cs.KeyboardKey)key);
    public static bool IsKeyboardKeyDown(KeyboardKey key) => Raylib.IsKeyDown((Raylib_cs.KeyboardKey)key);

    // Mouse
    public static bool IsMouseButtonPressed(MouseButton button) => Raylib.IsMouseButtonPressed((Raylib_cs.MouseButton)button);
    public static bool IsMouseButtonReleased(MouseButton button) => Raylib.IsMouseButtonReleased((Raylib_cs.MouseButton)button);
    public static bool IsMouseButtonUp(MouseButton button) => Raylib.IsMouseButtonUp((Raylib_cs.MouseButton)button);
    public static bool IsMouseButtonDown(MouseButton button) => Raylib.IsMouseButtonDown((Raylib_cs.MouseButton)button);
    public static Vector2 GetMouseDeltaPosition() => Raylib.GetMouseDelta();
    public static Vector2 GetMousePosition() => Raylib.GetMousePosition();
    public static float GetMouseX() => Raylib.GetMouseX();
    public static float GetMouseY() => Raylib.GetMouseY();
    public static Vector2 GetMouseWheel() => Raylib.GetMouseWheelMoveV();
    public static float GetMouseWheelX() => Raylib.GetMouseWheelMoveV().X;
    public static float GetMouseWheelY() => Raylib.GetMouseWheelMoveV().Y;

    // Mouse Cursor
    public static void DisableMouseCursor() => Raylib.DisableCursor();
    public static void EnableMouseCursor() => Raylib.EnableCursor();
    public static void ShowMouseCursor() => Raylib.ShowCursor();
    public static void HideMouseCursor() => Raylib.HideCursor();
    public static void IsMouseCursorHidden() => Raylib.IsCursorHidden();
    public static void IsMouseCursorOnScreen() => Raylib.IsCursorOnScreen();

    // Controller Button
    public static bool IsControllerButtonPressed(int controllerIndex, ControllerButton controllerButton)
        => Raylib.IsGamepadButtonPressed(controllerIndex, (GamepadButton)controllerButton);
    public static bool IsControllerButtonReleased(int controllerIndex, ControllerButton controllerButton)
        => Raylib.IsGamepadButtonReleased(controllerIndex, (GamepadButton)controllerButton);
    public static bool IsControllerButtonUp(int controllerIndex, ControllerButton controllerButton)
        => Raylib.IsGamepadButtonUp(controllerIndex, (GamepadButton)controllerButton);
    public static bool IsControllerButtonDown(int controllerIndex, ControllerButton controllerButton)
        => Raylib.IsGamepadButtonDown(controllerIndex, (GamepadButton)controllerButton);


    private delegate CBool RaylibGamepadButtonFunc(int controllerIndex, GamepadButton controllerButton);
    private static bool IsAnyControllerButtonXXX(ControllerButton controllerButton, RaylibGamepadButtonFunc gamepadFunc)
    {
        int controllerCount = ConnectedControllerCount();
        for (int i = 0; i < controllerCount; i++)
        {
            GamepadButton button = (GamepadButton)controllerButton;
            bool isTriggered = gamepadFunc(i, button);
            if (isTriggered)
                return true;
        }
        return false;
    }
    public static bool IsAnyControllerButtonPressed(ControllerButton controllerButton)
        => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonPressed);
    public static bool IsAnyControllerButtonReleased(ControllerButton controllerButton)
        => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonReleased);
    public static bool IsAnyControllerButtonUp(ControllerButton controllerButton)
        => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonUp);
    public static bool IsAnyControllerButtonDown(ControllerButton controllerButton)
        => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonDown);


    // Controller Axis
    public static float GetControllerAxis(int controllerIndex, ControllerAxis controllerAxis)
    {
        GamepadAxis axis = (GamepadAxis)controllerAxis;
        float value = Raylib.GetGamepadAxisMovement(controllerIndex, axis);
        return value;
    }
    public static float GetAnyControllerAxis(ControllerAxis controllerAxis, float deadzone = 0.05f)
    {
        GamepadAxis axis = (GamepadAxis)controllerAxis;
        float finalValue = 0f;
        int activeControllers = 0;

        int controllerCount = ConnectedControllerCount();
        for (int i = 0; i < controllerCount; i++)
        {
            float value = Raylib.GetGamepadAxisMovement(i, axis);
            bool isActive = Math.Abs(value) > deadzone;
            if (isActive)
            {
                finalValue += value;
                activeControllers++;
            }
        }

        finalValue /= controllerCount;
        return finalValue;
    }
    public static bool IsControllerAvailable(int controllerIndex)
    {
        bool isAvailable = Raylib.IsGamepadAvailable(controllerIndex);
        return isAvailable;
    }
    public static int ConnectedControllerCount()
    {
        int controllerCount = 0;
        int index = 0;
        while (Raylib.IsGamepadAvailable(index++))
            controllerCount++;
        return controllerCount;
    }
}
