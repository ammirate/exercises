using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati.Liste.Exercise {
    /// <summary>
    /// L'algoritmo merge sort è un algoritmo di ordinamento che ordina una
    /// sequenza di elementi ricorsivamente nel modo seguente:
    /// 1. divide la sequenza in due sequenze non ordinate, ciascuna avente taglia
    ///    circa la metà della sequenza originale;
    /// 2. ordina separatamente ciascuna delle due sequenze;
    /// 3. fonde le due sequenze ordinate in un'unica sequenza ordinata
    /// </summary>
    public class MergeSorter {

        public static void MergeSort(ArrayList<int> list) {
            int n = list.size();
            if (n < 2) return;
            ArrayList<int> l1 = new ArrayList<int>();
            ArrayList<int> l2 = new ArrayList<int>();

            for (int i = 0; i < n / 2; i++) {
                l1.add(list.remove(list.size() - 1));
            }

            for (int i = n/2; i < n; i++) {
                l2.add(list.remove(list.size() - 1));
            }

            MergeSort(l1);
            MergeSort(l2);
            merge(l1, l2, list);
        }


        private static void merge(ArrayList<int> L1, ArrayList<int> L2, ArrayList<int> LIST) {
            while (!L1.isEmpty() && !L2.isEmpty()) {
                if (L1.get(0) < L2.get(0)) {
                    LIST.add(L1.remove(0));
                } else {
                    LIST.add(L2.remove(0));
                }
            }

            while (!L1.isEmpty()) {
                LIST.add(L1.remove(0));
            }

            while (!L2.isEmpty()) {
                LIST.add(L2.remove(0));
            }
        }

        public static void run() {

            ArrayList<int> V = new ArrayList<int>();
            V.add(5);
            V.add(2);
            V.add(10);
            V.add(24);
            V.add(1);
            V.add(21);
            MergeSort(V);
            for (int i = 0; i < V.size(); i++)
                Console.WriteLine(V.get(i));
            System.Console.ReadKey();
        }


    }
}
