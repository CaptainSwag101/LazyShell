using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LAZYSHELL.Undo
{

    /*
     * This class completely encapsulates the undo and redo functionality for a window.
     * Just create a command object after each change and push it onto the CommandStack
     * 
     * To undo a command, just call CommandStack.UndoCommand()
     * to redo a command, just call CommandStack.RedoCommand()
     * 
     * If there are no commands to redo/undo nothing will happen
     */
    class CommandStack
    {
        private Command[] commands;
        private Stack<Command> redoStack;
        private int index = 0;
        private int undo = 0;
        private bool undoing = false, redoing = false;

        public CommandStack()
        {
            commands = new Command[50];
            redoStack = new Stack<Command>();
        }
        public CommandStack(int initialSize)
        {
            commands = new Command[initialSize];
            redoStack = new Stack<Command>();
        }
        public void UndoCommand()
        {
            if (commands.Length < 1 || commands[index] == null || undo <= 0)
                return;

            undoing = true;

            if (index > 0 && commands[index] != null) // not going to wrap
            {
                commands[index].Execute();
                if (!commands[index].AutoRedo())
                    redoStack.Push(commands[index]);

                index--;
                undo--;
            }
            else if (index == 0 && commands[index] != null) // wrap
            {
                commands[index].Execute();
                if (!commands[index].AutoRedo())
                    redoStack.Push(commands[index]);

                index = commands.Length - 1;
                undo--;
            }

            undoing = false;
        }
        public void RedoCommand()
        {
            redoing = true;
            Command cmd;

            if (redoStack.Count > 0)
            {
                cmd = redoStack.Pop();
                cmd.Execute();
                if (!cmd.AutoRedo())
                    Push(cmd);
            }
            
            redoing = false;
        }
        public void Push(Command cmd)
        {
            if (commands.Length <= 0)
            {
                return;
            }
            if (undoing)
            {
                redoStack.Push(cmd);
                return;
            }
            if (redoStack.Count != 0 && !redoing)
                redoStack.Clear();

            index++;
            if (index < commands.Length)
            {
                commands[index] = cmd;

                if (undo < commands.Length)
                    undo++;
            }
            else if (index >= commands.Length)
            {

                index = 0; // We have filled the whole array and are now overwriting the old commands
                commands[index] = cmd;

                if (undo < commands.Length)
                    undo++;

            }
        }
        public void Clear()
        {
            for (int i = 0; i < commands.Length; i++)
                commands[i] = null;
            redoStack.Clear();

            index = 0;
            undo = 0;
        }


    }
}
