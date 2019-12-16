using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public boardmanager boardscript;
    public GenerateMazeAlgoritnm m;
    // Start is called before the first frame update
    void Awake()
    {
        boardscript = GetComponent<boardmanager>();
        m = GetComponent<GenerateMazeAlgoritnm>();
    }
    void Start()
    {
        Initgame();
    }
    void Initgame()
    {
        //m.Gnerator();
        boardscript.setup();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    

}
