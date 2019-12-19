using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public Rigidbody2D rb_bullet;
    public float speed_bullet = 10.0f;
    public float lifetime = 100.0f;
    Vector2 direction_bullet;

    //float record_direction_x;
    //float record_direction_y;
    // Start is called before the first frame update
    void Start()
    {
        rb_bullet = GetComponent<Rigidbody2D>();
        /*
        record_direction_x = Input.GetAxisRaw("Horizontal");
        record_direction_y = Input.GetAxisRaw("Vertical");
        */
        direction_bullet = GameObject.FindGameObjectWithTag("Player").GetComponent<playerinput>().dvec;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fly_Bullet();
    }

    void Fly_Bullet()
    {
        rb_bullet.position += direction_bullet * speed_bullet * Time.fixedDeltaTime;
        lifetime -= Time.fixedDeltaTime;
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
    }
    
   
   
    
}
