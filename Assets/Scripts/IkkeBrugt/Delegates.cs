using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Delegates : MonoBehaviour
{
    //lampda funktion er en funktion uden et navn = delegates?

    public delegate void ThingyDoer(int item);

    public static void DoStuff()
    {
        var list = new List<int> { 1,2,3};
       
        //tager input data og laver det om til noget andet
        list.Select(x => x + 1);//Select g�r at den g�r det ved hver item i datas�ttet, den funktion der st�r i parentes er en lampda funktion     det bliver lavet til en ny liste
        list.Where(x => x > 1); //Where v�lger alle dem hvor at statement er true

        DoStuffWithItems(list, x => Console.WriteLine(x));
    }

    static void DoStuffWithItems(List<int> items, Action<int> doer)
    {
        foreach (var item in items)
        {
            doer.Invoke(item);
        }
    }

    //Action = den retunere ikke noget(void)
}
