using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personTester: MonoBehaviour
{
    public List<double> mouthHeight = new List<double>();
    public List<double> mouthWidth = new List<double>();
    public List<double> mouthXPos = new List<double>();
    public List<double> mouthYPos = new List<double>();
    public List<char> mouthType = new List<char>();
    public List<int> mouthAbnormality = new List<int>();
     
    public List<double> earsHeight = new List<double>();
    public List<double> earsWidth = new List<double>();
    public List<double> earsXPos = new List<double>();
    public List<double> earsYPos = new List<double>();
    public List<char> earsType = new List<char>();
    public List<int> earsAbnormality = new List<int>();
     
    public List<double> eyesHeight = new List<double>();
    public List<double> eyesWidth = new List<double>();
    public List<double> eyesXPos = new List<double>();
    public List<double> eyesYPos = new List<double>();
    public List<char> eyesType = new List<char>();
    public List<int> eyesAbnormality = new List<int>();
     
    public List<double> noseHeight = new List<double>();
    public List<double> noseWidth = new List<double>();
    public List<double> noseXPos = new List<double>();
    public List<double> noseYPos = new List<double>();
    public List<char> noseType = new List<char>();
    public List<int> noseAbnormality = new List<int>();
     
    public List<double> headHeight = new List<double>();
    public List<double> headWidth = new List<double>();
    public List<char> headType = new List<char>();
    public List<int> headAbnormality = new List<int>();

    public void showPerson( person personToShow, string descr, double extremeness)
    {
        trackPerson(personToShow, extremeness);
        Debug.Log(" --- new person ---");
        Debug.Log(descr);
        Debug.Log(extremeness);

        Debug.Log("-mouth-");
        showGeneralTrait(personToShow.mouth);
        Debug.Log("-nose-");
        showGeneralTrait(personToShow.nose);
        Debug.Log("-ears-");
        showGeneralTrait(personToShow.ears);
        Debug.Log("-eyes-");
        showGeneralTrait(personToShow.eyes);

        showHead(personToShow.head);

        Debug.Log("----");
        Debug.Log("----");
        Debug.Log("----");
    }

    private void trackPerson(person personToShow, double extremeness)
    {
        trackMouth(personToShow.mouth);
        trackEars(personToShow.ears);
        trackEyes(personToShow.eyes);
        trackNose(personToShow.nose);
        trackHead(personToShow.head);
    }

    private void trackHead(head head)
    {
        headAbnormality.Add(head.abnormality);
        headHeight.Add(head.height);
        headWidth.Add(head.width);
        headAbnormality.Add(head.abnormality);
    }

    private void trackNose(generalTraitAspects nose)
    {
        noseAbnormality.Add(nose.abnormality);
        noseHeight.Add(nose.height);
        noseWidth.Add(nose.width);
        noseXPos.Add(nose.xPos);
        noseYPos.Add(nose.yPos);
        noseAbnormality.Add(nose.abnormality);
    }

    private void trackEyes(generalTraitAspects eyes)
    {
        eyesAbnormality.Add(eyes.abnormality);
        eyesHeight.Add(eyes.height);
        eyesWidth.Add(eyes.width);
        eyesXPos.Add(eyes.xPos);
        eyesYPos.Add(eyes.yPos);
        eyesAbnormality.Add(eyes.abnormality);
    }

    private void trackEars(generalTraitAspects ears)
    {
        earsAbnormality.Add(ears.abnormality);
        earsHeight.Add(ears.height);
        earsWidth.Add(ears.width);
        earsXPos.Add(ears.xPos);
        earsYPos.Add(ears.yPos);
        earsAbnormality.Add(ears.abnormality);
    }

    private void trackMouth(generalTraitAspects mouth)
    {
        mouthAbnormality.Add(mouth.abnormality);
        mouthHeight.Add(mouth.height);
        mouthWidth.Add(mouth.width);
        mouthXPos.Add(mouth.xPos);
        mouthYPos.Add(mouth.yPos);
        mouthAbnormality.Add(mouth.abnormality);
    }

    private static void showHead(head head)
    {
        Debug.Log("abnormality: " + head.abnormality);
        Debug.Log("height: " + head.height);
        Debug.Log("width: " + head.width);
        Debug.Log("type: " + head.type);
    }

    private static void showGeneralTrait(generalTraitAspects gen)
    {
        Debug.Log("abnormality: " + gen.abnormality);
        Debug.Log("height: " + gen.height);
        Debug.Log("width: " + gen.width);
        Debug.Log("xPos: " + gen.xPos);
        Debug.Log("yPos: " + gen.yPos);
        Debug.Log("type: " + gen.type);
    }
}
