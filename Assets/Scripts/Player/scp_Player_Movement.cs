using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Player_Movement : MonoBehaviour
{
    //Reference to the player's rigidbody component
    Rigidbody rb;

    //Variables storing the movement and rotation speed of the object
    public float speed = 5f;
    public float rotateSpeed = 50f;

    //Audio source and clip
    public AudioSource source;
    public AudioClip clip;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rb.MovePosition(transform.position + input * Time.deltaTime * speed);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.L))
        {
            //Rotates the object clockwise along the Y axis
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.K))
        {
            //Rotates the object anti-clockwise along the Y axis
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            //Plays audio
            source.PlayOneShot(clip);
        }
    }
}
