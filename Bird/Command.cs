/*
* PROJECT:          Bird Interactive Shell
* CONTENT:          Bird Command Interpreter - Command Base
* PROGRAMMER(S):    Kevan Guillot <kevan37000@hotmail.com>
*/

using System;
using System.Collections.Generic;

namespace Bird
{
    public class Command : IDisposable
    {
        public string[] CommandValues;

        /// <summary>
        /// Command that needs a class.
        /// </summary>
        /// <param name="commandvalues">Commands values wich will be interpreted.</param>
        public Command(string[] commandvalues)
        {
            CommandValues = commandvalues;
        }

        /// <summary>
        /// Code to be executed without arguments.
        /// </summary>
        public virtual void Execute() { }
        
        /// <summary>
        /// Code to be executed with arguments.
        /// </summary>
        /// <param name="args">Arguments to pass.</param>
        public virtual void Execute(List<string> args) { }
        
        /// <summary>
        /// Help command (often to indicate the use and the args of the command).
        /// </summary>
        public virtual void Help() { }

        /// <summary>
        /// Does the input corresponds to a command?
        /// </summary>
        /// <param name="command">input</param>
        /// <returns>true if the input equals the command, else false.</returns>
        public bool ContainsCommand(string command)
        {
            foreach (var commandvalue in CommandValues)
                if (commandvalue == command)
                    return true;
            return false;
        }
        
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }

    }
}