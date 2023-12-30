using System;
using System.Collections.Generic;

namespace ch04_Stack
{
    public class StackTest
    {
        public void Test()
        {
        }

        private void init()
        {
            Stack<Command> cmds = new Stack<Command>();
            var cmd = new Command
            {
                CommandId = 1,
                CommandName = "Name 1",
                OperationOn = DateTime.Now
            };
            cmds.Push(cmd);
            cmds.Pop();
        }

        class CommandStack
        {
            public Stack<Command> _commands { get; private set; }
            int _capacity;
            public CommandStack(int capacity)
            {
                _commands= new Stack<Command>(capacity);
                _capacity = capacity;
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <returns></returns>
            public bool IsFull()
            {
                return _commands.Count >= _capacity;
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <returns></returns>
            public bool IsEmpty()
            {
                return _commands.Count== 0;
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <param name="cmd"></param>
            /// <returns></returns>
            public bool PerformCommand(Command cmd)
            {
                if (!IsFull())
                {
                    _commands.Push(cmd);
                    return true;
                }
                return false;
            }

            /// <summary>
            /// O(n)
            /// </summary>
            /// <param name="cmd"></param>
            /// <returns></returns>
            public bool PerformCommands(List<Command> cmds)
            {
                bool inserted = true;
                foreach (var cmd in cmds)
                {
                    inserted = PerformCommand(cmd);
                }
                return inserted;
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <param name="cmd"></param>
            /// <returns></returns>
            public Command UndoCommand()
            {
                return _commands.Pop();
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <param name="cmd"></param>
            /// <returns></returns>
            public void Reset()
            {
                _commands.Clear();
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <param name="cmd"></param>
            /// <returns></returns>
            public int TotalCommands()
            {
                return _commands.Count;
            }

        }


        class Command
        {
            public int CommandId { get; set; }
            public string CommandName { get; set; }
            public DateTime OperationOn { get; set; }

        }
    }
}
