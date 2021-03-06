﻿using System;
using System.Collections.Generic;


/*
Inserimento e cancellazione avvengono secondo una
strategia FIFO (first in first out):
- Inserimento: un nuovo oggetto viene inserito dietro la coda
- Cancellazione: viene cancellato sempre l'oggetto davanti alla coda
*/
public interface IQueue<T> {

    int size();

    bool isEmpty();

    void enqueue(T element);

    T dequeue();

    T frontEl();

}

