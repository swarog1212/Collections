using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace Collections
{
    class Program
    {

        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\Симаргл\Desktop\cdev_Text.txt"); //текстовый файл на рабочем столе
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var textList = new List<string>();
            textList.AddRange(words);
            var textLinkedList = new LinkedList<string>();

            foreach (var item in words)
            {
                textLinkedList.AddFirst(item);
            }
            Estimate(20, textLinkedList, textList);
        }
        static void InsertList(List<string> text)
        {
            text.Insert(2, "Вставка");
        }

        static void InsertLinkedList(LinkedList<string> text)
        {
            LinkedListNode<string> node = text.First;
            text.AddAfter(node, "Вставка");
        }

        static void Estimate(int n, LinkedList<string> llText, List<string> lText)
        {
            var timer = new Stopwatch();
            Console.WriteLine("Оценка производительности вставки List");

            timer.Start();

            for (int i = 0; i < n; i++)
            {
                timer.Restart();
                InsertList(lText);
                timer.Stop();
                Console.WriteLine(timer.ElapsedTicks);
            }

            Console.WriteLine("Оценка производительности вставки LinkedList");

            for (int i = 0; i < n; i++)
            {
                timer.Restart();
                InsertLinkedList(llText);
                timer.Stop();
                Console.WriteLine(timer.ElapsedTicks);
            }
        }
    }
}
