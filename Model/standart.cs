using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standart : MonoBehaviour
{
    public const double totallyNormal = 1;
    public const double prettyNormal = 1.2;
    public const double notNormal = 1.4;
    public const double weird = 1.7;


    public Vector2 headNosePos;
    public Vector2 headOneMouthPos;
    public Vector2 headTwoMouthPos;
    public Vector2 headThreeMouthPos;
    public Vector2 headFourMouthPos;
    public Vector2 headFiveMouthPos;

    public Vector2 headOneEyePos;
    public Vector2 headTwoEyePos;
    public Vector2 headThreeEyePos;
    public Vector2 headFourEyePos;
    public Vector2 headFiveEyePos;

    public Vector2 headOneEarPos;
    public Vector2 headTwoEarPos;
    public Vector2 headThreeEarPos;
    public Vector2 headFourEarPos;
    public Vector2 headFiveEarPos;

    public int sunglassesID = 1;
    public int poxID = 2;
    public int jaundiceID = 3;
    public int syphilisID = 4;
    public int thirdEyeID = 5;
    public int walrusID = 6;
    public int frankensteinID = 7;
    public static int maxMoneyBonus = 60;
    public const char typeOne = 'a';
    public const char typeTwo = 'b';
    public const char typeThree = 'c';
    public const char typeFour = 'd';
    public const char typeFive = 'e';

    public const double standartMinimumForLengthMultiplier = 0.8;
    public const double standartMaximumForLengthMultiplier = 1.2;

    void Start()
    {
        headNosePos = Vector2.zero;

        headOneMouthPos   = new Vector2(0f, 0f);
        headTwoMouthPos   = new Vector2(0f, 0f);
        headThreeMouthPos = new Vector2(0f, 0f);
        headFourMouthPos  = new Vector2(0f, 0f);
        headFiveMouthPos  = new Vector2(0f, 0f);

        headOneEyePos    = new Vector2(0f, 0f);
        headTwoEyePos    = new Vector2(0f, 0f);
        headThreeEyePos  = new Vector2(0f, 0f);
        headFourEyePos   = new Vector2(0f, 0f);
        headFiveEyePos   = new Vector2(0f, 0f);

        headOneEarPos    = new Vector2(0f, 0f);
        headTwoEarPos    = new Vector2(0f, 0f);
        headThreeEarPos  = new Vector2(0f, 0f);
        headFourEarPos   = new Vector2(0f, 0f);
        headFiveEarPos   = new Vector2(0f, 0f);
    }

}
