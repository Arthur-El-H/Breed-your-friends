using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personCreator : MonoBehaviour
{
    public person createRandomPerson(double extremeness)
    {
        person newPerson = new person();
        newPerson.head = getRandomHead(extremeness);
        newPerson = getRandromGeneralTraits(newPerson, extremeness);
        newPerson = getRandomMutations(newPerson);
        newPerson.abnormality = abnormalityMeasurer.getAbnormalityOfPerson(newPerson);
        newPerson.attractivity = marriageMarket.getAttractivity(newPerson);
        return newPerson;
    }

    private static person getRandomMutations(person newPerson)
    {
        newPerson.sunglasses = new sunglasses();
        newPerson.pox = new pox();
        newPerson.jaundice = new jaundice();
        newPerson.syphilis = new syphilis();
        newPerson.thirdEye = new thirdEye();
        newPerson.walrus = new walrus();
        newPerson.frankenstein = new frankenstein();
        return newPerson;
    }

    private static person getRandromGeneralTraits(person newPerson, double extremeness)
    {
        newPerson.eyes = getRandomGeneralTrait(extremeness);
        newPerson.nose = getRandomGeneralTrait(extremeness);
        newPerson.ears = getRandomGeneralTrait(extremeness);
        newPerson.mouth = getRandomGeneralTrait(extremeness);
        return newPerson;
    }

    private static generalTraitAspects getRandomGeneralTrait(double extremeness)
    {
        generalTraitAspects generalTrait = new generalTraitAspects();
        generalTrait.type = helperClass.getRandomType();
        generalTrait.height = helperClass.getRandomLength(extremeness);
        generalTrait.width = helperClass.getRandomLength(extremeness);
        generalTrait.xPos = helperClass.getRandomPos(extremeness);
        generalTrait.yPos = helperClass.getRandomPos(extremeness);
        generalTrait.abnormality = abnormalityMeasurer.getGeneralTraitAbnormality(generalTrait);
        return generalTrait;
    }
    private static head getRandomHead(double extremeness)
    {
        head randomHead = new head();

        randomHead.type = helperClass.getRandomType();

        randomHead.height = helperClass.getRandomLength(extremeness);
        randomHead.width = helperClass.getRandomLength(extremeness);

        randomHead.abnormality = abnormalityMeasurer.getHeadAbnormality(randomHead);
        headAdjuster.adjustHeadToLength(randomHead);

        return randomHead;
    }
}
