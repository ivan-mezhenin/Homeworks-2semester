// <copyright file="PriorityQueueTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Test1.Tests;

public class Tests
{
    [Test]
    public void PriorityQueue_Enqueue_AddValueWithDifferentPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(1, 1);
        priorityQueue.Enqueue(3, 2);
        priorityQueue.Enqueue(10, 3);
        
        Assert.That(priorityQueue.Dequeue(), Is.EqualTo(10));
    }

    [Test]
    public void PriorityQueue_Enqueue_AddValueWithSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(10, 1);
        priorityQueue.Enqueue(3, 2);
        priorityQueue.Enqueue(1, 2);
        
        Assert.That(priorityQueue.Dequeue(), Is.EqualTo(3));
    }

    [Test]
    public void PriorityQueue_Dequeue_AddNewValuesWithDifferentPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(1, 1);
        priorityQueue.Enqueue(3, 2);
        priorityQueue.Enqueue(10, 3);

        List<int> result = [];
        for (var _ = 0; _ < 3; ++_)
        {
            result.Add(priorityQueue.Dequeue());
        }
        
        Assert.That(result, Is.EquivalentTo((int[]) [10, 3 , 1]));
    }

    [Test]
    public void PriorityQueue_Dequeue_AddNewValuesWithSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(1, 20);
        priorityQueue.Enqueue(2, 20);
        priorityQueue.Enqueue(3, 20);
        priorityQueue.Enqueue(4, 20);
        
        List<int> result = [];
        for (var _ = 0; _ < 4; ++_)
        {
            result.Add(priorityQueue.Dequeue());
        }
        
        Assert.That(result, Is.EquivalentTo((int[]) [1, 2, 3, 4]));
    }

    [Test]
    public void PriorityQueue_Empty_ShouldReturnTrue()
    {
        var priorityQueue = new PriorityQueue();
        
        Assert.That(priorityQueue.Empty, Is.True);
    }
    
    [Test]
    public void PriorityQueue_Empty_ShouldReturnFalse()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue(1, 1);
        
        Assert.That(priorityQueue.Empty, Is.False);
    }

    [Test]
    public void PriorityQueue_Dequeue_ShouldCatchException()
    {
        var priorityQueue = new PriorityQueue();
        
        Assert.Throws<EmptyEnqueueException>(() => priorityQueue.Dequeue());
    }
}