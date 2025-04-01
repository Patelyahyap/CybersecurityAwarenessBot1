using System;
using System.IO;
using System.Media;
using System.Threading; // Required for Thread.Sleep

namespace CybersecurityAwarenessBot1 // Make sure this matches your project name/folder
{
    class Program
    {
        static string? userName = null; // Store user's name

        static void Main(string[] args)
        {
            // --- Initial Setup & Greetings ---
            SetConsoleAppearance();
            PlayGreetingSound();
            DisplayAsciiArt();
            DisplayDivider();
            AskForUserName();
            DisplayWelcomeMessage();
            DisplayDivider();

            // --- Main Interaction Loop ---
            ChatLoop();

            // --- Farewell ---
            Console.ForegroundColor = ConsoleColor.Yellow;
            SimulatedTyping("\nThank you for chatting! Stay safe online.", 40); // Use simulated typing
            Console.ResetColor();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // --- UI and Formatting Methods ---

        static void SetConsoleAppearance()
        {
            Console.Title = "Cybersecurity Awareness Bot";
            Console.ForegroundColor = ConsoleColor.White; // Default text color
            Console.BackgroundColor = ConsoleColor.Black; // Default background
            Console.Clear(); // Clear console in case of previous content
        }

        static void DisplayAsciiArt()
        {
            // Example ASCII Art (Replace with your own)
            string asciiArt = @"
   *****************************************
   *       ___ Cybersecurity ___         *
   *      /   \ Awareness /   \        *
   *     |  () |   Bot   |  () |       *
   *      \___/         \___/        *
   *     _______||_______||_______       *
   *    / ______||_______||______ \      *
   *   / /     \\       //     \ \     *
   *  | |       \\_____//       | |    *
   *  | |        \_____/        | |    *
   *  \ \         -----         / /     *
   *   \ \_______/-----\_______/ /      *
   *    \_______________________/       *
   *                                       *
   *****************************************
";
            Console.ForegroundColor = ConsoleColor.Cyan;
            SimulatedTyping(asciiArt, 1); // Use simulated typing here too
            Console.ResetColor();
            Console.WriteLine(); // Add space after art
        }

        static void DisplayDivider(char symbol = '=', int length = 50)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string(symbol, length));
            Console.ResetColor();
        }

