﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breeder : MonoBehaviour
{
    const int typeOneDominance = 80;
    const int typeTwoDominance = 65;
    const int typeThreeDominance = 50;
    const int typeFourDominance = 40;
    const int typeFiveDominance = 25;

    const char typeOne = 'a';
    const char typeTwo = 'b';
    const char typeThree = 'c';
    const char typeFour = 'd';
    const char typeFive = 'e';

    const int abnormalityOne = 2;
    const int abnormalityTwo = 4;
    const int abnormalityThree = 6;
    const int abnormalityFour = 8;
    const int abnormalityFive = 10;

    const double lengthMultMaxCap = 2;
    const double lengthMultMinCap = .5;

    const double standartMultMin = 0.8;
    const double standartMultMax = 1.2;

    static System.Random random;


    void Start()
    {
        random = new System.Random();
    }

    public person breedPerson(person mom, person dad)
    {
        person brood = new person();

        //brood.head = breedHead(mom.head, dad.head);
        brood.mouth = breedGeneral(mom.mouth, dad.mouth);
        brood.nose = breedGeneral(mom.nose, dad.nose);
        brood.ears = breedGeneral(mom.ears, dad.ears);
        brood.eyes = breedGeneral(mom.eyes, dad.eyes);
        //...


        return brood;
    }

    private generalTraitAspects breedGeneral(generalTraitAspects mom, generalTraitAspects dad)
    {
        generalTraitAspects mouth = new generalTraitAspects();
        mouth.type = breedType(mom.type, dad.type);
        mouth.height = breedLength(mom.height, dad.height);
        mouth.width = breedLength(mom.width, dad.width);
        mouth.xPos = breedPos(mom.xPos, dad.xPos);
        mouth.yPos = breedPos(mom.yPos, dad.yPos);
        mouth.abnormality = getGeneralTraitAbnormality(mouth);
        return mouth;
    }

    private double breedPos(double Pos1, double Pos2)
    {
        // every Pos is always between 0 and 2. 
        // 1 is the ideal Position.
        // maybe TODO: add tendency
        double average = (Pos1 + Pos2) / 2;
        double broodPos = average + randomNumberBetween(-.1, .1);
        if (broodPos > 2)
        {
            return 2;
        }
        else if (broodPos < 0)
        {
            return 0;
        }
        else
        {
            return broodPos;
        }
    }
    private double breedLength(double height1, double height2, double specificParam = 1)
    {
        double average = (height1 + height2) / 2;
        double tendency = average - 1;

        double multiplier = randomNumberBetween(getLengthMultMin(tendency), getLengthMultMax(tendency)) ;
        return average * multiplier;
    }
    private char breedType(char momType, char dadType)
    {
        int momDominance = getTypeDominance(momType);
        int dadDominance = getTypeDominance(dadType);

        int result = random.Next(0, (momDominance + dadDominance));
        if (result < momDominance)
        {
            return momType;
        }
        else
        {
            return dadType;
        }
    }

    private int getTypeDominance(char type)
    {
        switch (type)
        {
            case typeFive: return typeFiveDominance;
            case typeFour: return typeFourDominance;
            case typeThree: return typeThreeDominance;
            case typeTwo: return typeTwoDominance;
            case typeOne: return typeOneDominance;
        }
        throw new wrongMethodParamException();            
    }

    private double getLengthMultMin(double tendency)
    {
        double min = standartMultMin + tendency;
        if (min < lengthMultMinCap)
        {
            return lengthMultMinCap;
        }
        else
        {
            return min;
        }
    }
    private double getLengthMultMax(double tendency)
    {
        double max = standartMultMax + tendency;
        if (max > lengthMultMaxCap)
        {
            return lengthMultMaxCap;
        }
        else
        {
            return max;
        }
    }

    private static double randomNumberBetween(double minValue, double maxValue)
    {
        var next = random.NextDouble();

        return minValue + (next * (maxValue - minValue));
    }

    private int getGeneralTraitAbnormality(generalTraitAspects traitAspects)
    {
        int abnormality = 0;
        abnormality += (int)Math.Round(10 * Math.Abs(1 - traitAspects.xPos), MidpointRounding.AwayFromZero);
        abnormality += (int)Math.Round(10 * Math.Abs(1 - traitAspects.yPos), MidpointRounding.AwayFromZero);
        abnormality += getLengthAbnorm(traitAspects.height);
        abnormality += getLengthAbnorm(traitAspects.width);
        abnormality += getTypeAbnorm(traitAspects.type);
        return abnormality;
    }
    private int getTypeAbnorm(char type)
    {
        switch (type)
        {
            case typeOne:
                return abnormalityOne;
            case typeTwo:
                return abnormalityTwo;
            case typeThree:
                return abnormalityThree;
            case typeFour:
                return abnormalityFour;
            case typeFive:
                return abnormalityFive;
        }
        throw new wrongMethodParamException();
    }
    private int getLengthAbnorm(double height)
    {
        return (int)Math.Round((height * 6 - 2), MidpointRounding.AwayFromZero);
    }

}
