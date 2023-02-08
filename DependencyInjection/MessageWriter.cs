using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class MessageWriter :IMessageWriter
    {
        public void Writer(string message)
        {
            Console.WriteLine($"MessageWriter.Writer(message : \"{ message}\")");
        }
    }
}
