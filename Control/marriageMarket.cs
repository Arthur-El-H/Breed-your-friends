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
    List<person> market;
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

    private void Start()
    {
        
    }

    internal void createMarriageMarket()
    {
        timesMarketWasEnlarged = 0;
        market = new List<person>();

        person personToCreate;
        possibleMate possibleMate;
        marryMethod = host.mate;

        //ToDo: Fix delegate. Create not always totally normal. See in commented code below. Delete commented code when finished and maybe delete List "Market".
        for (int i = 0; i < 3; i++)
        {
            personToCreate = personCreator.createRandomPerson(standart.totallyNormal);
            possibleMate = Instantiate(genericMate, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<possibleMate>();       
            GameObject btn = buttonManager.getButton(marryMethod, personToCreate);
            possibleMate.setUp(btn, matePositions[i]);
        }

        //market.Add(personCreator.createRandomPerson(standart.totallyNormal));
        //market.Add(personCreator.createRandomPerson(standart.prettyNormal));
        //market.Add(personCreator.createRandomPerson(standart.notNormal));
    }

    public void enlargeMarket()
    {
        //ToDo: change as above in createMarket Function
        timesMarketWasEnlarged++;
        //market.Add(personCreator.createRandomPerson(standart.totallyNormal));
        //market.Add(personCreator.createRandomPerson(standart.prettyNormal));
        //market.Add(personCreator.createRandomPerson(standart.notNormal));
    }
}
