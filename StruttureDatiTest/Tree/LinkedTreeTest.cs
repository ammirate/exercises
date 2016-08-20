using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StruttureDati.Tree;
using StruttureDati.ListeConcatenate;
using System.Collections.Generic;

namespace StruttureDatiTest.Tree {
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


    }
}
