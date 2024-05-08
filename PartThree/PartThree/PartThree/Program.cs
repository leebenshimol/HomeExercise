// See https://aka.ms/new-console-template for more information

namespace PartThree
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList(5);
           // linkedList.Append(4);
            //linkedList.Append(2);
            //linkedList.Append(9);
            //linkedList.Prepend(7);
            linkedList.Print();
          //  linkedList.Sort();
            Console.WriteLine(linkedList.GetMaxNode().Value);
            int last = linkedList.Unqueue();
            linkedList.Print();
            Console.WriteLine(last);
            Console.WriteLine(linkedList.GetMaxNode().Value);
            //Console.WriteLine(linkedList.GetMinNode().Value);
            //linkedList.Pop();
            //linkedList.Unqueue();
            //linkedList.Print();
            //List<int> l = linkedList.ToList().ToList();
            //foreach (int i in l)
            //{
            //    Console.Write(i + " - > ");
            //}
            // Console.WriteLine(linkedList.IsCircular());

        }
    }
}


