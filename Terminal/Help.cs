using System;
using BetterEventSystem;

namespace Terminal; 

public class Help {
    public Help() {
        new Event("help").AddListener((e) => {
            foreach (Event item in EventSystem.Events) {
                Console.WriteLine($"- {item.Name}");
            }
        });
    }
}