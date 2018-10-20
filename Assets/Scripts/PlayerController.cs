using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5;
    public float jumpVelocity = 5;
    public float fallMultiplier = 2.5f;
    public float lowJumpmultiplier = 2f;

    private Rigidbody rb;
    private SpriteRenderer spr;

	void Awake () {
        rb = GetComponent<Rigidbody>();
        spr = GetComponent<SpriteRenderer>();
	}

    void Update()
    {
        float jmp = rb.velocity.y;
        float hrz = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && (Physics.Raycast(transform.position + new Vector3(spr.bounds.extents.x, 0, 0), Vector3.down, 2*spr.bounds.extents.y + 0.5f) || 
                                            Physics.Raycast(transform.position - new Vector3(spr.bounds.extents.x, 0, 0), Vector3.down, 2*spr.bounds.extents.y + 0.5f)))
        {
            jmp += jumpVelocity;
        } 

        rb.velocity = new Vector3(speed * hrz, jmp, 0);

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpmultiplier - 1) * Time.deltaTime;
        }
    }
	
	
}
