using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


[TestClass]
public class LinkedTreeTest {

    private LinkedTree<int> T;

    [TestInitialize]
    public void init() {
        T = new LinkedTree<int>();
    }

    [TestMethod]
    public void TestIsEmpty() {
        Assert.IsTrue(T.isEmpty());
    }

    [TestMethod]
    public void TestIsSize() {
        Assert.AreEqual(0, T.size());
    }

    [TestMethod]
    public void TestRoot() {
        T.addRoot(0);
        Assert.AreEqual(1, T.size());

        Exception captured = null;
        try {
            T.addRoot(1);
        } catch (Exception e) {
            captured = e;
        }
        Assert.IsNotNull(captured);

        Assert.IsNotNull(T.root());
        Assert.AreEqual(0, T.root().element());
    }



    [TestMethod]
    public void TestChildren() {
        T.addRoot(0);
        IPosition<int> root = T.root();

        Exception captured = null;
        try { T.children(root); } catch (InvalidOperationException e) { captured = e; }
        Assert.IsNotNull(captured);

        T.insertChild(root, 1);
        Assert.IsNotNull(T.children(root));
    }


    [TestMethod]
    public void TestEnumerable() {
        T.addRoot(0);
        T.insertChild(T.root(), 1);
        T.insertChild(T.root(), 2);
        T.insertChild(T.root(), 3);
        T.insertChild(T.root(), 4);

        IEnumerator<int> el = T.iterator();
        IEnumerable<IPosition<int>> pos = T.positions();

        foreach (IPosition<int> p in pos) {
            Assert.AreEqual(p.element(), el.Current);
        }
    }


    [TestMethod]
    public void depth() {
        T.addRoot(0);
        IPosition<int> temp = T.root();
        for (int i = 0; i < 10; i++) {
            temp = T.insertChild(temp, i);
        }
        Assert.AreEqual(10, T.depth(temp));
    }


    [TestMethod]
    public void TestNumberLeaves() {
        T.addRoot(0);
        Assert.AreEqual(1, T.numberLeaves(T, T.root()));

        for (int i = 0; i < 10; i++) {
            T.insertChild(T.root(), i);
        }
        Assert.AreEqual(10, T.numberLeaves(T, T.root()));
    }



    [TestMethod]
    public void TestAncestor() {
        T.addRoot(0);
        IPosition<int> p1 = T.insertChild(T.root(), 1);
        IPosition<int> p11 = T.insertChild(p1, 1);

        IPosition<int> p2 = T.insertChild(T.root(), 10);


        Assert.IsTrue(T.ancestor(T.root(), T.root()));
        Assert.IsTrue(T.ancestor(T.root(), p1));
        Assert.IsTrue(T.ancestor(T.root(), p11));
        Assert.IsTrue(T.ancestor(T.root(), p2));

        Assert.IsTrue(T.ancestor(p1, p11));
        Assert.IsFalse(T.ancestor(p1, p2));//p1 is sibling of p3
    }



    [TestMethod]
    public void TestLca() {
        T.addRoot(0);
        IPosition<int> p1 = T.insertChild(T.root(), 1);
        IPosition<int> p11 = T.insertChild(p1, 1);
        IPosition<int> p2 = T.insertChild(T.root(), 10);

        Assert.AreEqual(T.root(), T.lca(T.root(), T.root()));
        Assert.AreEqual(T.root(), T.lca(T.root(), p1));
        Assert.AreEqual(T.root(), T.lca(T.root(), p11));

        Assert.AreEqual(p1, T.lca(p1, p11));
        Assert.AreEqual(T.root(), T.lca(p11, p2));
    }

}

