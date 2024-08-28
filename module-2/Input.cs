using Raylib_cs;
using System;
using System.Numerics;

public static class Input
{
    private delegate CBool RaylibKeyboardKeyFunc(KeyboardKey key);
    private delegate CBool RaylibGamepadButtonFunc(int controllerIndex, GamepadButton controllerButton);

    // Keyboard
    private static bool IsKeyX(KeyboardKey key, RaylibKeyboardKeyFunc keyboardFunc)
    {
        bool state = keyboardFunc(key);
        return state;
    }
    public static bool IsKeyPressed(KeyboardKey key) => IsKeyX(key, Raylib.IsKeyPressed);
    public static bool IsKeyReleased(KeyboardKey key) => IsKeyX(key, Raylib.IsKeyReleased);
    public static bool IsKeyUp(KeyboardKey key) => IsKeyX(key, Raylib.IsKeyUp);
    public static bool IsKeyDown(KeyboardKey key) => IsKeyX(key, Raylib.IsKeyDown);

    // Button
    private static bool IsControllerButton(int gamepadIndex, ControllerButton controllerButton, RaylibGamepadButtonFunc controllerFunc)
    {
        GamepadButton button = (GamepadButton)controllerButton;
        bool state = controllerFunc(gamepadIndex, button);
        return state;
    }
    public static bool IsControllerButtonPressed(int controllerIndex, ControllerButton controllerButton)
        => IsControllerButton(controllerIndex, controllerButton, Raylib.IsGamepadButtonPressed);
    public static bool IsControllerButtonReleased(int controllerIndex, ControllerButton controllerButton)
        => IsControllerButton(controllerIndex, controllerButton, Raylib.IsGamepadButtonReleased);
    public static bool IsControllerButtonUp(int controllerIndex, ControllerButton controllerButton)
        => IsControllerButton(controllerIndex, controllerButton, Raylib.IsGamepadButtonUp);
    public static bool IsControllerButtonDown(int controllerIndex, ControllerButton controllerButton)
        => IsControllerButton(controllerIndex, controllerButton, Raylib.IsGamepadButtonDown);

    private static bool IsAnyControllerButton(ControllerButton controllerButton, RaylibGamepadButtonFunc gamepadFunc)
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
        => IsAnyControllerButton(controllerButton, Raylib.IsGamepadButtonPressed);
    public static bool IsAnyControllerButtonReleased(ControllerButton controllerButton)
        => IsAnyControllerButton(controllerButton, Raylib.IsGamepadButtonReleased);
    public static bool IsAnyControllerButtonUp(ControllerButton controllerButton)
        => IsAnyControllerButton(controllerButton, Raylib.IsGamepadButtonUp);
    public static bool IsAnyControllerButtonDown(ControllerButton controllerButton)
        => IsAnyControllerButton(controllerButton, Raylib.IsGamepadButtonDown);


    // Axis
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
