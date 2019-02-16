using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLSave : MonoBehaviour
{
    private List<bool> choises;
    private int choise = 0;
        
    private void Start()
    {
        choises = new List<bool>(10);
        for(int i = 0;i<10;i++)
            choises.Add(false);
        clear();
    }

    public void clear()
    {
        for (int i = 0; i < 10; i++)
            choises[i] = false;
        choise = 0;
    }

    public void makeChoise(int ind)
    {
        choises[ind-1] = true;
        if (getBoolsCount() == 1)
            choise = ind;
    }

    public void getEnding(out int ind, out bool result)
    {
        int count = getBoolsCount();
        
        switch (count)
        {
            // good all persons ending
            case 10:
                ind = 0;
                result = true;
                break;
            // zero ending
            case 0:
                ind = 0;
                result = false;
                break;
            // good ending
            case 1:
                ind = choise;
                result = true;
                break;
            // bad ending
            default:
                ind = choise;
                result = false;
                break;
        }
    }

    private int getBoolsCount()
    {
        int count = 0;
        for (int i = 0; i < 10; i++)
        {
            if (choises[i])
                count++;
        }

        return count;
    }
}
