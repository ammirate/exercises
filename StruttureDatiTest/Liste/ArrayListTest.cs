using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StruttureDatiTest.Liste {
    /// <summary>
    /// Descrizione del riepilogo per ArrayListTest
    /// </summary>
    [TestClass]
    public class ArrayListTest {

        ArrayList<int> A;

        [TestInitialize]
        public void init() {
            A = new ArrayList<int>();
        }

        
        [TestMethod]
        public void sizeTest() {
            Assert.AreEqual(0, A.size());
        }

        [TestMethod]
        public void isEmptyTest() {
            Assert.IsTrue(A.isEmpty());
        }

        [TestMethod]
        public void addTest1() {
            for(int i = 0; i < 5; i++) {
                A.add(i);
            }
            Assert.AreEqual(5, A.size());
        }


        [TestMethod]
        public void getTest() {
            A.add(1);
            Assert.AreEqual(1, A.get(0));

            A.add(2);
            Assert.AreEqual(2, A.get(1));

            A.add(3);
            Assert.AreEqual(3, A.get(2));

            Exception captured = null;

            try {
                A.get(A.size());
            } catch(IndexOutOfRangeException e) {
                captured = e;
            }
            Assert.IsNotNull(captured);

            try {
                A.get(-1);
            } catch (IndexOutOfRangeException e) {
                captured = e;
            }
            Assert.IsNotNull(captured);
        }


        [TestMethod]
        public void addTest2() {
            for(int i = 0; i < 22; i++) {
                A.add(i);
            }

            A.add(-5, 10);
            Assert.AreEqual(-5, A.get(10));

            A.add(-5, 20);
            Assert.AreEqual(-5, A.get(20));

            A.add(-5, A.size() - 1);
            Assert.AreEqual(-5, A.get(A.size() - 2));
        }


        [TestMethod]
        public void setTest() {
            Exception captured = null;
            try {
                A.set(-1, 0);
            } catch (IndexOutOfRangeException e) {
                captured = e;
            }
            Assert.IsNotNull(captured);


            A.add(5);
            A.add(6);
            int res = A.set(-1, 1);
            Assert.AreEqual(6, res);
            Assert.AreEqual(-1, A.get(1));
            Assert.AreEqual(2, A.size());
        }


        [TestMethod]
        public void removeTest() {
            for (int i = 0; i < 50; i++) {
                A.add(i);
            }

            for (int i = 0; i < 50; i++) {
                A.remove(0);
            }

            Exception captured = null;
            try {
                A.remove(0);
            } catch(IndexOutOfRangeException e) {
                captured = e;
            }
            Assert.IsNotNull(captured);
        }
    }
}
