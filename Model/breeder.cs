using System;
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

    const double lengthMultMaxCap = 2;
    const double lengthMultMinCap = .5;
    const double maxLength = 3;
    const double minLength = .3;

    static System.Random random;


    void Start()
    {
        random = new System.Random();
    }

    public person breedPerson(person mom, person dad)
    {
        person brood = new person();

        brood.head = breedHead(mom.head, dad.head);

        brood.mouth = breedGeneral(mom.mouth, dad.mouth);
        brood.nose = breedGeneral(mom.nose, dad.nose);
        brood.ears = breedGeneral(mom.ears, dad.ears);
        brood.eyes = breedGeneral(mom.eyes, dad.eyes);

        brood.sunglasses = breedMutation(mom.sunglasses, dad.sunglasses);
        brood.pox = breedMutation(mom.pox, dad.pox);
        brood.jaundice = breedMutation(mom.jaundice, dad.jaundice);
        brood.syphilis = breedMutation(mom.syphilis, dad.syphilis);
        brood.thirdEye = breedMutation(mom.thirdEye, dad.thirdEye);
        brood.walrus = breedMutation(mom.walrus, dad.walrus);
        brood.frankenstein = breedMutation(mom.frankenstein, dad.frankenstein);
        helperClass.saveMutationActivityOfAPersonToItsList(brood);

        brood.abnormality = abnormalityMeasurer.getAbnormalityOfPerson(brood);
        brood.attractivity = marriageMarket.getAttractivity(brood);

        return brood;
    }

    private head breedHead(head headMom, head headDad)
    {
        head broodHead = new head();
        broodHead.type = breedType(headMom.type, headDad.type);
        broodHead.height = breedLength(headMom.height, headDad.height);
        broodHead.width = breedLength(headMom.width, headDad.width);
        broodHead.abnormality = abnormalityMeasurer.getHeadAbnormality(broodHead);
        headAdjuster.adjustHeadToLength(broodHead); //Diesen Teil evtl. in drawer, damit in der breeder Klasse nur die absoluten Daten sind.
        return broodHead;
    }

    private generalTraitAspects breedGeneral(generalTraitAspects mom, generalTraitAspects dad)
    {
        generalTraitAspects generalTrait = new generalTraitAspects();
        generalTrait.type = breedType(mom.type, dad.type);
        generalTrait.height = breedLength(mom.height, dad.height);
        generalTrait.width = breedLength(mom.width, dad.width);
        generalTrait.xPos = breedPos(mom.xPos, dad.xPos);
        generalTrait.yPos = breedPos(mom.yPos, dad.yPos);
        generalTrait.abnormality = abnormalityMeasurer.getGeneralTraitAbnormality(generalTrait);
        return generalTrait;
    }

    private double breedPos(double Pos1, double Pos2)
    {
        // every Pos is always between 0 and 2. 
        // 1 is the ideal Position.
        // maybe TODO: add tendency
        double average = (Pos1 + Pos2) / 2;
        double broodPos = average + helperClass.randomNumberBetween(-.1, .1);
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

        double multiplier = helperClass.randomNumberBetween(getLengthMultMin(tendency), getLengthMultMax(tendency)) ;
        double newLength = average * multiplier;

        if (newLength > maxLength) newLength = maxLength;
        if (newLength < minLength) newLength = minLength;

        return newLength;
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
            case standart.typeFive: return typeFiveDominance;
            case standart.typeFour: return typeFourDominance;
            case standart.typeThree: return typeThreeDominance;
            case standart.typeTwo: return typeTwoDominance;
            case standart.typeOne: return typeOneDominance;
        }
        throw new wrongMethodParamException();            
    }

    private double getLengthMultMin(double tendency)
    {
        double min = standart.standartMinimumForLengthMultiplier + tendency;
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
        double max = standart.standartMaximumForLengthMultiplier + tendency;
        if (max > lengthMultMaxCap)
        {
            return lengthMultMaxCap;
        }
        else
        {
            return max;
        }
    }

    private Imutation breedMutation(Imutation mutationMom, Imutation mutationDad)
    {
        bool momActive = mutationMom.isActive();
        bool dadActive = mutationDad.isActive();
        bool broodActive;
        double chanceForMutation;

        if (dadActive && momActive)
        {
            chanceForMutation = mutationMom.getChanceForBothParents();
        }
        else if (dadActive || momActive)
        {
            chanceForMutation = mutationMom.getChanceForOneParent();
        }
        else
        {
            chanceForMutation = mutationMom.getChanceForNoParent();
        }

        broodActive = helperClass.getMutationActivity(chanceForMutation);

        mutationMom.setActivity(broodActive);
        return mutationMom;
    }
}
