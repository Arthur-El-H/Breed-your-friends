using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Imutation 
{
    public bool isActive();
    public double getChanceForNoParent();
    public double getChanceForOneParent();
    public double getChanceForBothParents();
    public void setActivity(bool newActivity);
    public int getAttractivityBonus();
}
