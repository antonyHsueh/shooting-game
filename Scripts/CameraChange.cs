using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{

    public Transform camera;
    public PolygonCollider2D c;
    // Start is called before the first frame update
    void Start()
    {
        camera = this.transform.Find("CM vcam1");
        c = this.transform.Find("CameraChangeBorder").GetComponent<PolygonCollider2D>();
        OnTriggerStay2D(c);
        OnTriggerExit2D(c);
    }



    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        camera.GetComponent<CinemachineVirtualCamera>().m_Priority = 20;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        camera.GetComponent<CinemachineVirtualCamera>().m_Priority = 10;
    }
}
