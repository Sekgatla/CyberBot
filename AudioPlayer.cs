using System;
using System.IO;
using System.Media;

namespace CyberSecurityChatbot
{
    public class AudioPlayer
    {
        private readonly string _filePath = "greeting.wav";

        public void PlayGreeting()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using SoundPlayer player = new SoundPlayer(_filePath);
                    player.PlaySync();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Warning: greeting.wav not found.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }
    }
}
