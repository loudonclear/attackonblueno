using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Light spotlight;

	// Use this for initialization
	void Start () {
        spotlight = this.gameObject.GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
