using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallMoveScene : MonoBehaviour
{
    public GameObject wallTrigger;
    public GameObject wallGlow;
    public GameObject WASD;
    public GameObject textBox;
    public GameObject player;
    public GameObject tutPrompts;
    public GameObject textEndIcon;
    PlayerControls playerControls;
    public TextMesh tutPromptText;
    TextWritingScript textScript;
    public string[] tutPromptMsg;
    int textTracker = 16;
    bool isColliding;
    bool wallFlashHasRun;
    // Start is called before the first frame update
    void Start()
    {
        textScript = GameObject.Find("WorldScriptHolder").GetComponent<TextWritingScript>();
        playerControls = player.GetComponent<PlayerControls>();
        wallGlow.GetComponent<Animator>().SetBool("startGlow", false);
    }

    // Update is called once per frame
    void Update()
    {
        tutPrompts.transform.position = new Vector3(player.transform.position.x - 2, player.transform.position.y + 2, player.transform.position.z);
        if (WASD.activeSelf == false && textBox.activeSelf == false)
        {
            StartCoroutine(turnOnFlash());
            if (wallFlashHasRun)
            {
                StartCoroutine(WallFlash());
            }
        }
        else
        {
            wallGlow.GetComponent<Animator>().SetBool("startGlow", false);
        }
        if (textEndIcon.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                textBox.SetActive(false);
                playerControls.canMove = true;
                tutPromptText.text = tutPromptMsg[1];
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == wallTrigger.name)
        {
            wallGlow.GetComponent<Animator>().SetBool("startGlow", false);
            tutPrompts.SetActive(true);
            tutPromptText.text = tutPromptMsg[0];
        }
    }
    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.name == "Foyer_Wall 1")
        {
            isColliding = true;
            StartCoroutine(WallPrompt1());
        }
    }
    private void OnCollisionExit(Collision collide)
    {
        if (collide.gameObject.name == "Foyer_Wall 1")
        {
            isColliding = false;
        }
    }
    IEnumerator WallPrompt1()
    {
        yield return new WaitForSeconds(5f);
        tutPromptText.text = "";
        if (isColliding)
        {
            Debug.Log("yes");
        }
        playerControls.canMove = false;
        textBox.SetActive(true);
        textScript.triggerText(textTracker);
    }
    IEnumerator WallFlash()
    {
            wallGlow.GetComponent<Animator>().SetBool("startGlow", true);
            yield return new WaitForSeconds(5f);
            wallGlow.GetComponent<Animator>().SetBool("startGlow", false);
    }
    IEnumerator turnOnFlash()
    {
        yield return new WaitForSeconds(2f);
        wallFlashHasRun = true;
    }
}
