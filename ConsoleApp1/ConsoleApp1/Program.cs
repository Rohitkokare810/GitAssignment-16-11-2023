using System;
using System.Collections.Generic;

public class LargeDataCollection : IDisposable
{
    private List<object> data;

    // Constructor to initialize the collection with initial data
    public LargeDataCollection(IEnumerable<object> initialData)
    {
        data = new List<object>(initialData);
    }

    // Method to add an element to the collection
    public void AddElement(object element)
    {
        data.Add(element);
    }

    // Method to remove an element from the collection
    public bool RemoveElement(object element)
    {
        return data.Remove(element);
    }

    // Method to access elements from the collection
    public object GetElement(int index)
    {
        if (index >= 0 && index < data.Count)
        {
            return data[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
    }

    // Implementing the IDisposable interface
    public void Dispose()
    {
        // Release any unmanaged resources here
        // Set the internal data structure to null to free up memory
        data = null;
    }
}

class Program
{
    static void Main()
    {
        // Create an instance of LargeDataCollection
        using (var largeDataCollection = new LargeDataCollection(new List<object> { 1, 2, 3, "four", 5.0 }))
        {
            // Demonstrate adding, removing, and accessing elements
            largeDataCollection.AddElement("six");
            Console.WriteLine("Element at index 2: " + largeDataCollection.GetElement(2));
            largeDataCollection.RemoveElement(3);

            // Explicitly call Dispose to release resources and free up memory
            largeDataCollection.Dispose();
        }

        // The largeDataCollection is disposed of and cannot be used here
    }
}
