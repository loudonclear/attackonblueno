using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLight : MonoBehaviour {

    public float timer = 0f;
    public float timerMax = 2.5f;
    public float speed = 2f;
    public GameObject PlayerGameObject;

    // Use this for initialization
    void Start () {
        PlayerGameObject = GameObject.FindGameObjectWithTag("PlayerTag");
        timerMax = 2.5f + Random.value;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (PlayerGameObject.transform.position.x - 5 > this.transform.position.x)
        {
            speed = Mathf.Abs(speed);
            timer = 0;
            timerMax = 2.5f + Random.value;
            FollowPlayerMovement();
        }
        else
        {
            regularMovement();
        }     
    }

    void regularMovement()
    {
        timer += Time.deltaTime;

        transform.Translate(Vector2.right * Time.deltaTime * speed);

        if (timer >= timerMax)
        {
            speed = -speed;
            timer = 0;
            timerMax = 2.5f + Random.value;
        }
    }

    void FollowPlayerMovement()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed * 2f);
    }
}
