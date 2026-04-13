using System;
using System.Threading;

namespace CyberSecurityChatbot
{
    public class Chatbot
    {
        private User? _user;

        public void Start()
        {
            DisplayHeader();
            GetUserName();
            RunChat();
        }

        private void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("====================================================");
            Console.WriteLine(@"
   ____            _               ____        _   
  / ___| _   _ ___| |_ ___ _ __   | __ )  ___ | |_ 
 | |    | | | / __| __/ _ \ '__|  |  _ \ / _ \| __|
 | |___ | |_| \__ \ ||  __/ |     | |_) | (_) | |_ 
  \____| \__, |___/\__\___|_|     |____/ \___/ \__|
         |___/                                    
");
            Console.WriteLine("        CYBERSECURITY AWARENESS BOT");
            Console.WriteLine("====================================================");
            Console.ResetColor();
        }

        private void GetUserName()
        {
            Console.Write("\nEnter your name: ");
            string? input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Name cannot be empty. Enter your name: ");
                input = Console.ReadLine();
            }

            _user = new User { Name = input.Trim() };
            TypeEffect($"\nHello {_user.Name}! Welcome to the Cybersecurity Awareness Bot.\n");
        }

        private void RunChat()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nAsk a question (type 'exit' to quit): ");
                Console.ResetColor();

                string? input = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter something.");
                    continue;
                }

                if (input == "exit")
                {
                    Console.WriteLine("Goodbye! Stay safe online.");
                    break;
                }

                Respond(input);
            }
        }

        private void Respond(string input)
        {
            if (input.Contains("how are you"))
            {
                Console.WriteLine("I'm just a program, but I'm here to help you stay safe online!");
            }
            else if (input.Contains("what can i ask") || input.Contains("what can you do") || input.Contains("help") || input.Contains("topics"))
            {
                Console.WriteLine("You can ask me about passwords, phishing, safe browsing, malware, VPN security, two-factor authentication, identity theft, and public Wi-Fi safety.");
            }
            else if (input.Contains("purpose"))
            {
                Console.WriteLine("My purpose is to educate users about cybersecurity threats and help them stay safe online.");
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("Use strong passwords with at least 12 characters, including uppercase letters, lowercase letters, numbers, and symbols. Avoid personal information and never reuse passwords.");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("Phishing is when attackers trick you with fake messages or websites. Never click suspicious links, and always verify the sender before sharing personal information.");
            }
            else if (input.Contains("safe") && input.Contains("brows"))
            {
                Console.WriteLine("For safe browsing, use HTTPS websites, avoid suspicious downloads, keep your browser updated, and close pages that ask for unnecessary personal information.");
            }
            else if (input.Contains("malware") || input.Contains("virus") || input.Contains("ransomware"))
            {
                Console.WriteLine("Malware is harmful software that can damage your device or steal information. Keep antivirus updated, avoid unknown attachments, and do not install untrusted apps.");
            }
            else if (input.Contains("vpn"))
            {
                Console.WriteLine("A VPN encrypts your internet connection, especially on public networks. Use a trusted VPN to help protect your privacy when browsing on Wi-Fi you do not control.");
            }
            else if (input.Contains("2fa") || input.Contains("two factor") || input.Contains("mfa"))
            {
                Console.WriteLine("Two-factor authentication adds a second layer of security to your account. Turn it on wherever possible so stolen passwords alone are not enough for attackers.");
            }
            else if (input.Contains("identity theft") || input.Contains("identity"))
            {
                Console.WriteLine("Identity theft happens when criminals use your personal details to impersonate you. Protect your ID number, banking details, and account logins, and monitor your accounts regularly.");
            }
            else if (input.Contains("wifi") || input.Contains("wi-fi") || input.Contains("public wi-fi") || input.Contains("public wifi"))
            {
                Console.WriteLine("Public Wi-Fi can be risky. Avoid banking or sensitive logins on open networks, and use a VPN if you must connect in public.");
            }
            else
            {
                Console.WriteLine("I didn't quite understand that. Could you rephrase?");
            }
        }

        private void TypeEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
        }
    }
}
