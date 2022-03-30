using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingameManager : MonoBehaviour
{
    [SerializeField] private marriageMarket marriageMarket;
    [SerializeField] private personCreator personCreator;
    [SerializeField] private GameObject hostPrefab;
    [SerializeField] private breeder breeder;
    [SerializeField] private buttonManager buttonManager;
    [SerializeField] private personTester personTest;




    private host host;

    public void initGame()
    {
        host = Instantiate(hostPrefab, Vector3.zero, Quaternion.identity).GetComponent<host>();
        host.initHost(marriageMarket, breeder, personTest);
        host.nestIn(personCreator.createRandomPerson(standart.totallyNormal));
        marriageMarket.initMarriageMarket(host, personCreator);

        marriageMarket.createMarriageMarket();
        buttonManager.initActionBtns(host);
    }

    // Start is called before the first frame update
    void Start()
    {
        initGame();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
