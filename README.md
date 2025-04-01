# Cybersecurity Awareness Bot (POE Part 1)

A basic C# console chatbot designed to provide foundational cybersecurity awareness information, developed as Part 1 of a Portfolio of Evidence.

## Description

This command-line application simulates a simple conversation with a user to educate them on basic cybersecurity concepts. It addresses the growing need for cyber awareness, particularly focusing on common threats encountered by individuals. This initial version establishes the core structure, user interaction, multimedia elements, and CI/CD pipeline required for the project.

## Features (Part 1)

*   **Voice Greeting:** Plays a pre-recorded `.wav` audio file welcoming the user upon launch.
*   **ASCII Art Display:** Shows a cybersecurity-themed ASCII logo or symbol as a header.
*   **Personalized Interaction:** Asks for the user's name and uses it in subsequent messages.
*   **Text-Based Greeting:** Displays a formatted text welcome message.
*   **Basic Response System:** Responds to predefined questions about:
    *   Its purpose ("What's your purpose?", "What can I ask you about?")
    *   Password safety tips
    *   Phishing awareness
    *   Safe browsing practices
*   **Input Validation:** Handles empty or unrecognized user input gracefully with a default message.
*   **Enhanced Console UI:** Utilizes colored text, spacing, dividers, and a simulated typing effect for a more engaging visual experience.
*   **Version Control:** Managed using Git with meaningful commits hosted on GitHub.
*   **Continuous Integration (CI):** Includes a GitHub Actions workflow (`.github/workflows/dotnet.yml`) to automatically build the project and check for basic errors on push.

## Requirements

*   **.NET SDK:** [Specify .NET Version, e.g., 8.0] or later. ([Download here](https://dotnet.microsoft.com/download))
*   **Operating System:** Windows is required for default `System.Media.SoundPlayer` functionality. Playback on macOS/Linux might require adjustments or alternative libraries (or may fail gracefully as implemented in the code).

## Setup and Installation

1.  **Clone the repository:**
    ```bash
    git clone <your-repo-url>
    ```
    *(Replace `<your-repo-url>` with the actual URL of your GitHub repository)*

2.  **Navigate to the project directory:**
    ```bash
    cd CybersecurityAwarenessBot1
    ```
3.  **(Optional) Restore dependencies:** (Usually not needed with modern .NET SDKs)
    ```bash
    dotnet restore
    ```

## How to Run

1.  Ensure you are in the project's root directory (`CybersecurityAwarenessBot1`).
2.  Run the application using the .NET CLI:
    ```bash
    dotnet run
    ```

## Project Structure
Use code with caution.
Markdown
CybersecurityAwarenessBot1/
├── .github/
│ └── workflows/
│ └── dotnet.yml # GitHub Actions CI workflow file
├── .git/ # Git repository data (hidden)
├── .gitignore # Specifies files/folders ignored by Git
├── bin/ # Compiled output (ignored by Git)
├── obj/ # Build artifacts (ignored by Git)
├── CybersecurityAwarenessBot1.csproj # C# project file
├── Greeting.wav # Voice greeting audio file
├── Program.cs # Main application C# code
└── README.md # This file

## Version Control & CI Notes

*   This repository contains a minimum of three meaningful commits reflecting the project's development stages for Part 1.
*   The GitHub Actions CI workflow automatically triggers on pushes to the `main` branch, performing a `dotnet build` to ensure the code compiles successfully.

## Author

Developed by: [Yahya Patel]
