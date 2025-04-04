using System;
using System.Media;
using System.Threading;
//using System.Windows.Forms;
using System.Speech.Synthesis;
class CyberSecurityChatbot
{
    static void Main()
    {
        SpeechSynthesizer talk = new SpeechSynthesizer();
        talk.Volume = 100;
        talk.Rate = 1;

        talk.Speak("Hello i'm here to provide cybersecurity tips");
        Console.Title = "Cybersecurity Awareness Assistant";
        Console.Clear();
        PlayVoiceGreeting();
        ShowHeader();
        GetUserInput();
        ChatLoop();
    }

    static void PlayVoiceGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer();
            player.PlaySync(); // Play the greeting before moving forward
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠ Error: Unable to play voice greeting.");
            Console.WriteLine("Details: " + e.Message);
            Console.ResetColor();
        }
    }

    static void ShowHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
  ██████╗ ██╗   ██╗██████╗ ███████╗███████╗
 ██╔═══██╗██║   ██║██╔══██╗██╔════╝██╔════╝
 ██║   ██║██║   ██║██████╔╝███████╗█████╗  
 ██║▄▄ ██║██║   ██║██╔══██╗╚════██║██╔══╝  
 ╚██████╔╝╚██████╔╝██║  ██║███████║███████╗
  ╚══▀▀═╝  ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝
     Cybersecurity Awareness Assistant  
        ");
        Console.ResetColor();
    }

    static void GetUserInput()
    {
        Console.Write("\n👤 Enter your name: ");
        string name = Console.ReadLine()?.Trim();

        while (string.IsNullOrEmpty(name))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠ Please enter a valid name.");
            Console.ResetColor();
            Console.Write("👤 Enter your name: ");
            name = Console.ReadLine()?.Trim();
        }

        Console.WriteLine($"\n👋 Hello, {name}! I'm here to provide cybersecurity tips.");
        Console.WriteLine("💡 You can ask about password security, phishing scams, or safe browsing habits.");
    }

    static void ChatLoop()
    {
        while (true)
        {
            Console.Write("\n💬 You: ");
            string userInput = Console.ReadLine()?.ToLower().Trim();

            if (string.IsNullOrEmpty(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("🤖 I didn't catch that. Could you rephrase?");
                Console.ResetColor();
                continue;
            }

            switch (userInput)
            {
                case "how are you?":
                    TypeResponse("I'm just a bot, but I'm here to help you stay secure!");
                    break;

                case "what's your purpose?":
                    TypeResponse("I offer guidance on online safety and cybersecurity best practices.");
                    break;

                case "what can I ask you about?":
                    TypeResponse("You can ask about password security, phishing scams, or safe browsing.");
                    break;

                case "password security":
                    TypeResponse("Use long, complex passwords with a mix of uppercase, lowercase, numbers, and symbols.");
                    break;

                case "phishing":
                    TypeResponse("Avoid clicking suspicious links and always verify sender identities.");
                    break;

                case "safe browsing":
                    TypeResponse("Use secure websites (HTTPS), keep your browser updated, and avoid untrusted downloads.");
                    break;

                case "exit":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("🔒 Stay safe online! Goodbye.");
                    Console.ResetColor();
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("🤖 I didn't understand that. Try asking about cybersecurity topics.");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void TypeResponse(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(25); // Simulate a typing effect
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}

   