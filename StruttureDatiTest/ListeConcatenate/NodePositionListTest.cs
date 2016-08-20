using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StruttureDati.ListeConcatenate;
using System.Collections.Generic;

namespace StruttureDatiTest.ListeConcatenate {
    [TestClass]
    public class NodePositionListTest {

        private NodePositionList<int> L;

        [TestInitialize]
        public void init() {
            L = new NodePositionList<int>();
        }

        [TestMethod]
        public void isEmptyTest() {
            Assert.IsTrue(L.isEmpty());
        }

        [TestMethod]
        public void sizeTest() {
            Assert.AreEqual(0, L.size());
        }

        [TestMethod]
        public void addFirstTest() {
            L.addFirst(5);
            Assert.IsFalse(L.isEmpty());
            Assert.AreEqual(1, L.size());
            Assert.AreEqual(5, L.first().element());
            Assert.AreEqual(5, L.last().element());

            L.addFirst(10);
            Assert.AreEqual(2, L.size());
            Assert.AreEqual(10, L.first().element());
            Assert.AreEqual(5, L.last().element());
        }


        [TestMethod]
        public void addLastTest() {
            L.addLast(5);
            Assert.IsFalse(L.isEmpty());
            Assert.AreEqual(1, L.size());
            Assert.AreEqual(5, L.first().element());
            Assert.AreEqual(5, L.last().element());

            L.addLast(10);
            Assert.AreEqual(2, L.size());
            Assert.AreEqual(5, L.first().element());
            Assert.AreEqual(10, L.last().element());
        }

        [TestMethod]
        public void addAfterTest() {
            L.addLast(1);
            L.addLast(2);
            L.addLast(3);

            L.addAfter(L.first(), 5);
            DNode<int> first = (DNode<int>)L.first();
            Assert.AreEqual(5, first.getNext().element());
            Assert.AreEqual(5, first.getNext().getNext().getPrev().element());
        }


        [TestMethod]
        public void addBeforeTest() {
            L.addLast(1);
            L.addLast(2);
            L.addLast(3);

            L.addBefore(L.first(), 5);
            Assert.AreEqual(5, L.first().element());

            L.addBefore(L.last(), 10);
            Assert.AreEqual(10, L.prev(L.last()).element());
        }


        [TestMethod]
        public void removeTest() {
            L.addLast(1);
            L.addLast(2);
            L.addLast(3);

            L.remove(L.first());
            Assert.AreEqual(2, L.first().element());

            L.remove(L.first());
            Assert.AreEqual(3, L.first().element());
        }


        [TestMethod]
        public void setTest() {
            L.addLast(1);
            L.addLast(2);
            L.addLast(3);

            L.set(L.first(), 10);
            Assert.AreEqual(10, L.first().element());
        }


        [TestMethod]
        public void EnumeratorTest() {
            L.addLast(1);
            L.addLast(2);
            L.addLast(3);
            L.addLast(4);
            L.addLast(5);
            IPosition<int> node = L.first();

            IEnumerator<int> enumerator = L.GetEnumerator();
            while (enumerator.MoveNext()) {
                Assert.AreEqual(node.element(), enumerator.Current);
                node = L.next(node);
            }
        }
    }
}
