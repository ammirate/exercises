using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati.Liste {

    [SerializableAttribute]
    public class Stack<T> : IStack<T> {

        private int SIZE = 5;
        private T[] stack;
        private int head;

        public Stack() {
            stack = new T[SIZE];
            head = -1;
        }

        public bool isEmpty() {
            return head < 0;
        }

        public T pop() {
            if (isEmpty()) {
                throw new InvalidOperationException("Cannot pop empty stack");
            }
            T toReturn = stack[head];
            stack[head] = default(T);
            head--;
            return toReturn;
        }

        public void push(T element) {
            if (head == stack.Length - 1) {
                enlargeStack();
            }
            head++;
            stack[head] = element;
        }

        public int size() {
            return head + 1;
        }

        public T top() {
            if (isEmpty()) {
                throw new InvalidOperationException("Stack is empty");
            }
            return stack[head];
        }


        private void enlargeStack() {
            T[] newStack = new T[stack.Length * 2];
            for (int i = 0; i < stack.Length; i++) {
                newStack[i] = stack[i];
            }
            stack = newStack;
            newStack = null;
        }

        public string toString() {
            String s = "[";
            for (int i = 0; i < stack.Length; i++) {
                if (stack[i] == null) break;
                s += stack[i];
                s += " | ";
            }
            return s;
        }
    }
}
