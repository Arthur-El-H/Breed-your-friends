using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class host: MonoBehaviour
{
    private marriageMarket marriageMarket;
    private person currentHost;
    private breeder breeder;
    private double wealth = 100;
    private double attractivity;
    private readonly double fuckingSuperAttractive = 100000000000;

    public void initHost(marriageMarket newMarriageMarket, breeder newBreeder)
    {
        marriageMarket = newMarriageMarket;
        breeder = newBreeder;
    }

    public void gainWealth()
    {
        wealth += 30;
        wealth *= 1.3;
    }

    public void gainAcquaintances()
    {
        marriageMarket.enlargeMarket();
    }

    public void workout()
    {
        attractivity *= 1.4;
    }

    public void getPlasticSurgery()
    {
        if (wealth > 1000)
        {
            attractivity = fuckingSuperAttractive;
            wealth = 100;
        }
        else
        {
            //TODO nicht genug Geld irgendwie zurückmelden.
        }
    }

    public void mate(person mate)
    {
        Debug.Log("pls marry me");
        nestIn(breeder.breedPerson(currentHost, mate));
    }

    internal void nestIn(person person)
    {
        currentHost = person;
    }
}
