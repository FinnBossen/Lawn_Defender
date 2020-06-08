using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotateSpeed = 3f;
    public float speed = 1f;
    bool isGrounded = false;
    bool Jump = false;
    public float JumpForce = 20.0f;
    

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Jump)
        {

            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            Debug.Log("Jump");
            Jump = false;
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    


        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);

        if (Input.GetKeyDown("space") && isGrounded)
        {
            Jump = true;
        }
    }


    void OnCollisionStay(Collision other)
    {

        if (other.gameObject.tag == "isGround")
        {
            isGrounded = true;

        }


    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pfandflasche")
        {
            GameManager.PfandCoins++;
            Destroy(other.gameObject);

        }

    }




}
