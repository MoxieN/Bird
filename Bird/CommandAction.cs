/*
* PROJECT:          Bird Interactive Shell
* CONTENT:          Bird Command Interpreter - CommandAction Base
* PROGRAMMER(S):    Kevan Guillot <kevan37000@hotmail.com>
*/

using System;

namespace Bird;

public class CommandAction : Command
{
    private Action _action;

    /// <summary>
    /// Command without being forced to create a class, with actions.
    /// </summary>
    /// <param name="commandvalues">Commands values wich will be interpreted.</param>
    /// <param name="action">Action that the command will do.</param>
    public CommandAction(string[] commandvalues, Action action) : base(commandvalues)
    {
        _action = action;
    }

    /// <summary>
    /// RebootCommand
    /// </summary>
    public override void Execute()
    {
        _action();
    }
}