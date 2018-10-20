using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float maxDistance;

    private Vector3 offset;
    private Vector3 targetPos;

    void Start() {
        offset = transform.position - target.transform.position;
        targetPos = target.transform.position + offset;
    }

    void LateUpdate() {

        targetPos = target.transform.position + offset;

        if ((transform.position - targetPos).magnitude < 0.01f)
        {
            transform.position = targetPos;
        } else
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
        }
    }
}
