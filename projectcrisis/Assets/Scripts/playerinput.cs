using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinput : MonoBehaviour
{
    // variable
    public string keyup  = "w";   
    public string keydown = "s";    
    public string keyright = "d";   
    public string keyleft = "a";  
    public string keyfire = "Fire1";
    public float dup;
    public float dright;        
    public float dmag;
    public Vector2 dvec;
    private float targetdup;
    private float targetdright;
    private float velocitydup;
    private float velocitydright;
    public bool inputEnable = true;
    public Vector2 mouse2d;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetdup = (Input.GetKey(keyup)?1.0f:0) - (Input.GetKey(keydown)?1.0f:0);
        targetdright = (Input.GetKey(keyright)?1.0f:0) - (Input.GetKey(keyleft)?1.0f:0);
        if(inputEnable == false)
        {
            dup = 0;
            dright = 0;
        }
        dup = Mathf.SmoothDamp(dup,targetdup,ref velocitydup,0.1f);
        dright = Mathf.SmoothDamp(dright,targetdright,ref velocitydright,0.1f);
        Vector2 tempDaxi = SquareToCircle(new Vector2(dright, dup));
        float dupc = tempDaxi.y;
        float drightc = tempDaxi.x;


        dmag = Mathf.Sqrt((dupc*dupc)+(drightc*drightc));
        dvec = drightc*transform.right+dupc*transform.up;


        Vector3 i = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse2d = new Vector2(i.x, i.y);
    }

    private Vector2 SquareToCircle(Vector2 input)
    {
        Vector2 output = Vector2.zero;
        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f);
        return output;
    }
}
