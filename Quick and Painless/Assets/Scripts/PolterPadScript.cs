using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PolterPadScript : MonoBehaviour
{
    public GameObject polterPad;
    public GameObject polterPadUI;
    public UnityEvent triggerTimePause;
    public UnityEvent triggerTimeUnPause;
    public int ppActive = 0;
    //public Animator triggerPolterPad;
    void Start()
    {
        polterPad.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (ppActive == 0)
            {
                StartCoroutine(ActivatePP());
            }
            if (ppActive == 1)
            {
                polterPad.SetActive(false);
                polterPadUI.SetActive(true);
                triggerTimeUnPause.Invoke();
                ppActive--;
            }
        }
    }
    IEnumerator ActivatePP()
    {
        yield return new WaitForSeconds(0.2f);
        polterPad.SetActive(true);
        polterPadUI.SetActive(false);
        triggerTimePause.Invoke();
        ppActive++;
    }
}
