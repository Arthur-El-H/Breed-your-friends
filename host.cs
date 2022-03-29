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

    private int yearsPassed;
    private const int maxYearsToPass = 5;

    public void initHost(marriageMarket newMarriageMarket, breeder newBreeder)
    {
        marriageMarket = newMarriageMarket;
        breeder = newBreeder;
    }

    private bool isMoreYearsAvailable()
    {
        if ( yearsPassed < maxYearsToPass)
        {
            return true;
        }
        yearsPassed++;
        Debug.Log("Enough years have passed. Marry already!");
        return false;
    }

    public void gainWealth()
    {
        if (!isMoreYearsAvailable()) return;
        Debug.Log("gaining wealth");
        wealth += 30;
        wealth *= 1.3;
    }

    public void gainAcquaintances()
    {
        if (!isMoreYearsAvailable()) return;
        Debug.Log("gaining Acquaintances");
        marriageMarket.enlargeMarket();
    }

    public void workout()
    {
        if (!isMoreYearsAvailable()) return;
        Debug.Log("working out");
        attractivity *= 1.4;
    }

    public void getPlasticSurgery()
    {
        if (!isMoreYearsAvailable()) return;
        Debug.Log("getting surgery");
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
