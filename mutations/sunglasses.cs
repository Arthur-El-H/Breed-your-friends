using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunglasses : AbstractMutation, Imutation
{
    private double chanceForBothParent = 90;
    private double chanceForOneParent = 50;
    private double chanceForNoParent = 5;
    private bool mutationIsActive;
    private double chanceForRandomCreation = 10;
    private int AttractivityBonus = 15;
}