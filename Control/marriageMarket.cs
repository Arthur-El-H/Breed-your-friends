using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marriageMarket : MonoBehaviour
{
    // Start is called before the first frame update

    personCreator personCreator;
    List<person> market;

    internal void createMarriageMarket()
    {
        market = new List<person>();
        market.Add(personCreator.createRandomPerson(standart.totallyNormal));
        market.Add(personCreator.createRandomPerson(standart.prettyNormal));
        market.Add(personCreator.createRandomPerson(standart.notNormal));
    }

    public void enlargeMarket()
    {
        market.Add(personCreator.createRandomPerson(standart.totallyNormal));
        market.Add(personCreator.createRandomPerson(standart.prettyNormal));
        market.Add(personCreator.createRandomPerson(standart.notNormal));
    }
}
