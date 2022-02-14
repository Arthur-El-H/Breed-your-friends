using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingameManager : MonoBehaviour
{
    [SerializeField] private marriageMarket marriageMarket;
    [SerializeField] private personCreator personCreator;
    [SerializeField] private host host;

    public void initGame()
    {
        host.nestIn(personCreator.createRandomPerson(standart.totallyNormal));
        marriageMarket.createMarriageMarket();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
