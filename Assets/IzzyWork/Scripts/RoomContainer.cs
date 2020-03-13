using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomContainer : MonoBehaviour
{
    // Start is called before the first frame update


    //creating container for rooms on campus
    //Multiple nested lists does not work
    //public List<List<List<List<GameObject>>>> CampusContainer;

    //Prototype data structure
    //This campus list has the shorthand names of all buildings, similar to banner
    //public List<string> CampusBuildingList;
    //Each building has a list of floors
    //public List<List<GameObject>> FloorRoomList;
    //public List<GameObject> RoomList;

    //Centralizing the building structure will not work, is better to traverse the buildings
    //Abbreviated names list
    public List<string> CampusBuildingNameList;
    //List of Building names
    public List<GameObject> CampusBuildingList;

    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public GameObject FindRoomTarget(string BuildingNameGiven, int RoomNumber)
    {
        GameObject target;

        foreach(string buildingNameInList in CampusBuildingNameList)
        {
            if(buildingNameInList == BuildingNameGiven)
            {
                //From here get bulding from CampusBuildingList, access that building's buildingContainer and grab proper room.
            }
        }

        //return target;
    }*/
}
