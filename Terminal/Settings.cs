using System;
using BetterEventSystem;

namespace Terminal;

public class Settings {
    public bool CreateIfNotExists = true;
    
    public Settings() {
        CreateIfNotExists = true;

        new Event("settings").AddListener((e) => {
            string[] args = e.data as string[];

            try {
                switch (args[0]) {
                    case "query":
                        Console.WriteLine("{ \"settings\": { \"createIfNotExists\": " + CreateIfNotExists + " } }");
                        return;
                        break;
                    case "set":
                        try {
                            switch (args[1]) {
                                case "createifnotexists":
                                    CreateIfNotExists = bool.Parse(args[2]);
                                    return;
                                    break;
                            }
                        } catch(IndexOutOfRangeException) {}
                        Console.WriteLine("settings set arguments:");
                        Console.WriteLine("- settings set help");
                        Console.WriteLine("- settings set CreateIfNotExists <bool>");
                        return;
                        break;
                }
            } catch(IndexOutOfRangeException) {}
            Console.WriteLine("settings command arguments:");
            Console.WriteLine("- settings query");
            Console.WriteLine("- settings set");
            Console.WriteLine("- settings help");
        });
    }
}