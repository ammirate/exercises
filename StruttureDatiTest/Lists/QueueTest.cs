using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


/// <summary>
/// Descrizione del riepilogo per QueueTest
/// </summary>
[TestClass]
public class QueueTest {

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

    private Queue<int> queue;

    [TestInitialize]
    public void MyTestInitialize() {
        queue = new Queue<int>();
    }


    [TestMethod]
    public void ConstructorTest() {
        Assert.IsNotNull(queue);
    }

    [TestMethod]
    public void IsEmptyTest() {
        Assert.IsTrue(queue.isEmpty());
    }


    [TestMethod]
    public void SizeTest() {
        Assert.AreEqual(0, queue.size());
    }


    [TestMethod]
    public void EnqueueTest() {

        for (int i = 0; i < 5; i++) { // 5 is the max size in test
            queue.enqueue(i);
        }
        Assert.AreEqual(5, queue.size());

        Exception captured = null;
        try {
            queue.enqueue(0);
        } catch (Exception e) {
            captured = e;
        }
        Assert.IsNotNull(captured);
    }


    [TestMethod]
    public void FrontTest() {
        queue.enqueue(5);
        Assert.AreEqual(5, queue.frontEl());

        queue.enqueue(8);
        Assert.AreEqual(5, queue.frontEl());
    }


    [TestMethod]
    public void DequeueTest() {
        queue.enqueue(5);
        Assert.AreEqual(5, queue.frontEl());

        int front = queue.dequeue();
        Assert.AreEqual(5, front);

        Assert.IsTrue(queue.isEmpty());
    }


    [TestMethod]
    public void globalTest() {
        for (int i = 0; i < 10; i++) {
            queue.enqueue(i);
            queue.dequeue();
        }
        Assert.IsTrue(queue.isEmpty());
    }
}
