using System;


/**
  function insertionSort(array A)
     for i ← 1 to length[A] do
        value ← A[i]
        j ← i-1
        while j >= 0 and A[j] > value do
            A[j + 1] ← A[j]
            j ← j-1
        A[j+1] ← value
*/


public class InsertionSort {

    public static void insertionSort(ArrayList<int> V) {
        for (int i = 1; i < V.size(); i++) {
            int value = V.get(i);
            int j = i - 1;

            while (j >= 0 && V.get(j) > value) {
                V.set(V.get(j), j + 1);
                j--;
            }
            V.set(value, j + 1);
        }
    }


    public static void run() {

        ArrayList<int> V = new ArrayList<int>();
        V.add(10);
        V.add(20);
        V.add(30);
        V.add(24);
        V.add(36);
        V.add(21);
        insertionSort(V);
        for (int i = 0; i < V.size(); i++)
            Console.WriteLine(V.get(i));
        System.Console.ReadKey();
    }

}

