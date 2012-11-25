using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LAZYSHELL.Undo
{
    class CommandStack
    {
        // class variables and accessors
        private Command[] commands;
        private Stack<Command> redoStack;
        private int index = 0;
        private int undo = 0;
        private bool undoing = false, redoing = false;
        // constructor
        public CommandStack()
        {
            commands = new Command[65535];
            redoStack = new Stack<Command>();
        }
        public CommandStack(int initialSize)
        {
            commands = new Command[initialSize];
            redoStack = new Stack<Command>();
        }
        // accessor functions
        public void SetTilemaps(Tilemap tilemap)
        {
            foreach (TilemapEdit command in commands)
                if (command != null)
                    command.Tilemap = tilemap;
        }
        public void SetSolidityMaps(Tilemap tilemap)
        {
            foreach (SolidityEdit command in commands)
                if (command != null)
                    command.Tilemap = tilemap;
        }
        // public functions
        public bool UndoCommand()
        {
            if (commands.Length < 1 || commands[index] == null || undo <= 0)
                return false;
            //
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
            //
            return true;
        }
        public bool RedoCommand()
        {
            if (redoStack.Count == 0)
                return false;
            //
            redoing = true;
            Command cmd = redoStack.Pop();
            cmd.Execute();
            if (!cmd.AutoRedo())
                Push(cmd);
            redoing = false;
            //
            return true;
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
            //
            index++;
            if (index < commands.Length)
            {
                commands[index] = cmd;
                if (undo < commands.Length)
                    undo++;
            }
            else if (index >= commands.Length)
            {
                // We have filled the whole array and are now overwriting the old commands
                index = 0;
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
            //
            index = 0;
            undo = 0;
        }
    }
}
