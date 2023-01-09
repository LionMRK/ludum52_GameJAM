using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Configs;

public class PlantCards : Cards
{
    public int ID;
    public int energy;
    public int good_value;
    public int bad_value;
    public int odd;
    public Type type;
    public bool is_multiplier;


    public int CalcOdd()
    {
        int random;
        random = Random.Range(1, 11);

        Hability();

        if(random <= odd)
        {
            return good_value;
        }

        return bad_value;
    }

    public virtual void Hability()
    {

    }

    public Type GetTypeCard()
    {
        return type;
    }

}
