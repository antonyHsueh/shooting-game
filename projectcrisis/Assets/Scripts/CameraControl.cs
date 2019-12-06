using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform GameObject;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(GameObject.position.x, GameObject.position.y, -10f);
    }
}
