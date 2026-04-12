namespace CyberBot
{
    public class User
    {
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public string GetGreeting()
        {
            return $"Hello, {Name}! Welcome to the Cybersecurity Awareness Bot.";
        }
    }
}
