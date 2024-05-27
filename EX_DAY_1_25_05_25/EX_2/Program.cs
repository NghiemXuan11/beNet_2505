using System;
using System.Net.WebSockets;
using System.Text;

namespace EX_2
{
    class Program
    {
        static void Main()
        {
            var ptBac1 = new PT_BAC_1();
            ptBac1.GIAI_PT_BAC_1();
            Console.WriteLine('\n');
            var ptBac2 = new PT_BAC_2();
            ptBac2.GIAI_PT_BAC_2();
        }
    }
}