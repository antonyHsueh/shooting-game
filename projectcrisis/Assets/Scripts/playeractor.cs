using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeractor : MonoBehaviour
{
    public GameObject modle;
    public playerinput pi;
    public Rigidbody2D rigid2d;
    public float walkspeed=5.0f;
    public Animator animbody;
    public Animator animhead;
    public SpriteRenderer sr;


    void Awake()
    {
        pi = GetComponent<playerinput> ();
        rigid2d = GetComponent<Rigidbody2D> ();
        animbody = transform.Find("body").GetComponent<Animator>();
        animhead = transform.Find("head").GetComponent<Animator>();
        //modle = this.gameObject.transform.GetChild(0).gameObject;
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
        
        animbody.SetFloat("vecx", Mathf.Abs(pi.dvec.x));
        animbody.SetFloat("vecy", pi.dvec.y);
        animhead.SetFloat("vecx", Mathf.Abs(pi.dvec.x));
        animhead.SetFloat("vecy", pi.dvec.y);
        if (pi.dvec.x < 0)
        {
            transform.Find("body").GetComponent<SpriteRenderer>().flipX = true;
            transform.Find("head").GetComponent<SpriteRenderer>().flipX = true;

        }
        else
        {
            transform.Find("body").GetComponent<SpriteRenderer>().flipX = false;
            transform.Find("head").GetComponent<SpriteRenderer>().flipX = false;
        }
        
    }
}
