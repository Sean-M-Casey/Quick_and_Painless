using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public Color outlineColor;
    public Color outlineColorPressed;
    int interactAmounts = 1;
    public GameObject[] interactCheck;

    //Checks which interactable you are in range of and activates outline on trigger
    private void OnTriggerEnter(Collider other)
    {
            for (int i = 0; i < interactAmounts; i++)
            {
                if (interactCheck[i].name == other.name)
                {
                    interactCheck[i].GetComponent<Outline>().enabled = true;

            }
            }
    }
    //if in the trigger and you press defined key, green outline will activate
    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < interactAmounts; i++)
        {
            if (interactCheck[i].name == other.name)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactCheck[i].GetComponent<Outline>().OutlineColor = outlineColorPressed;
                }
            }
        }
    }
    //When exiting Trigger Outline is removed and set back to red
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < interactAmounts; i++)
        {
                interactCheck[i].GetComponent<Outline>().enabled = false;
                interactCheck[i].GetComponent<Outline>().OutlineColor = outlineColor;
        }
    }
}
