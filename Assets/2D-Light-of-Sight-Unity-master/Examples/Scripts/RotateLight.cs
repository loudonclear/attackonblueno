using UnityEngine;
using System.Collections;
using LOS;

public class RotateLight : MonoBehaviour {

	public LOSLightBase coneLight;
	public float minAngle, maxAngle;
	public float speed;

    private float initAngle;

    void Start()
    {
        initAngle = coneLight.faceAngle;
    }

	void Update () {

        if (coneLight.faceAngle - initAngle > maxAngle || coneLight.faceAngle - initAngle < minAngle)
        {
            speed = -speed;
        }

        coneLight.faceAngle += speed * Time.deltaTime;
	}
}
