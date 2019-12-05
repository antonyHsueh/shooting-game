using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Animator anim;
    public LayerMask ground;
    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }
    void SwitchAnim()
    {
        anim.SetFloat("running_x", 0);
        anim.SetFloat("running_y_front", 0);
        anim.SetFloat("running_y_back", 0);
        //

    }
    void Movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedirection_x = Input.GetAxisRaw("Horizontal");
        // float facedirection_y = Input.GetAxisRaw("Vertical");
        float vertical = Input.GetAxis("Vertical");

        //角色移动
        if (horizontalmove != 0 ||vertical !=0)
        {
            rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime, vertical * speed * Time.deltaTime);
            anim.SetFloat("running_x", Mathf.Abs(facedirection_x));

            
            if (vertical > 0)
            {
                anim.SetFloat("running_y_back", Mathf.Abs(vertical));
            }
            else
            {
                anim.SetFloat("running_y_front", Mathf.Abs(vertical));
            }
        }


        if (facedirection_x != 0)
        {
            transform.localScale = new Vector3(facedirection_x, 1, 1);
        }





            //动画状态转换
            //  SwitchAnim();
        
    }
}