using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class PriorityQueueTest {

    private IPriorityQueue<int,int> Q;

    [TestInitialize]
    public void init() {
        Q = new SortedListPriorityQueue<int, int>();
    }


    [TestMethod]
    public void size() {
        Assert.AreEqual(0, Q.size());
    }


    [TestMethod]
    public void isEmpty() {
        Assert.IsTrue(Q.isEmpty());
    }

    [TestMethod]
    public void min() {
        Exception captured = null;
        try {
            Q.min();
        } catch(InvalidOperationException e) {
            captured = e;
        }

        Assert.IsNotNull(captured);
    }


    [TestMethod]
    public void removeMin() {
        Exception captured = null;
        try {
            Q.removeMin();
        } catch (InvalidOperationException e) {
            captured = e;
        }

        Assert.IsNotNull(captured);
    }


    [TestMethod]
    public void global() {

        Q.insert(4, 4);
        Q.insert(0, 0);
        Q.insert(1, 1);
        Q.insert(3, 3);
        Q.insert(2, 2);

        Assert.AreEqual(0, Q.removeMin().value);
        Assert.AreEqual(1, Q.removeMin().value);
        Assert.AreEqual(2, Q.removeMin().value);
        Assert.AreEqual(3, Q.removeMin().value);
        Assert.AreEqual(4, Q.removeMin().value);
        Assert.IsTrue(Q.isEmpty());
    }

}