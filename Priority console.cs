using System;
using System.Collections.Generic;

class PriorityQueue<T>
{
    private List<Tuple<T, int>> queue = new List<Tuple<T, int>>();

    public void Enqueue(T item, int priority)
    {
        queue.Add(Tuple.Create(item, priority));
    }

    public T Dequeue()
    {
        int bestIndex = 0;

        for (int i = 0; i < queue.Count; i++)
        {
            if (queue[i].Item2 < queue[bestIndex].Item2)
            {
                bestIndex = i;
            }
        }

        T bestItem = queue[bestIndex].Item1;
        queue.RemoveAt(bestIndex);
        return bestItem;
    }

    public int Count
    {
        get { return queue.Count; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        PriorityQueue<string> q = new PriorityQueue<string>();
        q.Enqueue("venn", 2);
        q.Enqueue("srem", 3);
        q.Enqueue("lily", 1);

        while (q.Count > 0)
        {
            Console.WriteLine(q.Dequeue());
        }
    }
}
