﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class Worker : BackgrounfService
    {
        private readonly IMessageWriter _messageWriter;

    }
}
