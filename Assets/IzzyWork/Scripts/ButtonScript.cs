using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPathFinding()
    {
        Debug.Log("ButtonPressed");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            Debug.Log("player not nulll");
            player.GetComponent<AiPawn>().StartPath();
        }
    }
}
