using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public GameObject[] Weapons;
    public int current_weapon = 0;
    public GameObject Sbullet;
    public playerinput pi;
    private Transform boardholder;
    // Start is called before the first frame update
    void Start()
    {
        pi = GetComponent<playerinput>();
       
        // rb = GetComponent<Rigidbody2D>();
    }

  
    // Update is called once per frame
    void FixedUpdate()
    {
        CheckButton();
    }


    void CheckButton()
    {
        //子弹初始位置
        Vector2 bullet_position = GetComponent<Rigidbody2D>().position;
        bullet_position = pi.mouse2d - bullet_position;
        bullet_position /= bullet_position.magnitude;
        bullet_position *= 1.5f;
        bullet_position += GetComponent<Rigidbody2D>().position;

        boardholder = GameObject.FindGameObjectWithTag("Board").transform;
            //如果开火键1被按下
            if (Input.GetButtonDown(pi.keyfire))
            {
                GameObject tomake = Weapons[current_weapon];
                //检测当前武器
                GameObject ins = Instantiate(tomake, bullet_position, Quaternion.identity) as GameObject;

                ins.transform.SetParent(boardholder);
            }
              
    }
  
}

