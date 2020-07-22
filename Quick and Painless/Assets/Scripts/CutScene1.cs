using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutScene1 : MonoBehaviour
{
    public GameObject textBox;
    public GameObject textEndIcon;
    public UnityEvent canMoveEvent;
    TextWritingScript textScript;
    int textTracker = 0;
    public int cutsceneOneSentenceLimit;
    // Start is called before the first frame update
    void Start()
    {
        textScript = gameObject.GetComponent<TextWritingScript>();
        textBox.SetActive(false);
        StartCoroutine(Cutscene1());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && textEndIcon.activeSelf == true)
        {
            textTracker++;
            StartCoroutine(Cutscene1());
            textScript.chatText.text = "";
            textScript.letterDelay = textScript.letterDelayDefault;
            if (textTracker == textScript.sentences.Length)
            {
                textBox.SetActive(false);
                canMoveEvent.Invoke();
            }
            else
            {
                textBox.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && textBox.activeSelf == true)
        {
            textScript.letterDelay = 0;
        }
    }
    IEnumerator Cutscene1()
    {
        yield return new WaitForSeconds(0.07f);
        textScript.triggerName(0);
        textScript.triggerText(textTracker);
        if (textTracker != textScript.sentences.Length)
        {
            textBox.SetActive(true);
        }
    }
}
