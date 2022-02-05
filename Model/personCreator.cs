using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personCreator : MonoBehaviour
{
    public person createRandomPerson()
    {
        person newPerson = new person();
        newPerson.head = getRandomHead();
        newPerson = getRandromGeneralTraits(newPerson);
        newPerson = getRandomMutations(newPerson);
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

    private static person getRandromGeneralTraits(person newPerson)
    {
        newPerson.eyes = getRandomGeneralTrait();
        newPerson.nose = getRandomGeneralTrait();
        newPerson.ears = getRandomGeneralTrait();
        newPerson.eyes = getRandomGeneralTrait();
        return newPerson;
    }

    private static generalTraitAspects getRandomGeneralTrait()
    {
        generalTraitAspects generalTrait = new generalTraitAspects();
        generalTrait.type = helperClass.getRandomType();
        generalTrait.height = helperClass.getRandomLength();
        generalTrait.width = helperClass.getRandomLength();
        generalTrait.xPos = helperClass.getRandomPos();
        generalTrait.yPos = helperClass.getRandomPos();
        generalTrait.abnormality = abnormalityMeasurer.getGeneralTraitAbnormality(generalTrait);
        return generalTrait;
    }
    private static head getRandomHead()
    {
        head randomHead = new head();

        randomHead.type = helperClass.getRandomType();

        //TODO get random length mit Parameter dafür, wie weit Abweichung vom Standart sein darf. Bisher immer nur Standart Personen.
        randomHead.height = helperClass.getRandomLength();
        randomHead.width = helperClass.getRandomLength();

        randomHead.abnormality = abnormalityMeasurer.getHeadAbnormality(randomHead);
        headAdjuster.adjustHeadToLength(randomHead);

        return randomHead;
    }
}
