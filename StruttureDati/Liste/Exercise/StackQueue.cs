using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
Si scriva una classe StackQueue che implementi l'interfaccia Queue
usando due stack.
*/
namespace StruttureDati.Liste.Exercise {

    public class StackQueue<T> : IQueue<T> {

        private IStack<T> S, SHelp;

        public StackQueue(int size) {
            S = new Stack<T>();
            SHelp = new Stack<T>();

        }

        public bool isEmpty() {
            return S.isEmpty();
        }

        public int size() {
            return S.size();
        }


        public void enqueue(T element) {
            revert();
            SHelp.push(element);
            revert();
        }

        public T dequeue() {
            try {
                return S.pop();
            }catch (Exception e) {
                throw new InvalidOperationException("Queue is empty");
            }

        }

        

        public T frontEl() {
            try {
                return S.top();
            } catch (Exception e) {
                throw new InvalidOperationException("Queue is empty");
            }
        }

        /**
        * If S contains all data and SHelp is empty, transfers all data to SHelp.
        * Vice versa, transfer all data from SHelp to S.
        */
        private void revert() {

            IStack<T> source, dest;
            source = SHelp.isEmpty() ? S : SHelp;
            dest = SHelp.isEmpty() ? SHelp : S;

            while (!source.isEmpty()) {
                dest.push(source.pop());
            }
        }


    }

}
