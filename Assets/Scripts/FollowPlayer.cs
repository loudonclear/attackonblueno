using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    private Vector3 offset;
    public GameObject PlayerGameObject;

    // Use this for initialization
    void Start () {
        PlayerGameObject = GameObject.FindGameObjectWithTag("PlayerTag");
        offset = transform.position - PlayerGameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        /*
        transform.position = new Vector3(Mathf.Clamp(PlayerGameObject.transform.position.x, xMin, xMax), 
            Mathf.Clamp(PlayerGameObject.transform.position.y, yMin, yMax), PlayerGameObject.transform.position.z);
            */
    }

    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = PlayerGameObject.transform.position + offset;
    }
}
