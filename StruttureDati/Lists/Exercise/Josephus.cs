using System;


/*
    Ci sono N persone disposte in circolo in attesa di essere giustiziate. Partendo
    da una persona scelta a caso e procedendo in senso orario, il boia salta k − 1
    persone, raggiunge la k-esima persona, la giustizia e la elimina dal gruppo.
    Si saltano ancora le k − 1 persone successive e si giustizia la k-esima. Le
    esecuzioni proseguono in questo modo, finché non rimane una sola persona,
    che viene graziata.

    Dati n e k, scrivere un metodo che, usando una coda, determini la posizione della
    persona graziata all'interno del cerchio di partenza.
*/
class Josephus {

    static void Main1() {
        Console.WriteLine("The saved boy will be..." + josephus(500, 15));
        System.Console.ReadKey();
    }


    private static Queue<int> Q;

    public static int josephus(int n, int k) {
        // init
        Q = new Queue<int>(n);
        for (int i = 1; i <= n; i++) {
            Q.enqueue(i);
        }

        do {
            // jump the lucky guy, putting it in the queue again :)
            for (int i = 0; i < k - 1; i++) {
                Q.enqueue(Q.dequeue());
            }
            // kill the unlucky guy :(
            Q.dequeue();
        } while (Q.size() > 1);


        return Q.frontEl(); // saved guy ^^
    }


    private static int next(int i, int size) {
        return (i + 1) % size;
    }

}

