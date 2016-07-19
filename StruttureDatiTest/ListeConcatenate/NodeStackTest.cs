using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StruttureDati.ListeConcatenate;

namespace StruttureDatiTest.ListeConcatenate {
    /// <summary>
    /// Descrizione del riepilogo per NodeStackTest
    /// </summary>
    [TestClass]
    public class NodeStackTest {

        NodeStack<int> S;

        #region Attributi di test aggiuntivi
        //
        // È possibile utilizzare i seguenti attributi aggiuntivi per la scrittura dei test:
        //
        // Utilizzare ClassInitialize per eseguire il codice prima di eseguire il primo test della classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilizzare ClassCleanup per eseguire il codice dopo l'esecuzione di tutti i test della classe
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilizzare TestInitialize per eseguire il codice prima di eseguire ciascun test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilizzare TestCleanup per eseguire il codice dopo l'esecuzione di ciascun test
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestInitialize]
        public void initialize() {
            S = new NodeStack<int>();
        }


        [TestMethod]
        public void TestIsEmpty() {
            Assert.IsTrue(S.isEmpty());
        }

        [TestMethod]
        public void TestSize() {
            Assert.AreEqual(0, S.size());
        }

        [TestMethod]
        public void TestPush() {
            for (int i = 0; i < 10; i++) {
                S.push(i);
                Assert.AreEqual(i, S.top());
            }
            Assert.AreEqual(10, S.size());
        }

        [TestMethod]
        public void TestTop() {
            S.push(5);
            Assert.AreEqual(5, S.top());

            S.push(10);
            Assert.AreEqual(10, S.top());
        }

        [TestMethod]
        public void TestPop() {
            InvalidOperationException captured = null;
            try {
                S.pop();
            } catch (InvalidOperationException e) {
                captured = e;
            }

            Assert.IsNotNull(captured);

            S.push(5);
            S.push(10);

            int el = S.pop();
            Assert.AreEqual(10, el);
            Assert.AreEqual(1, S.size());
            Assert.AreEqual(5, S.top());
        }

        
    }
}
