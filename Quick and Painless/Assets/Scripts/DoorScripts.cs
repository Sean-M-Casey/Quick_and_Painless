using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScripts : MonoBehaviour
{
    public GameObject foyer_kitchen;
    public GameObject kitchen_foyer;
    public GameObject kitchen_dining;
    public GameObject dining_kitchen;
    public GameObject dining_foyer;
    public GameObject foyer_dining;
    public GameObject foyer_laundry;
    public GameObject laundry_foyer;
    public GameObject foyer_master;
    public GameObject master_foyer;
    public GameObject foyer_living;
    public GameObject living_foyer;
    public GameObject cam_pos_foyer_dining;
    public GameObject cam_pos_kitchen;
    public GameObject cam_pos_living;
    public GameObject cam_pos_master;
    public GameObject cam_pos_laundry;
    public GameObject main_camera;
    public GameObject player;
    public string inRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == foyer_kitchen.name)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = kitchen_foyer.transform.position;
                inRoom = "Kitchen";
                main_camera.transform.position = new Vector3(cam_pos_kitchen.transform.position.x, cam_pos_kitchen.transform.position.y, cam_pos_kitchen.transform.position.z);
            }
        }
        if (other.name == kitchen_foyer.name)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = foyer_kitchen.transform.position;
                inRoom = "Foyer";
                main_camera.transform.position = new Vector3(cam_pos_foyer_dining.transform.position.x + 3, cam_pos_foyer_dining.transform.position.y, cam_pos_foyer_dining.transform.position.z);
            }
        }
        if (other.name == kitchen_dining.name)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = dining_kitchen.transform.position;
                inRoom = "Dining";
                main_camera.transform.position = new Vector3(player.transform.position.x, cam_pos_foyer_dining.transform.position.y, cam_pos_foyer_dining.transform.position.z);
            }
        }
        if (other.name == dining_kitchen.name)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = kitchen_dining.transform.position;
                inRoom = "Kitchen";
                main_camera.transform.position = new Vector3(cam_pos_kitchen.transform.position.x, cam_pos_kitchen.transform.position.y, cam_pos_kitchen.transform.position.z);
            }
        }
        if (other.name == dining_foyer.name)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = foyer_dining.transform.position;
                inRoom = "Foyer";
                main_camera.transform.position = new Vector3(cam_pos_foyer_dining.transform.position.x + 3, cam_pos_foyer_dining.transform.position.y, cam_pos_foyer_dining.transform.position.z);
            }
        }
        if (other.name == foyer_dining.name)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = dining_foyer.transform.position;
                inRoom = "Dining";
                main_camera.transform.position = new Vector3(cam_pos_kitchen.transform.position.x, cam_pos_kitchen.transform.position.y, cam_pos_kitchen.transform.position.z);
            }
        }
    }
}
