﻿using DemoLibrary.Chore;
using DemoLibrary.MessageSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Factory
    {
        public static IPerson CreatePerson()
        {
            return new Person();
        }

        public static IChore CreateChore()
        {
            return new Chore(CreateLogger(),CreateMessageSender());
        }
        public static ILogger CreateLogger()
        {
            return new Logger();
        }
        
        public static IMessageSender CreateMessageSender()
        {
            return new Emailer();
        }
    }
}
