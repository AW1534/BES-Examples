using System;

using BetterEventSystem;
namespace Terminal;

internal class Program {

    static void Main(string[] args) {
        Console.WriteLine("Welcome to Terminal!");
        
        new Event("quit").AddListener((e) => {
            Console.WriteLine("Quitting...");
            Environment.Exit(0);
        });
        
        // instantiate all classes that contain other events.
        new Help();
        new Blackjack();
        Settings settings = new Settings();

        while (true) {
            Console.Write(">>> ");
            string[] input = Console.ReadLine().ToLower().Split(" "); // Split input by spaces (and make everything lowercase)
            string command = input[0]; // Get the first word of the input, which is the command
            string[] cmdArgs = input.Skip(1).ToArray(); // Get the rest of the input, which are the arguments

            try {
                // Try to find an event with the given name, and broadcast it while passing the arguments.
                // We are doing it synchronously, so we can wait for the command to finish before continuing.
                EventSystem.GetEvent(command, settings.CreateIfNotExists).BroadcastSync(data: cmdArgs);
            }
            catch (NullReferenceException) {
                // if Settings.createIfNotExists is false, the event will not be created if it doesn't exist. this will throw a NullReferenceException, so we catch it and print an error message
                Console.WriteLine("Command not found.");
            }

        }
    }
}