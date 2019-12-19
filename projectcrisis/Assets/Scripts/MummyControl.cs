using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyControl : MonoBehaviour
{
    public Rigidbody2D rigid2d;
    public float speed = 3;
    public Animator anim;
    public GameObject player;
    public Collider2D coll;
    public Vector2 dvec;
    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }
    void SwitchAnim()
    {

    }
    void Movement()
    {
        dvec = player.GetComponent<Rigidbody2D>().position - rigid2d.position;
        dvec /= dvec.magnitude;
        rigid2d.position += dvec * speed * Time.fixedDeltaTime;
        //角色移动
        anim.SetFloat("vecx", Mathf.Abs(dvec.x));
        anim.SetFloat("vecy", dvec.y);
        if (dvec.x < 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }









        //动画状态转换

    }
}
