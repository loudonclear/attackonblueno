using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {

    public GameObject PlayerGameObject;
    public float timer = 0f;
    public float speed = 2f;

    public int tempCollisionCounter = 1;

    public float RotateSpeed = 4f;
    public float Radius = 0.1f;

    private float angle;

    private bool readyToMoveRegularly = true;


    // Use this for initialization
    void Start () {
        PlayerGameObject = GameObject.FindGameObjectWithTag("PlayerTag");
    }
	
	// Update is called once per frame
	void Update () {

        //Temp design: Move up and down periodically, and when the player moves ahead, the light moves to be in
        //front of player
        this.regularLightMovement();

        /*
        if (transform.position.x + 3 < PlayerGameObject.transform.position.x && readyToMoveRegularly)
        {
            readyToMoveRegularly = false;
            this.MoveLightForward();
            
        }
        else if (readyToMoveRegularly)
        {
            this.regularLightMovement();
        }
        */

    }

    public void regularLightMovement()
    {
        timer += Time.deltaTime;

        transform.Translate(Vector2.up * Time.deltaTime * speed);

        if (timer >= 3)
        {
            speed = -speed;
            timer = 0;
        }

        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * Radius;
        transform.position = transform.position + offset;

        if (transform.position.x + 3 < PlayerGameObject.transform.position.x)
        {
            transform.Translate(Vector2.right * 8);
        }
    }

    public void MoveLightForward()
    {
        while(transform.position.x + 4 < PlayerGameObject.transform.position.x)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }
        
        readyToMoveRegularly = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerTag" && collision.gameObject.layer == 0)
        {
            print("Collision " + tempCollisionCounter);
            tempCollisionCounter++;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            print("Collision with Enemy");
            collision.gameObject.GetComponentInChildren<Light>().intensity = 3;
        }
    }
}
