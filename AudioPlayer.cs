using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CyberSecurityChatbot
{
    public class AudioPlayer
    {
        // Windows API for playing WAV files — no NuGet package needed
        [DllImport("winmm.dll", SetLastError = true)]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

        private const uint SND_FILENAME = 0x00020000;
        private const uint SND_SYNC = 0x00000000;

        // Path to audio file
        private readonly string _filePath = "greeting.wav";

        public void PlayGreeting()
        {
            try
            {
                // Check if file exists
                if (File.Exists(_filePath))
                {
                    // Play WAV file using Windows built-in API (no packages required)
                    PlaySound(_filePath, IntPtr.Zero, SND_FILENAME | SND_SYNC);
                }
                else
                {
                    // Display warning if file is missing
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Warning: greeting.wav not found.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                // Handle any playback errors
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }
    }
}
