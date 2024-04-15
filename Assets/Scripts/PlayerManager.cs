using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int coins = 1000;
    private int numOfItem1 = 0;
    private int numOfItem2 = 0;
    private int numOfItem3 = 0;

    private int costOfItem1 = 10;
    private int costOfItem2 = 20;
    private int costOfItem3 = 30;

    private void Start()
    {
        
    }

    public void buyItem1()
    {
        if(coins >= costOfItem1)
        {
            numOfItem1++;
            coins -= costOfItem1;
            print("Item1 purchased. You have " + numOfItem1.ToString()
                + " Item1 and " + coins.ToString() + " coins.");
        }
        else
        {
            print("Not enough coins");
        }
    }

    public void buyItem2()
    {
        if (coins >= costOfItem2)
        {
            numOfItem2++;
            coins -= costOfItem2;
            print("Item2 purchased. You have " + numOfItem2.ToString()
                + " Item2 and " + coins.ToString() + " coins.");
        }
        else
        {
            print("Not enough coins");
        }
    }

    public void buyItem3()
    {
        if (coins >= costOfItem3)
        {
            numOfItem3++;
            coins -= costOfItem3;
            print("Item3 purchased. You have " + numOfItem3.ToString()
                + " Item3 and " + coins.ToString() + " coins.");
        }
        else
        {
            print("Not enough coins");
        }
    }
}
