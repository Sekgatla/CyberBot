using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CyberBot
{
    public class AudioPlayer
    {
        private readonly string _filePath;

        public AudioPlayer(string filePath)
        {
            _filePath = filePath;
        }

        public void Play()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"  [Audio] greeting.wav not found at: {_filePath}");
                    Console.ResetColor();
                    return;
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    PlayOnWindows(_filePath);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  [Audio] Voice greeting loaded. (Playback requires Windows.)");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  [Audio] Could not play greeting: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void PlayOnWindows(string path)
        {
            var playerType = Type.GetType("System.Media.SoundPlayer, System.Windows.Extensions");
            if (playerType == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  [Audio] System.Media not available on this runtime.");
                Console.ResetColor();
                return;
            }

            using var player = (IDisposable)Activator.CreateInstance(playerType, path)!;
            playerType.GetMethod("PlaySync")?.Invoke(player, null);
        }
    }
}
