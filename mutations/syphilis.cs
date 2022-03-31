using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syphilis : AbstractMutation, Imutation
{
    private double chanceForBothParent = 90;
    private double chanceForOneParent = 50;
    private double chanceForNoParent = 5;
    private double chanceForRandomCreation = 10;
    private bool mutationIsActive;
    private int AttractivityBonus = -20;
}