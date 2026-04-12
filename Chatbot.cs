using System;
using System.Collections.Generic;
using System.Threading;

namespace CyberBot
{
    public class Chatbot
    {
        private User? _user;
        private bool _running;

        private static readonly Dictionary<string[], string> _responses = new(new StringArrayEqualityComparer())
        {
            {
                new[] { "how are you" },
                "I'm just code, but I'm running smoothly and ready to help you stay safe online!"
            },
            {
                new[] { "what is your purpose", "what's your purpose", "what can you do", "purpose" },
                "My purpose is to educate South African citizens about cybersecurity threats such as phishing, password attacks, and social engineering — and how to avoid them."
            },
            {
                new[] { "what can i ask you about", "what can i ask", "help", "topics" },
                "You can ask me about:\n  • Password safety\n  • Phishing\n  • Safe browsing\n  • Social engineering\n  • Malware & ransomware\n  • Identity theft"
            },
            {
                new[] { "password" },
                "Use strong passwords with at least 12 characters, mixing uppercase, lowercase, numbers, and symbols.\n  Never reuse passwords across sites. Consider a password manager!"
            },
            {
                new[] { "phishing" },
                "Phishing is when attackers send fake emails or messages pretending to be trusted organisations.\n  Never click suspicious links. Verify the sender's email address carefully."
            },
            {
                new[] { "safe browsing", "browse safely", "browsing" },
                "For safe browsing:\n  • Use HTTPS websites (look for the padlock icon)\n  • Avoid downloading files from untrusted sources\n  • Keep your browser and plugins updated\n  • Use a reputable ad/script blocker"
            },
            {
                new[] { "social engineering", "social engineer" },
                "Social engineering is psychological manipulation to trick you into giving up information.\n  Always verify identities before sharing sensitive data — even if someone claims to be from IT support."
            },
            {
                new[] { "malware", "virus", "ransomware" },
                "Malware is malicious software designed to harm your system.\n  Install reputable antivirus software, keep it updated, and avoid opening unknown email attachments."
            },
            {
                new[] { "identity theft", "identity" },
                "Identity theft occurs when criminals steal your personal information.\n  Protect your ID number, bank details, and personal info. Monitor your accounts regularly for unusual activity."
            },
            {
                new[] { "two factor", "2fa", "multi factor", "mfa" },
                "Two-factor authentication (2FA) adds an extra layer of security to your accounts.\n  Always enable 2FA where possible — it drastically reduces the risk of unauthorised access."
            },
            {
                new[] { "vpn" },
                "A VPN (Virtual Private Network) encrypts your internet connection.\n  Use a trusted VPN, especially on public Wi-Fi networks, to keep your data private."
            },
            {
                new[] { "public wifi", "public wi-fi", "wifi", "wi-fi" },
                "Public Wi-Fi can be dangerous! Avoid accessing banking or sensitive accounts on public networks.\n  If you must, always use a VPN to encrypt your connection."
            },
        };

        public void Start()
        {
            Console.Clear();
            DisplayBanner();
            PlayVoiceGreeting();
            AskForName();
            RunConversationLoop();
        }

        private void DisplayBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
  ======================================================================
   ______      _               ____        _   
  / ___\ \ / / |__   ___ _ __| __ )  ___ | |_ 
 | |    \ V /| '_ \ / _ \ '__|  _ \ / _ \| __|
 | |___  | | | |_) |  __/ |  | |_) | (_) | |_ 
  \____|  |_| |_.__/ \___|_|  |____/ \___/ \__|
                                                
   Cybersecurity Awareness Bot — Protecting SA Citizens Online
  ======================================================================
");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
      ___________
     /           \
    | ( o )( o ) |    ""Stay Safe. Stay Aware.""
    |      _      |
    |  \______/  |
     \___________/
        |     |
       /|     |\
");
            Console.ResetColor();
        }

        private void PlayVoiceGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TypeLine("  Playing voice greeting...");
            Console.ResetColor();

            string wavPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");
            var player = new AudioPlayer(wavPath);
            player.Play();

            Console.WriteLine();
        }

        private void AskForName()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  Enter your name: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Please enter your name to continue.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  Enter your name: ");
                Console.ResetColor();
                input = Console.ReadLine();
            }

            _user = new User(input.Trim());

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            TypeLine($"  {_user.GetGreeting()}");
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  ── Type a question about cybersecurity, or try: how are you, help, topics ──");
            Console.WriteLine("  ── Type 'exit' or 'quit' to leave ──");
            Console.ResetColor();
            Console.WriteLine();
        }

        private void RunConversationLoop()
        {
            _running = true;

            while (_running)
            {
                PrintDivider();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"  [{_user?.Name ?? "You"}] > ");
                Console.ResetColor();

                string? raw = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(raw))
                {
                    PrintBotResponse("Please enter something. You can type 'help' to see available topics.");
                    continue;
                }

                string input = raw.Trim().ToLower();

                if (input == "exit" || input == "quit" || input == "bye")
                {
                    PrintBotResponse($"Stay safe online, {_user?.Name}! Goodbye.");
                    _running = false;
                    break;
                }

                string response = GetResponse(input);
                PrintBotResponse(response);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ======================================================================");
            Console.WriteLine("   Thank you for using the Cybersecurity Awareness Bot. Stay secure!");
            Console.WriteLine("  ======================================================================");
            Console.ResetColor();
            Console.WriteLine();
        }

        private string GetResponse(string input)
        {
            foreach (var entry in _responses)
            {
                foreach (string keyword in entry.Key)
                {
                    if (input.Contains(keyword))
                    {
                        return entry.Value;
                    }
                }
            }

            return "I didn't quite understand that. Could you rephrase?\n  Type 'help' to see topics I can assist with.";
        }

        private void PrintBotResponse(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  [CyberBot] ");
            Console.ResetColor();
            TypeLine(message);
            Console.WriteLine();
        }

        private static void TypeLine(string text, int delayMs = 18)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        private static void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  ──────────────────────────────────────────────────────────────────────");
            Console.ResetColor();
        }
    }

    internal class StringArrayEqualityComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[]? x, string[]? y)
        {
            if (x == null || y == null) return false;
            if (x.Length != y.Length) return false;
            for (int i = 0; i < x.Length; i++)
                if (x[i] != y[i]) return false;
            return true;
        }

        public int GetHashCode(string[] obj)
        {
            int hash = 0;
            foreach (var s in obj) hash ^= s.GetHashCode();
            return hash;
        }
    }
}
