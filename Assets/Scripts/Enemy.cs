using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Light spotlight;
    public GameObject PlayerGameObject;
    private bool enemyActivated = false;
    public float enemySpeed = 0f;
    private float timer = 0f;

	// Use this for initialization
	void Start () {
        spotlight = this.gameObject.GetComponentInChildren<Light>();
        PlayerGameObject = GameObject.FindGameObjectWithTag("PlayerTag");
    }
	
	// Update is called once per frame
	void Update () {
		if(spotlight.intensity == 3 && !enemyActivated)
        {
            enemyActivated = true;
        }

        if(enemyActivated)
        {
            transform.Translate(Vector2.left * Time.deltaTime * enemySpeed * spotlight.intensity);
            spotlight.intensity -= .05f;
            if(spotlight.intensity <= 0)
            {
                enemyActivated = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == PlayerGameObject && enemyActivated)
        {
            print("Enemy Colliding with Player");
        }
    }

}
