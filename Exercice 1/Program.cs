using System;

namespace Exercice_1
{
    class Program
    {
        static void Test_Case1()
        {
            CustomQueue<string> string_queue = new CustomQueue<string>();
		
            string_queue.enqueueing("node1");
            string_queue.enqueueing("node2");
            string_queue.enqueueing("node3");
            string_queue.enqueueing("node4");
            string_queue.normal_print();
            
            string_queue.dequeueing();
            string_queue.foreach_print();

            string_queue.enqueueing("node5");
            string_queue.foreach_print();
        }

        static void Test_Case2()
        {
            CustomQueue<int> int_queue = new CustomQueue<int>();
		
            int_queue.enqueueing(1);
            int_queue.enqueueing(2);
            int_queue.enqueueing(3);
            int_queue.enqueueing(4);
            int_queue.normal_print();
            
            int_queue.dequeueing();
            int_queue.foreach_print();

            int_queue.enqueueing(5);
            int_queue.foreach_print();
        }

        static void Main(string[] args)
        {
            //Test_Case1();
            Test_Case2();
        }
    }
}
