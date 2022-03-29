using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class abnormalityMeasurer 
{
    const int abnormalityOne = 2;
    const int abnormalityTwo = 4;
    const int abnormalityThree = 6;
    const int abnormalityFour = 8;
    const int abnormalityFive = 10;

    public static int getAbnormalityOfPerson(person person)
    {
        int abnormality = 0 + person.ears.abnormality
                            + person.eyes.abnormality
                            + person.head.abnormality
                            + person.nose.abnormality
                            + person.mouth.abnormality;
        return abnormality;
    }

    public static int getGeneralTraitAbnormality(generalTraitAspects traitAspects)
    {
        int abnormality = 0;
        abnormality += (int)Math.Round(10 * Math.Abs(1 - traitAspects.xPos), MidpointRounding.AwayFromZero);
        abnormality += (int)Math.Round(10 * Math.Abs(1 - traitAspects.yPos), MidpointRounding.AwayFromZero);
        abnormality += getLengthAbnorm(traitAspects.height);
        abnormality += getLengthAbnorm(traitAspects.width);
        abnormality += getTypeAbnorm(traitAspects.type);
        return abnormality;
    }
    public static int getTypeAbnorm(char type)
    {
        switch (type)
        {
            case standart.typeOne:
                return abnormalityOne;
            case standart.typeTwo:
                return abnormalityTwo;
            case standart.typeThree:
                return abnormalityThree;
            case standart.typeFour:
                return abnormalityFour;
            case standart.typeFive:
                return abnormalityFive;
        }
        throw new wrongMethodParamException();
    }
    public static int getLengthAbnorm(double height)
    {
        return (int)Math.Round((height * 6 - 2), MidpointRounding.AwayFromZero);
    }
    public static int getHeadAbnormality(head broodHead)
    {
        int abnormality = 0;
        abnormality += getLengthAbnorm(broodHead.height);
        abnormality += getLengthAbnorm(broodHead.width);
        abnormality += getTypeAbnorm(broodHead.type);
        return abnormality;
    }
}
