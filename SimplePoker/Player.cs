using System;

namespace SimplePoker {
    /// <summary>
    /// Information about player
    /// </summary>
    public class Player {

        #region Fields

        string name;

        #endregion

        #region Properties
        /// <summary>
        /// Player name
        /// </summary>
        public string Name { get { return name; } }

        #endregion

        #region Constructors

        public Player() {
            this.name = "Anonymous";
        }

        public Player(string name) : this() {
            this.name = name;
        }

        #endregion
    }
}
