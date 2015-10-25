using System;

namespace SimplePoker {
    /// <summary>
    /// Information about player
    /// </summary>
    public class Player {
        string name;

        public string Name { get { return name; } }

        public Player() {
            name = "Anonymous";
        }
        public Player(string name) : this() {
            this.name = name;
        }
    }
}
