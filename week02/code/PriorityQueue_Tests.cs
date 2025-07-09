using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities and dequeue all.
    // Expected Result: Dequeue returns the items in order of highest to lowest priority: C, B, A.
    // Defect(s) Found: The highest priority item (C) was not dequeued first. Dequeue did not return items in order of highest to lowest priority.
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 3);
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with the same highest priority, ensure FIFO order is preserved for ties.
    // Expected Result: Dequeue returns the first enqueued item with the highest priority first.
    // Defect(s) Found: FIFO order for items with the same highest priority is not preserved. Dequeue returned C before A, even though A was enqueued first.
    public void TestPriorityQueue_FIFOTieBreaker()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 5);
        Assert.AreEqual("A", pq.Dequeue()); // A and C have highest priority, A was first
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue and dequeue interleaved, check order and priorities.
    // Expected Result: Dequeue returns highest priority, FIFO for ties, and works after interleaving.
    // Defect(s) Found: Dequeue did not always return the highest priority item after interleaving. The order of dequeued items was incorrect.
    public void TestPriorityQueue_Interleaved()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        Assert.AreEqual("B", pq.Dequeue());
        pq.Enqueue("C", 2);
        pq.Enqueue("D", 3);
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: Exception message does not match exactly. Expected "Queue is empty.", but got "The queue is empty."
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("Queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }

    // Add more test cases as needed below.
}