using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingameManager : MonoBehaviour
{
    [SerializeField] private marriageMarket marriageMarket;
    [SerializeField] private personCreator personCreator;
    [SerializeField] private GameObject hostPrefab;

    private host host;

    public void initGame()
    {
        host = Instantiate(hostPrefab, Vector3.zero, Quaternion.identity).GetComponent<host>();
        host.nestIn(personCreator.createRandomPerson(standart.totallyNormal));
        marriageMarket.createMarriageMarket();
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
