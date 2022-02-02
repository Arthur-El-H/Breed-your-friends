using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pox : Imutation
{
    private double chanceForBothParent = 90;
    private double chanceForOneParent = 50;
    private double chanceForNoParent = 5;

    private bool mutationIsActive;

    public pox(bool isActive)
    {
        mutationIsActive = isActive;
    }

    public double getChanceForBothParents()
    {
        return chanceForBothParent;
    }

    public double getChanceForNoParent()
    {
        return chanceForNoParent;
    }

    public double getChanceForOneParent()
    {
        return chanceForOneParent;
    }

    public bool isActive()
    {
        return mutationIsActive;
    }
    public void setActivity(bool newActivity)
    {
        mutationIsActive = newActivity;
    }
}