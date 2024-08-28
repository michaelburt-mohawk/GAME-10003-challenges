using Raylib_cs;
using System.Diagnostics;

public class Time
{
    private static int targetFPS = 60;

    public static int TargetFPS
    {
        get => targetFPS;
        set => SetTargetFpsOrError(value);
    }

    private static void SetTargetFpsOrError(int targetFPS)
    {
        if (targetFPS < 0)
        {
            string msg = "FPS must be greater than 0!";
            throw new ArgumentException(msg);
        }

        Time.targetFPS = targetFPS;
    }

    public static double TimeSinceStart()
    {
        double timeSinceStart = Raylib.GetTime();
        return timeSinceStart;
    }

    public static float FixedDeltaTime()
    {
        float fixedDeltaTime = 1f / targetFPS;
        return fixedDeltaTime;
    }
    public static float DynamicDeltaTime()
    {
        float dynamicDeltaTime = Raylib.GetFrameTime();
        return dynamicDeltaTime;
    }
    public static float DeltaTime()
    {
        bool isDebugging = Debugger.IsAttached;
        float deltaTime = isDebugging ? FixedDeltaTime() : DynamicDeltaTime();
        return deltaTime;
    }
}
