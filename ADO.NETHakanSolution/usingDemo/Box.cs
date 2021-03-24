using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usingDemo
{
    class Box : IDisposable
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int Depth { get; set; }

        public void Dispose()
        {
            Console.WriteLine("Disposing unnecessary OS resources.");
        }
    }
}
