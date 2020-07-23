using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCheck : MonoBehaviour
{
    public GameObject player;
    string inRoom;
    // Start is called before the first frame update
    void Start()
    {
        inRoom = player.GetComponent<DoorScripts>().inRoom;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRoom == "Foyer")
        {

        }
    }
}
