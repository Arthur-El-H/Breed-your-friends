using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct person
{
    public head head;

    public generalTraitAspects nose;
    public generalTraitAspects mouth;
    public generalTraitAspects eyes;
    public generalTraitAspects ears;

    public Imutation sunglasses;
    public Imutation pox;
    public Imutation jaundice;
    public Imutation syphilis;
    public Imutation thirdEye;
    public Imutation walrus;
    public Imutation frankenstein;

    public List<Imutation> activeMutations;

    public int abnormality;
    public int attractivity;
}

public struct head
{
    public char type;
    
    public double height;
    public double width;

    public Vector2 nosePos;
    public Vector2 eyesPos;
    public Vector2 mouthPos;
    public Vector2 earsPos;

    public int abnormality;

    public possibleSpace noseSpace;
    public possibleSpace eyesSpace;
    public possibleSpace mouthSpace;
    public possibleSpace earsSpace;
}

public struct generalTraitAspects // generally used for physical parts of the face
{
    public char type;
    public double xPos;
    public double yPos;
    public double height;
    public double width;

    public Color color;
    public int abnormality;
}

public struct possibleSpace
{
    public double maxX;
    public double maxY;
    public double minX;
    public double minY;
}