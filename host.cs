using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class host: MonoBehaviour
{
    private marriageMarket marriageMarket;
    public person currentHost; //TODO private
    private breeder breeder;
    private double wealth = 100;
    private double attractivity;
    private readonly double fuckingSuperAttractive = 100000000000;
    public personTester breedTest;


    private int acquaintancesGainedForCurrentHost;
    private int maxTimesToGainAcquaintances = 2;
    private int yearsPassed;
    private const int maxYearsToPass = 5;

    public void initHost(marriageMarket newMarriageMarket, breeder newBreeder, personTester breedTester)
    {
        marriageMarket = newMarriageMarket;
        breeder = newBreeder;
        breedTest = breedTester;
    }

    private bool isMoreYearsAvailable()
    {
        if ( yearsPassed < maxYearsToPass)
        {
            yearsPassed++;
            return true;
        }
        Debug.Log("Enough years have passed. Marry already!");
        return false;
    }

    private bool CheckForLoss(List<person> potentialMates)
    {
        foreach (person mate in potentialMates)
        {
            if (marriageMarket.hyptheticallyPropose(this.currentHost, mate)) return false;
        }
        return true;
    }

    public void gainWealth()
    {
        if (!isMoreYearsAvailable())
        {
            CheckForLoss(marriageMarket.getAllCurrentlyAvailableMates());
            return;
        }

        Debug.Log("gaining wealth");
        wealth += 30;
        wealth *= 1.3;
    }

    public void gainAcquaintances()
    {
        // TODO: For now, order of ifs is important, bc isMoreYearsAvailable() adds to passing years... Change that to seperate method
        if (acquaintancesGainedForCurrentHost == maxTimesToGainAcquaintances) return;
        if (!isMoreYearsAvailable())
        {
            CheckForLoss(marriageMarket.getAllCurrentlyAvailableMates());
            return;
        }
        Debug.Log("gaining Acquaintances");
        acquaintancesGainedForCurrentHost++;
        marriageMarket.enlargeMarket();
    }

    public void workout()
    {
        if (!isMoreYearsAvailable())
        {
            CheckForLoss(marriageMarket.getAllCurrentlyAvailableMates());
            return;
        }
        Debug.Log("working out");
        attractivity *= 1.4;
    }

    public void getPlasticSurgery()
    {
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
        if (marriageMarket.hyptheticallyPropose(currentHost, mate))
        {
            nestIn(breeder.breedPerson(currentHost, mate));
            marriageMarket.reset();
        }
        else Debug.Log("no marriage happening");
    }

    internal void nestIn(person person)
    {
        currentHost = person;
        currentHost.attractivity = marriageMarket.getAttractivity(this);
        acquaintancesGainedForCurrentHost = 0;
        yearsPassed = 0;
        breedTest.showAndTrackPerson(person,"",1);
    }

    private bool isThereAPotentialMate(List<person> peopleInMarriageMarket)
    {
        bool thereIsAPotentialMate = false;

        foreach (person potentialMate in peopleInMarriageMarket )
        {
            if (marriageMarket.hyptheticallyPropose(this.currentHost, potentialMate)) return true;
        }

        return thereIsAPotentialMate;
    }

    internal int getWealth()
    {
        return (int)wealth;
    }
}
