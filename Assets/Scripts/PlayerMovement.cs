using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D playerRigidBody;

    private float horizontal = 0.0f;
    public float playerSpeed = 5.0f;

    public float isGroundedRayLength = 0.1f;
    LayerMask layerMaskForGrounded;

    // Use this for initialization
    void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        playerRigidBody.velocity = new Vector2(horizontal * playerSpeed, playerRigidBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            this.gameObject.layer = 8;
            print("Player entered building");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            this.gameObject.layer = 0;
            print("Player left building");
        }
    }

}
