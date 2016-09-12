using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;



[TestClass]
public class DequeTest {

    Deque<int> D;

    [TestInitialize]
    public void init() {
        D = new Deque<int>();
    }

    [TestMethod]
    public void sizeTest() {
        Assert.AreEqual(0, D.size());
    }

    [TestMethod]
    public void isEmptyTest() {
        Assert.IsTrue(D.isEmpty());
    }


    [TestMethod]
    public void getFirstTest() {
        InvalidOperationException captured = null;
        try {
            D.getFirst();
        } catch (InvalidOperationException e) {
            captured = e;
        }
        Assert.IsNotNull(captured);

        D.addFirst(1);
        Assert.AreEqual(1, D.getFirst());
    }

    [TestMethod]
    public void getFirstTest1() {
        D.addLast(1);
        Assert.AreEqual(1, D.getFirst());
    }

    [TestMethod]
    public void getLastTest() {
        InvalidOperationException captured = null;
        try {
            D.getLast();
        } catch (InvalidOperationException e) {
            captured = e;
        }
        Assert.IsNotNull(captured);

        D.addLast(1);
        Assert.AreEqual(1, D.getLast());
    }

    [TestMethod]
    public void getLastTest1() {
        D.addFirst(1);
        Assert.AreEqual(1, D.getLast());
    }

    [TestMethod]
    public void addFirstTest() {

        for (int i = 0; i < 10; i++) {
            D.addFirst(i);
            Assert.IsFalse(D.isEmpty());
            Assert.AreEqual(i + 1, D.size());

            Assert.AreEqual(i, D.getFirst());
        }
    }

    [TestMethod]
    public void addLastTest() {
        for (int i = 0; i < 10; i++) {
            D.addLast(i);
            Assert.IsFalse(D.isEmpty());
            Assert.AreEqual(i + 1, D.size());

            Assert.AreEqual(i, D.getLast());
        }
    }



    [TestMethod]
    public void removeFirstTest() {
        D.addFirst(0);
        D.addFirst(1);

        int res = D.removeFirst();
        Assert.AreEqual(1, res);
    }

    [TestMethod]
    public void removeFirstTest1() {
        D.addLast(0);
        D.addLast(1);

        int res = D.removeFirst();
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void removeLastTest() {
        D.addLast(0);
        D.addLast(2);
        D.addLast(1);

        int res = D.removeLast();
        Assert.AreEqual(1, res);

        res = D.removeLast();
        Assert.AreEqual(2, res);
    }


    [TestMethod]
    public void removeLastTest1() {
        D.addLast(0);
        D.addLast(1);

        int res = D.removeLast();
        Assert.AreEqual(1, res);

        res = D.removeLast();
        Assert.AreEqual(0, res);
    }
}

