using System;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    private SortedDictionary<int, Queue<T>> queue = new SortedDictionary<int, Queue<T>>();

    public void Enqueue(T item, int priority)
    {
        if (!queue.ContainsKey(priority))
        {
            queue.Add(priority, new Queue<T>());
        }
        queue[priority].Enqueue(item);
    }

    public T Dequeue()
    {
        var highestPriority = queue.Keys.First();
        var item = queue[highestPriority].Dequeue();
        if (queue[highestPriority].Count == 0)
        {
            queue.Remove(highestPriority);
        }
        return item;
    }

    public int Count
    {
        get { return queue.Values.Sum(q => q.Count); }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        PriorityQueue<string> q = new PriorityQueue<string>();

        q.Enqueue("venn", 2);
        q.Enqueue("srem", 3);
        q.Enqueue("lily", 1);
        

        Console.WriteLine("Queue count: " + q.Count);

        Console.WriteLine(q.Dequeue()); // should print task3
        Console.WriteLine(q.Dequeue()); // should print task4
        Console.WriteLine(q.Dequeue()); // should print task1
        Console.WriteLine(q.Dequeue()); // should print task2

        Console.WriteLine("Queue count: " + q.Count);
    }
}
