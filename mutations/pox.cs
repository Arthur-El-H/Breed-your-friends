using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pox : AbstractMutation, Imutation
{
    private double chanceForBothParent = 90;
    private double chanceForOneParent = 50;
    private double chanceForNoParent = 5;
    private bool mutationIsActive;
    private double chanceForRandomCreation = 10;
}