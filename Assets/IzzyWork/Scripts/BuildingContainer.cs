using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingContainer : MonoBehaviour
{
    // Start is called before the first frame update

    //This list shows how many floors the building has
    public List<int> FloorNumbers;

    //Each one of these lists has the rooms in numerical named order
    public List<GameObject> Floor1;
    public List<GameObject> Floor2;
    public List<GameObject> Floor3;
    public List<GameObject> Floor4;

    //Only needed for smith hall
    public List<GameObject> Floor5;
    public List<GameObject> Floor6;
    public List<GameObject> Floor7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
