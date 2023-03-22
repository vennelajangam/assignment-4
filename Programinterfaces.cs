using System;
using System.Collections.Generic;
using System.Linq;

public interface IPriorityQueue<T>
{
    void Enqueue(T item, int priority);
    T Dequeue();
}

public class PriorityQueue<T> : IPriorityQueue<T>
{
    private SortedDictionary<int, Queue<T>> _items = new SortedDictionary<int, Queue<T>>();

    public void Enqueue(T item, int priority)
    {
        if (!_items.ContainsKey(priority))
        {
            _items.Add(priority, new Queue<T>());
        }

        _items[priority].Enqueue(item);
    }

    public T Dequeue()
    {
        var item = _items.First();

        if (item.Value.Count == 1)
        {
            _items.Remove(item.Key);
        }
        else
        {
            _items[item.Key].Dequeue();
        }

        return item.Value.Dequeue();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IPriorityQueue<string> queue = new PriorityQueue<string>();

        queue.Enqueue("Hello", 2);
        queue.Enqueue("World", 1);
        queue.Enqueue("!", 2);

        Console.WriteLine(queue.Dequeue()); // Output: World
        Console.WriteLine(queue.Dequeue()); // Output: Hello
        Console.WriteLine(queue.Dequeue()); // Output: !
    }
}
