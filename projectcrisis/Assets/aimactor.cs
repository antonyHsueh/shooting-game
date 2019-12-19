using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimactor : MonoBehaviour
{

    public playerinput pi;
    public Rigidbody2D rigid2d;
    public Vector2 aimdir;

    public GameObject aim;
    // Start is called before the first frame update
    void Start()
    {
        pi = GetComponent<playerinput>();
        rigid2d = GetComponent<Rigidbody2D>();
        aim = GameObject.Find("aim");
    }

    // Update is called once per frame
    void Update()
    {
        aimmovement();
    }

    void aimmovement()
    {
        aimdir = pi.mouse2d - rigid2d.position;
        aimdir /= aimdir.magnitude;
        aim.transform.position = aimdir * 2 + rigid2d.position;

    }

}
