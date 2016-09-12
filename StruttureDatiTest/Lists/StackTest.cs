using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class StackTest {

    private Stack<int> stack;

    [TestMethod]
    public void ConstructorTest() {
        stack = new Stack<int>();
        Assert.IsNotNull(stack);
        Console.WriteLine("Constructor success");
    }

    [TestMethod]
    public void isEmptyTest() {
        stack = new Stack<int>();
        Assert.IsTrue(stack.isEmpty());
        Console.WriteLine("isEmpty success");
    }


    [TestMethod]
    public void sizeTest() {
        stack = new Stack<int>();
        Assert.AreEqual(stack.size(), 0);
        Console.WriteLine("Size success");
    }

    [TestMethod]
    public void pushTest() {
        stack = new Stack<int>();
        stack.push(1);
        Assert.IsTrue(stack.size() == 1);

        for (int i = 0; i < 10; i++) {
            stack.push(i);
        }

        Assert.IsTrue(stack.size() == 11);
        Console.WriteLine("Push success");
    }



    [TestMethod]
    public void topTest() {
        stack = new Stack<int>();
        stack.push(5);
        Assert.AreEqual(5, stack.top());

        stack = new Stack<int>();
        Exception expected = null;
        try {
            stack.top();
        } catch (Exception e) {
            expected = e;
        }

        Assert.IsNotNull(expected);
        Console.WriteLine("Top success");
    }


    [TestMethod]
    public void popTest() {
        stack = new Stack<int>();
        stack.push(1);
        Assert.AreEqual(stack.pop(), 1);

        Exception expected = null;
        try {
            stack.pop();
        } catch (Exception e) {
            expected = e;
        }
        Assert.IsNotNull(expected);
        Console.WriteLine("Pop success");
    }

}
