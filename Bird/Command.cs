using System.Collections.Generic;

namespace Bird
{
    public class Command
    {
        public string[] CommandValues;

        public Command(string[] commandvalues)
        {
            CommandValues = commandvalues;
        }

        public virtual void Execute() { }
        public virtual void Execute(List<string> args) { }
        public virtual void Help() { }

        public bool ContainsCommand(string command)
        {
            foreach (var commandvalue in CommandValues)
                if (commandvalue == command)
                    return true;
            return false;
        }
    }
}