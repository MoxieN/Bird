using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bird
{
    public class Bird
    {
        public const string version = "v1.0.1"; // Il y a pas de ctor  donc . . .
        
        public string Input { get; set; }
        public List<Command> Commands = new();
        
        /// <summary>
        /// Function to put in your Run method, it will handle the console itself
        /// </summary>
        /// <param name="namePth">Where on your filesystem is contained the hostname? if not found it will </param>
        /// <param name="currentDirectoy">Path of your current directory you set</param>
        public void HandleConsole(string namePth, string currentDirectoy)
        {
            string name = File.Exists(namePth) ? File.ReadAllText(namePth) : "Bird";
            
            Console.ForegroundColor = ConsoleColor.White;
            
            Write($"\n{name} ", ConsoleColor.Green);
            if (currentDirectoy == @"0:\")
                Write(@"~\", ConsoleColor.Cyan);
            else
                Write(currentDirectoy, ConsoleColor.Cyan);
            Write("#", ConsoleColor.Gray);
            
            Input = Console.ReadLine();
            if (Input != null) ExecuteCommand(Input);
        }
        
        /// <summary>
        /// Register Command
        /// </summary>
        /// <param name="command">Command to regiser</param>
        public void RegisterCommand(Command command)
        {
            Commands.Add(command);
        }
        
        /// <summary>
        /// Parse the input, then execute the command with arguments or not
        /// </summary>
        /// <param name="input"></param>
        public void ExecuteCommand(string input)
        {
            var args = ParseCommandLine(input);

            var name = args[0];

            if (args.Count > 0) args.RemoveAt(0); //get only arguments

            foreach (var command in Commands)
                if (command.ContainsCommand(name))
                {
                    if (args.Count == 0)
                        command.Execute();
                    else
                    {
                        if(args[0] == "-h")
                            command.Help();
                        
                        command.Execute(args);
                    }
                    
                }
        }
        
        /// <summary>
        /// Parse input to support quotes, args
        /// </summary>
        /// <param name="cmdLine">Input to parse</param>
        /// <returns></returns>
        public List<string> ParseCommandLine(string cmdLine)
        {
            var args = new List<string>();
            if (string.IsNullOrWhiteSpace(cmdLine)) return args;

            var currentArg = new StringBuilder();
            var inQuotedArg = false;

            for (var i = 0; i < cmdLine.Length; i++)
                if (cmdLine[i] == '"')
                {
                    if (inQuotedArg)
                    {
                        args.Add(currentArg.ToString());
                        currentArg = new StringBuilder();
                        inQuotedArg = false;
                    }
                    else
                    {
                        inQuotedArg = true;
                    }
                }
                else if (cmdLine[i] == ' ')
                {
                    if (inQuotedArg)
                    {
                        currentArg.Append(cmdLine[i]);
                    }
                    else if (currentArg.Length > 0)
                    {
                        args.Add(currentArg.ToString());
                        currentArg = new StringBuilder();
                    }
                }
                else
                {
                    currentArg.Append(cmdLine[i]);
                }

            if (currentArg.Length > 0) args.Add(currentArg.ToString());

            return args;
        }
        
        #region Write

        /// <summary>
        ///     Output text with color
        /// </summary>
        /// <param name="text">The text to output</param>
        /// <param name="foregroundColor">Change foreground text color</param>
        /// <param name="backgroundColor">Change background text color</param>
        public void Write(string text, ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void Write(int number, ConsoleColor foregroundColor = ConsoleColor.White,
    ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(number);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        ///     Output text with color
        /// </summary>
        /// <param name="text">The text to output</param>
        /// <param name="foregroundColor">Change foreground text color</param>
        /// <param name="backgroundColor">Change background text color</param>
        public void WriteLine(string text, ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        ///     Output text with color
        /// </summary>
        /// <param name="character">The char to output</param>
        /// <param name="foregroundColor">Change foreground text color</param>
        /// <param name="backgroundColor">Change background text color</param>
        public void WriteLine(char character, ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(character);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        ///     Output text with color
        /// </summary>
        /// <param name="character">The char to output</param>
        /// <param name="foregroundColor">Change foreground text color</param>
        /// <param name="backgroundColor">Change background text color</param>
        public void WriteLine(int number, ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(number);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }




        #endregion
    }
}