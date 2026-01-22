// PriorityQueue_Tests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items; Dequeue returns highest priority item first
    // Expected Result: Dequeue returns "high", then "medium", then "low"
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("medium", 5);
        priorityQueue.Enqueue("high", 10);

        var dequeued = priorityQueue.Dequeue();
        Assert.AreEqual("high", dequeued, "Dequeue should return the highest priority item.");

        dequeued = priorityQueue.Dequeue();
        Assert.AreEqual("medium", dequeued, "Next dequeue returns the next highest priority item.");

        dequeued = priorityQueue.Dequeue();
        Assert.AreEqual("low", dequeued, "Last dequeue returns the lowest priority item.");
    }

    [TestMethod]
    // Scenario: Dequeue from empty PriorityQueue should throw exception
    // Expected Result: InvalidOperationException thrown
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}

