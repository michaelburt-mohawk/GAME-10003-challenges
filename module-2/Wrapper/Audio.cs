using Raylib_cs;

/// <summary>
///     Access audio-related functions.
/// </summary>
public static class Audio
{
    // TODO: alias Sound, Music

    // Keep list of music to auto-update in background
    private static readonly List<Music> activeMusic = [];
    public static Music[] ActiveMusic => activeMusic.ToArray();

    public static Music LoadMusic(string filePath)
    {
        var music = Raylib.LoadMusicStream(filePath);
        activeMusic.Add(music);
        return music;
    }
    public static void UnloadMusic(Music music)
    {
        activeMusic.Remove(music);
        Raylib.UnloadMusicStream(music);
    }
    public static Sound LoadSound(string filePath)
    {
        var sound = Raylib.LoadSound(filePath);
        return sound;
    }
    public static void UnloadSound(Sound sound)
    {
        Raylib.UnloadSound(sound);
    }

    public static void Play(Sound sound) => Raylib.PlaySound(sound);
    public static void Pause(Sound sound) => Raylib.PauseSound(sound);
    public static void Resume(Sound sound) => Raylib.ResumeSound(sound);
    public static void Stop(Sound sound) => Raylib.StopSound(sound);
    public static bool IsPlaying(Sound sound) => Raylib.IsSoundPlaying(sound);
    public static void SetPan(Sound sound, float pan) => Raylib.SetSoundPan(sound, pan);
    public static void SetPitch(Sound sound, float pan) => Raylib.SetSoundPitch(sound, pan);
    public static void SetVolume(Sound sound, float pan) => Raylib.SetSoundVolume(sound, pan);


    public static void Play(Music music) => Raylib.PlayMusicStream(music);
    public static void Pause(Music music) => Raylib.PauseMusicStream(music);
    public static void Resume(Music music) => Raylib.ResumeMusicStream(music);
    public static void Stop(Music music) => Raylib.StopMusicStream(music);
    public static void SetPan(Music music, float pan) => Raylib.SetMusicPan(music, pan);
    public static void SetPitch(Music music, float pan) => Raylib.SetMusicPitch(music, pan);
    public static void SetVolume(Music music, float pan) => Raylib.SetMusicVolume(music, pan);

}