        // NEW: Simulated Typing effect
        static void SimulatedTyping(string message, int delay = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Pause briefly between characters
            }
            Console.WriteLine(); // Move to next line after message
        }

        // --- Feature Methods ---

        static void PlayGreetingSound()
        {
            try
            {
                string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Greeting.wav"); // Ensure correct filename

                if (File.Exists(soundPath))
                {
                    #pragma warning disable CA1416
                    SoundPlayer player = new SoundPlayer(soundPath);
                    player.PlaySync();
                    #pragma warning restore CA1416
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[Audio file 'Greeting.wav' not found. Skipping voice greeting.]");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error playing audio: {ex.Message}. Sound playback might not be supported.]");
                Console.ResetColor();
            }
        }

        static void AskForUserName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            SimulatedTyping("Before we start, could you please tell me your name? ", 40); // Use typing effect
            Console.ResetColor();
            Console.Write("> "); // Keep prompt on same line
            userName = Console.ReadLine();

            // Improved Input validation for name
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                SimulatedTyping("Oops! It looks like you didn't enter a name. Please tell me who I'm talking to.", 40);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("> ");
                Console.ResetColor();
                userName = Console.ReadLine();
            }
             // Capitalize first letter for niceness
            userName = char.ToUpper(userName[0]) + userName.Substring(1);
        }

        static void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            SimulatedTyping($"\nNice to meet you, {userName}!", 40); // Use typing effect
            SimulatedTyping("I am the Cybersecurity Awareness Bot.", 40);
            SimulatedTyping("My purpose is to provide basic information on staying safe online.", 40);
            Console.ResetColor();
        }

        // --- Main Interaction Logic ---

        static void ChatLoop()
        {
            string? userInput;
            bool continueChat = true;

            Console.ForegroundColor = ConsoleColor.Magenta;
            SimulatedTyping("\nHow can I help you today? You can ask me about my purpose, password safety, phishing, or safe browsing. Type 'help' for options or 'exit' to quit.", 40);
            Console.ResetColor();

            while (continueChat)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n{userName}> "); // Prompt user
                Console.ResetColor();
                userInput = Console.ReadLine();

                // Input Validation (Handles empty/null)
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    SimulatedTyping("Please enter a question or command.", 30);
                    Console.ResetColor();
                    continue; // Skip processing and ask again
                }

                // Process normalized input
                string processedInput = userInput.ToLower().Trim();

                // Check for exit command first
                if (processedInput == "exit" || processedInput == "quit" || processedInput == "bye")
                {
                    continueChat = false; // Exit the loop
                }
                else
                {
                    // Process other commands/questions
                    ProcessUserInput(processedInput);
                }

                // Add a small delay before next prompt if still chatting
                if(continueChat) Thread.Sleep(200);
            }
        }

        // Full Input Processing Logic
        static void ProcessUserInput(string input)
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // Bot response color

            // Use Contains for more flexible matching
            if (input.Contains("how are you"))
            {
                SimulatedTyping("I'm a bot, so I don't have feelings, but I'm running smoothly! Ready to help you with cybersecurity.", 30);
            }
            else if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                SimulatedTyping("My purpose is to provide basic awareness about common cybersecurity threats like phishing, weak passwords, and unsafe browsing habits.", 30);
            }
            else if (input.Contains("ask you about") || input.Contains("what can i ask") || input.Contains("help") || input.Contains("options"))
            {
                SimulatedTyping("You can ask me about:\n" +
                                "  - Password Safety (tips for strong passwords)\n" +
                                "  - Phishing (how to recognize phishing attempts)\n" +
                                "  - Safe Browsing (tips for browsing the web securely)\n" +
                                "Just type keywords like 'password', 'phishing', or 'browsing'. You can also type 'exit' to quit.", 30);
            }
            else if (input.Contains("password") || input.Contains("pass word"))
            {
                SimulatedTyping("Password Safety Tips:\n" +
                                "  - Use strong, unique passwords for different accounts.\n" +
                                "  - Combine upper/lowercase letters, numbers, and symbols.\n" +
                                "  - Aim for at least 12 characters.\n" +
                                "  - Avoid using personal information (birthdays, names).\n" +
                                "  - Consider using a password manager.", 30);
            }
            else if (input.Contains("phishing") || input.Contains("fishing"))
            {
                SimulatedTyping("Phishing Awareness:\n" +
                                "  - Be wary of emails/messages asking for personal info or login details.\n" +
                                "  - Check the sender's email address carefully.\n" +
                                "  - Look for typos or grammatical errors.\n" +
                                "  - Don't click suspicious links or download unknown attachments.\n" +
                                "  - If unsure, contact the organization directly through official channels.", 30);
            }
            else if (input.Contains("safe browsing") || input.Contains("browsing") || input.Contains("internet safety"))
            {
                SimulatedTyping("Safe Browsing Tips:\n" +
                                "  - Keep your browser and operating system updated.\n" +
                                "  - Use secure HTTPS connections (look for the padlock icon).\n" +
                                "  - Be cautious about downloading files or clicking pop-ups.\n" +
                                "  - Use reputable antivirus/anti-malware software.\n" +
                                "  - Be mindful of information shared on public Wi-Fi.", 30);
            }
            else
            {
                // Default response for invalid/unsupported input
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                SimulatedTyping("I didn't quite understand that. Could you rephrase? You can type 'help' to see what I can talk about.", 30);
            }

            Console.ResetColor(); // Reset color after bot response
        }
    }
}