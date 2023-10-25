using System;
using System.Collections.Generic;

public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> elements = new List<T>();

    public int Count { get { return elements.Count; } }

    public void Enqueue(T item)
    {
        elements.Add(item);
        elements.Sort(); // Сортируем элементы
    }

    public T Dequeue()
    {
        if (Count == 0)
            throw new InvalidOperationException("Queue is empty");

        T result = elements[0];
        elements.RemoveAt(0);
        return result;
    }
}
