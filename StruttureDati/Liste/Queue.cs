using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati.Liste {

    /*
        Implementa una coda circolare
    */
    public class Queue<T> : IQueue<T> {

        private int SIZE = 5;
        private int dim;
        private int items;
        private T[] queue;
        private int front, rear;


        public Queue(int size) {
            dim = size;
            queue = new T[size];
            front = rear = 0;
            items = 0;
        }

        // extends the previous constructor
        public Queue() : this(5) {
       
        }

 
        public bool isEmpty() {
            return rear == front && items == 0;
        }

        public int size() {
            return items;
        }

        public T dequeue() {
            if (isEmpty()) {
                throw new InvalidOperationException("Que is empty");
            }
            T toReturn = queue[front];
            queue[front] = default(T);
            front = circularIncrement(front);
            items--;
            return toReturn;
        }

        public void enqueue(T element) {
            if (items == dim) {
                throw new InvalidOperationException("Queue is full");
            }
            queue[rear] = element;
            items++;
            rear = circularIncrement(rear);
        }

        public T frontEl() {
            if (isEmpty()) {
                throw new InvalidOperationException("Que is empty");
            }
            return queue[front];
        }


        private int circularIncrement(int var) {
            return var = (var + 1) % dim; 
        }
    }
}
