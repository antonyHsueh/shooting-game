using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{

    public GameObject cam;
    //public GameObject borader;
    //public PolygonCollider2D c;
    // Start is called before the first frame update
    void Start()
    {
        //cam = this.transform.Find("CM vcam1").gameObject;
        cam.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").transform;
        //c = this.transform.Find("CameraChangeBorder").GetComponent<PolygonCollider2D>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            cam.SetActive(true);
        }
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            cam.SetActive(false);
        }
    }
    
}
