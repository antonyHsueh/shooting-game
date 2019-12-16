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
        Vector3 bullet_position = GameObject.FindGameObjectWithTag("Player").transform.position;
        bullet_position += new Vector3(pi.dvec.x * 2.0f, pi.dvec.y * 2.0f, 0);
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

