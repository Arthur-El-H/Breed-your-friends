using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marriageMarket: MonoBehaviour
{
    private List<possibleMate> currentPotentialMates;
    public List<possibleMate> getCurrentPotentialMates()
    {
        return currentPotentialMates;
    }

    public personTester totallyNormalTest;
    public personTester prettyNormalTest;
    public personTester notNormalTest;
    public personTester weirdTest;

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

    public List<person> getAllCurrentlyAvailableMates()
    {
        List<person> currentlyAvailableMates = new List<person>();
        foreach(possibleMate mate in currentPotentialMates)
        {
            currentlyAvailableMates.Add(mate.person);
        }
        return currentlyAvailableMates;
    }

    public void initMarriageMarket(host newHost, personCreator newPersonCreator)
    {
        host = newHost;
        personCreator = newPersonCreator;
        currentPotentialMates = new List<possibleMate>();
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

        switch (extremeness)
        {
            case standart.totallyNormal: totallyNormalTest.showAndTrackPerson(personToCreate, "person created for marriagemarket.", extremeness); break;
            case standart.prettyNormal: prettyNormalTest.showAndTrackPerson(personToCreate, "person created for marriagemarket.", extremeness); break;
            case standart.notNormal: notNormalTest.showAndTrackPerson(personToCreate, "person created for marriagemarket.", extremeness); break;
            case standart.weird: weirdTest.showAndTrackPerson(personToCreate, "person created for marriagemarket.", extremeness); break;
        }

        possibleMate = Instantiate(genericMate, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<possibleMate>();
        GameObject btn = buttonManager.getButtonForPossibleMate(marryMethod, personToCreate);
        possibleMate.setUp(btn, matePositions[indexNumber], personToCreate);

        currentPotentialMates.Add(possibleMate);
    }

    internal void reset()
    {
        foreach(possibleMate mate in currentPotentialMates)
        {
            mate.destroy();
        }
        currentPotentialMates.Clear();
        enlargeMarket();
    }

    public void enlargeMarket()
    {
        int matesToAdd = 3;
        // TODO: maybe make method more general: number of new mates and preferences of extremeness as parameter
        double extremeness = standart.totallyNormal;
        int firstPositionToSetMateOn = currentPotentialMates.Count + 1;
        int lastPositionToSetMateOn = firstPositionToSetMateOn + matesToAdd;
        for (int i = firstPositionToSetMateOn; i < lastPositionToSetMateOn; i++)
        {
            switch (i)
            {
                case 3: extremeness = standart.prettyNormal; break;
                case 4: extremeness = standart.notNormal; break;
                case 5: extremeness = standart.weird; break;
            }
            setUpMate(i-1, extremeness);
        }
    }

    public bool hyptheticallyPropose (person proposingPerson, person respondingPerson)
    {
        int howMuchMoreAttractiveIsProposer = proposingPerson.attractivity - respondingPerson.attractivity;
        if (howMuchMoreAttractiveIsProposer < -20)
        {
            return false;
        }
        return true;
    }

    public static int getAttractivity(person personToRate)
    {
        int personsAttractivity = 80 - personToRate.abnormality;
        if (personToRate.activeMutations != null)
        {
            foreach (Imutation mutation in personToRate.activeMutations)
            {
                personsAttractivity += mutation.getAttractivityBonus();
            }
        }
        return personsAttractivity;
    }

    public static int getAttractivity(host host)
    {
        int hostsAttractivity = host.currentHost.attractivity;
        int moneyBonus = host.getWealth() / 20;
        if (moneyBonus > standart.maxMoneyBonus) moneyBonus = standart.maxMoneyBonus;
        return hostsAttractivity + moneyBonus;
    }
}
