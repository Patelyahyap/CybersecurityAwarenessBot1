using System;
using System.IO;
using System.Media;
using System.Threading;

namespace CybersecurityAwarenessBot1 // Make sure this matches your project name/folder
{
    class Program
    {
        static string? userName = null; // Store user's name

        static void Main(string[] args)
        {
            // --- Initial Setup & Greetings (From Stage 1) ---
            SetConsoleAppearance();
            PlayGreetingSound();
            DisplayAsciiArt();
            DisplayDivider(); // Added divider

            // --- User Interaction (New for Stage 2) ---
            AskForUserName();
            DisplayWelcomeMessage();
            DisplayDivider(); // Added divider

            // --- Basic Interaction Loop (New skeleton for Stage 2) ---
            ChatLoop();

            // --- Farewell (Basic for now) ---
            Console.WriteLine("\n(Chat finished. Press any key to exit)");
            Console.ReadKey();
        }

        // --- UI and Formatting Methods ---

        static void SetConsoleAppearance()
        {
            Console.Title = "Cybersecurity Awareness Bot";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        static void DisplayAsciiArt()
        {
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
            Console.WriteLine(asciiArt);
            Console.ResetColor();
            Console.WriteLine();
        }

        // NEW Divider Method
        static void DisplayDivider(char symbol = '=', int length = 50)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string(symbol, length));
            Console.ResetColor();
        }

        // --- Feature Methods ---

        static void PlayGreetingSound()
        {
            try
            {
                string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Greeting.wav");

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

        // NEW: Ask for Name
        static void AskForUserName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Before we start, could you please tell me your name? "); // Simple Write for now
            Console.ResetColor();
            userName = Console.ReadLine();

            // Basic validation for name (more robust in Stage 3)
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "User"; // Default if empty
                Console.WriteLine("Okay, I'll call you User for now.");
            }
            else
            {
                 userName = char.ToUpper(userName[0]) + userName.Substring(1); // Capitalize
            }
        }

        // NEW: Display Welcome
        static void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nNice to meet you, {userName}!");
            Console.WriteLine("I am the Cybersecurity Awareness Bot.");
            Console.ResetColor();
        }

        // --- Main Interaction Logic (Skeleton) ---

        // NEW: Basic Chat Loop
        static void ChatLoop()
        {
            string? userInput;
            bool continueChat = true;

            Console.WriteLine("\nHow can I help you today? (Type 'purpose' or 'exit')"); // Basic prompt

            while (continueChat)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n{userName}> "); // Prompt user
                Console.ResetColor();
                userInput = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                     string processedInput = userInput.ToLower().Trim();

                     if (processedInput == "exit")
                     {
                         continueChat = false;
                     }
                     else
                     {
                         // Basic processing (more in Stage 3)
                         ProcessUserInput(processedInput);
                     }
                }
                 // No validation message yet for blank input
            }
        }

        // NEW: Basic Input Processing
        static void ProcessUserInput(string input)
        {
             Console.ForegroundColor = ConsoleColor.Cyan; // Bot response color

             if (input.Contains("purpose"))
             {
                 Console.WriteLine("My purpose is to provide basic awareness about common cybersecurity threats.");
             }
             else
             {
                 // Placeholder for unrecognised input (improved in Stage 3)
                 // Console.WriteLine("I didn't understand that yet.");
             }
             Console.ResetColor();
        }
    }
}