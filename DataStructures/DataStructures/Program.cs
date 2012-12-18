using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args) 
        {
            // Nodes are linked.
            var basicNodes = new NodePlay();
            basicNodes.Play();

            // Linked List.
            var linkedList = new LinkedListPlay();
            linkedList.Play();

            Console.ReadLine();
        }
    }
}
