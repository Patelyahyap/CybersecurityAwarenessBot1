using System;
using System.IO;          // Required for Path
using System.Media;       // Required for SoundPlayer (Add System.Windows.Extensions package if needed)
using System.Threading;   // Required for Thread.Sleep

namespace CybersecurityAwarenessBot1 // Make sure this matches your project name/folder
{
    class Program
    {
        static void Main(string[] args)
        {
            SetConsoleAppearance();
            PlayGreetingSound();
            DisplayAsciiArt();

            Console.WriteLine("\n(Stage 1 Complete: Press any key to exit)"); // Placeholder
            Console.ReadKey(); // Keep console open
        }

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
            // Use simple Console.WriteLine for now, SimulatedTyping comes later
            Console.WriteLine(asciiArt);
            Console.ResetColor();
            Console.WriteLine();
        }

        static void PlayGreetingSound()
        {
            try
            {
                string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Greeting.wav"); // Ensure your WAV file is named Greeting.wav

                if (File.Exists(soundPath))
                {
                    #pragma warning disable CA1416 // Validate platform compatibility
                    SoundPlayer player = new SoundPlayer(soundPath);
                    player.PlaySync(); // Play and wait
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
    }
}