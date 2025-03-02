using System;
using System.Collections.Generic;
using System.Linq;

public class StockPrice
{
    private Dictionary<int, int> timestamps;
    private SortedSet<(int, int)> maxHeap;
    private SortedSet<(int, int)> minHeap;
    private int latestTimestamp;

    public StockPrice()
    {
        timestamps = new Dictionary<int, int>();

        // Use Comparer to sort by price first, then timestamp (for uniqueness)
        maxHeap = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) =>
            b.Item1 != a.Item1 ? b.Item1.CompareTo(a.Item1) : b.Item2.CompareTo(a.Item2)));

        minHeap = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) =>
            a.Item1 != b.Item1 ? a.Item1.CompareTo(b.Item1) : a.Item2.CompareTo(b.Item2)));

        latestTimestamp = 0;
    }

    public void Update(int timestamp, int price)
    {
        // If timestamp already exists, remove old values from heaps
        if (timestamps.ContainsKey(timestamp))
        {
            int oldPrice = timestamps[timestamp];
            maxHeap.Remove((oldPrice, timestamp));
            minHeap.Remove((oldPrice, timestamp));
        }

        // Update dictionary
        timestamps[timestamp] = price;
        latestTimestamp = Math.Max(latestTimestamp, timestamp);

        // Insert new values into heaps
        maxHeap.Add((price, timestamp));
        minHeap.Add((price, timestamp));
    }

    public int Current()
    {
        return timestamps[latestTimestamp];
    }

    public int Maximum()
    {
        return maxHeap.First().Item1;  // Fix: Use Item1 for price
    }

    public int Minimum()
    {
        return minHeap.First().Item1;  // Fix: Use Item1 for price
    }
}
