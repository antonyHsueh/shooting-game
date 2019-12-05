using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeractor : MonoBehaviour
{
    public GameObject modle;
    public playerinput pi;
    public Rigidbody2D rigid2d;
    public float walkspeed=5.0f;
    public Animator anim;


    void Awake()
    {
        pi = GetComponent<playerinput> ();
        rigid2d = GetComponent<Rigidbody2D> ();
        modle = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rigid2d.position += pi.dvec * walkspeed * Time.fixedDeltaTime;
        
    }
}
