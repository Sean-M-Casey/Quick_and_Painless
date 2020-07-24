using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPolterDialogue : MonoBehaviour
{
    bool startDialogue;
    public GameObject player;
    public GameObject textEndIcon;
    public GameObject tutPromptBox;
    public TextMesh tutPromptText;
    // Start is called before the first frame update
    void Start()
    {
        tutPromptBox.SetActive(false);
        tutPromptText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        tutPromptBox.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tutPromptBox.SetActive(false);
            tutPromptText.text = "";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!startDialogue) {
            if (Input.GetKeyDown(KeyCode.E))
            {
                startDialogue = true;
            }
        }
        if (startDialogue)
        {
            if (textEndIcon == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    StartCoroutine(Dialogue());
                    startDialogue = false;
                }
            }
        }
    }
    IEnumerator Dialogue()
    {
        tutPromptBox.SetActive(true);
        tutPromptText.text = "Press TAB to open PolterPad";
        yield return new WaitForSeconds(2f);
    }
}
