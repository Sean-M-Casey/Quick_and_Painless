using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraTrigger : MonoBehaviour
{
    public GameObject[] Cameras;
    int roomNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Trigger2")
        {
            if(roomNum == 0)
            {
                gameObject.transform.position = Cameras[1].transform.position;
                roomNum = 1;
            }
            else if (roomNum == 1)
            {
                gameObject.transform.position = Cameras[0].transform.position;
                roomNum = 0;
            }
        }
        else if (other.name == "Trigger1")
        {
            if (roomNum == 0)
            {
                gameObject.transform.position = Cameras[5].transform.position;
                roomNum = 2;
            }
            else if (roomNum == 2)
            {
                gameObject.transform.position = Cameras[4].transform.position;
                roomNum = 0;
            }
        }
        else if (other.name == "Trigger3")
        {
            if (roomNum == 0)
            {
                gameObject.transform.position = Cameras[2].transform.position;
                roomNum = 3;
            }
            else if (roomNum == 3)
            {
                gameObject.transform.position = Cameras[3].transform.position;
                roomNum = 0;
            }
        }
    }
}
