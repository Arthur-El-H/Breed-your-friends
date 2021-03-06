using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class helperClass 
{
    //TODO maybe change name to randomizer or sth.
    static System.Random random = new System.Random(); //TODO initialize

    static public char getRandomType()
    {
        int randnum = UnityEngine.Random.Range(1, 5);
        switch (randnum)
        {
            case 1: return standart.typeOne;
            case 2: return standart.typeTwo;
            case 3: return standart.typeThree;
            case 4: return standart.typeFour;
            case 5: return standart.typeFive;
        }
        throw new unexpectedError();
    }

    internal static double getRandomLength(double extremeness)
    {
        return randomNumberBetween(standart.standartMinimumForLengthMultiplier / extremeness, extremeness * standart.standartMaximumForLengthMultiplier);
    }

    public static double getRandomPos(double extremeness)
    {
        return randomNumberBetween(standart.standartMinimumForLengthMultiplier / extremeness, extremeness * standart.standartMaximumForLengthMultiplier);
    }

    public static double randomNumberBetween(double minValue, double maxValue)
    {
        var next = random.NextDouble();
        double res = minValue + (next * (maxValue - minValue));
        return res;
    }

    public static bool getMutationActivity(double chance)
    {
        double resultOfMixture = helperClass.randomNumberBetween(0, 100);
        if (resultOfMixture < chance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void saveMutationActivityOfAPersonToItsList(person person)
    {
        person.activeMutations = new List<Imutation>();
        if (person.frankenstein.isActive()) person.activeMutations.Add(person.frankenstein);
        if (person.jaundice.isActive()) person.activeMutations.Add(person.jaundice);
        if (person.pox.isActive()) person.activeMutations.Add(person.pox);
        if (person.sunglasses.isActive()) person.activeMutations.Add(person.sunglasses);
        if (person.syphilis.isActive()) person.activeMutations.Add(person.syphilis);
        if (person.thirdEye.isActive()) person.activeMutations.Add(person.thirdEye);
        if (person.walrus.isActive()) person.activeMutations.Add(person.walrus);
    }
}
