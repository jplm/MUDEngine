﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUDServer
{
    class Gehen : BasicCommand
    {
        public Gehen(UserDialogue.WriteMethod write, DataContainer cont)
        {
            this.write = write;
            this.container = cont;
        }
        public override bool interpret(string userinput)
        {
            if (userinput == "n")
            {
                changeRoom("North");
            }
            else if (userinput == "w")
            {
                changeRoom("West");
            }
            else if (userinput == "s")
            {
                changeRoom("South");
            }
            else if (userinput == "o")
            {
                changeRoom("East");
            }
            else if (userinput == "h")
            {
                changeRoom("Up");
            }
            else if (userinput == "r")
            {
                changeRoom("Down");
            }
            else
            {
                return false;
            }
            return true;
        }
        private void changeRoom(string direction)
        {
            if (container.r_data.changeRoom(direction))
            {
                roomdescription();
            }
            else
            {
                write("Hier geht es nicht weiter.\n");
            }
        }
        private void roomdescription()
        {
            write(container.r_data.Name + "\n\n" + container.r_data.Description + "\n");
            List<Monster> tmp = Monster.loadMonsters(ref container);
            if (tmp != null)
            {
                write("Monster:\n");
                foreach (Monster m in tmp)
                {
                    write(" " + m.Name + "\n");
                }
            }
        }
    }
}
