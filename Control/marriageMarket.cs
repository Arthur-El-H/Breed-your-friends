using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marriageMarket: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private buttonManager buttonManager;
    [SerializeField] private GameObject genericMate;
    [SerializeField] private host host;
    personCreator personCreator;
    int timesMarketWasEnlarged;
    public buttonManager.marryMe marryMethod;

    Vector2[] matePositions = new Vector2[]
    {
        new Vector2(3, 4),
        new Vector2(6, 4),
        new Vector2(9, 4),
        new Vector2(3, 0),
        new Vector2(6, 0),
        new Vector2(9, 0),
        new Vector2(3, -4),
        new Vector2(6, -4),
        new Vector2(9, -4),
    };     

    public void initMarriageMarket(host newHost, personCreator newPersonCreator)
    {
        host = newHost;
        personCreator = newPersonCreator;
    }

    internal void createMarriageMarket()
    {
        timesMarketWasEnlarged = 0;
        marryMethod = host.mate;

        double extremeness = standart.totallyNormal;
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0: extremeness = standart.totallyNormal; break;
                case 1: extremeness = standart.prettyNormal; break;
                case 2: extremeness = standart.notNormal; break;
            }
            setUpMate( i, extremeness);
        }
    }

    private void setUpMate( int indexNumber, double extremeness)
    {
        person personToCreate;
        possibleMate possibleMate;
        personToCreate = personCreator.createRandomPerson(extremeness);
        possibleMate = Instantiate(genericMate, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<possibleMate>();
        GameObject btn = buttonManager.getButtonForPossibleMate(marryMethod, personToCreate);
        possibleMate.setUp(btn, matePositions[indexNumber]);
    }

    public void enlargeMarket()
    {
        timesMarketWasEnlarged++;
        double extremeness = standart.totallyNormal;
        for (int i = 3; i < 6; i++)
        {
            switch (i)
            {
                case 0: extremeness = standart.totallyNormal; break;
                case 1: extremeness = standart.prettyNormal; break;
                case 2: extremeness = standart.notNormal; break;
            }
            setUpMate(i, extremeness);
        }
    }
}
