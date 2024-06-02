using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeLibrary.enums;

namespace TicTacToeLibrary
{
    public class Message
    {
       public CommandEnum command { get; set; }
       public int data { get; set; }

        public Message(CommandEnum command, int data) 
        {
            this.command = command;
            this.data = data;
        }
    }
}
