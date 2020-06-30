using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidBody;
    public Animator LucilleAnim;
    public GameObject mainCam;
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();    
    }
    void Update()
    {
        mainCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
        //Getting Direction for Movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Makes Character Move in regards to movement variable
        rigidBody.AddForce(movement * speed);
        
        //Removes velocity when movement keys are released so that player doesnt continue moving
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }

       // Movement Animator Triggers
        if (Input.GetKeyDown(KeyCode.A))
        {
            LucilleAnim.SetTrigger("Left_Walk");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            LucilleAnim.SetTrigger("Right_Walk");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            LucilleAnim.SetTrigger("Down_Walk");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            LucilleAnim.SetTrigger("Up_Walk");
        }
        else
        {
            LucilleAnim.SetTrigger("To_Idle");
        }
    }
}