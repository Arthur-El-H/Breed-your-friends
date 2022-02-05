using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class headAdjuster
{
    public static void adjustHeadToLength(head broodHead)
    {
        //TODO statt adjust -> getAdjusted
        adjustHeadSpace(broodHead.earsSpace, broodHead.width, broodHead.height);
        adjustHeadSpace(broodHead.eyesSpace, broodHead.width, broodHead.height);
        adjustHeadSpace(broodHead.mouthSpace, broodHead.width, broodHead.height);
        adjustHeadSpace(broodHead.noseSpace, broodHead.width, broodHead.height);

        adjustHeadPos(broodHead.eyesPos, broodHead.width, broodHead.height); //Vermutlich erst in drawer umsetzen
    }
    private static void adjustHeadPos(Vector2 eyesPos, double width, double height)
    {

    }
    private static void adjustHeadSpace(possibleSpace space, double width, double height)
    {
        // this works when middlepoint is seen as 0/0
        space.minX *= width;
        space.maxX *= width;
        space.maxY *= height;
        space.minX *= height;
    }
}
