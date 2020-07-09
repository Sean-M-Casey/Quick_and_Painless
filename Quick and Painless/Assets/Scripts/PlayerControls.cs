using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidBody;
    public Animator LucilleAnim;
    public GameObject mainCam;
    public bool mouseLock;
    public float mainCamPosZ;
    public float mainCamDefaultPosZ = 13.38f;
    void Start()
    {
        mouseLock = false;
        rigidBody = gameObject.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        mainCamPosZ = -13.38f;
    }
    void Update()
    {
        mainCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, mainCamPosZ);
        //Getting Direction for Movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Makes Character Move in regards to movement variable
        rigidBody.AddForce(movement * speed);
        
        //Removes velocity when movement keys are released so that player doesnt continue moving
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }

       // Movement Animator Triggers
        if (moveHorizontal < 0)
        {
            LucilleAnim.SetTrigger("Left_Walk");
        }
        else if (moveHorizontal > 0)
        {
            LucilleAnim.SetTrigger("Right_Walk");
        }
        else if (moveVertical < 0)
        {
            LucilleAnim.SetTrigger("Down_Walk");
        }
        else if(moveVertical > 0)
        {
            LucilleAnim.SetTrigger("Up_Walk");
        }
        else
        {
            LucilleAnim.SetTrigger("To_Idle");
        }
    }
    //event trigger that changes state of mouselock
    public void UpdateMouseLock()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            StartCoroutine(Unlock());
        }
        else
        {
            StartCoroutine(Lock());
        }
    }
    private IEnumerator Unlock()
    {
        Cursor.lockState = CursorLockMode.Confined;
        yield return new WaitForSeconds(0.01f);
        Cursor.lockState = CursorLockMode.None;
    }
    private IEnumerator Lock()
    {
        Cursor.lockState = CursorLockMode.Confined;
        yield return new WaitForSeconds(0.01f);
        Cursor.lockState = CursorLockMode.Locked;
    }
}