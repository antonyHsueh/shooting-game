using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class boardmanager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimun;
        public int maxmiun;
        public Count(int min, int max)
        {
            minimun = min;
            maxmiun = max;
        }
    }
    public int columns = 5;
    public int rows = 5;
    public GameObject[] mapT;
    public GenerateMazeAlgoritnm m;

    private Transform boardholder;
    private List<Vector3> gridposition = new List<Vector3>();

    /*void Initialiselist()
    {
        gridposition.Clear();
        for (int x = 0; x < columns ; x++)
        {
            for (int y = 0; y < rows ; y++) 
            {
                gridposition.Add(new Vector3(x*20, y*20, 0));
            }
        }
    }*/

    Vector3 randomposition()
    {
        int randomindex = Random.Range(0, gridposition.Count);
        Vector3 rpois = gridposition[randomindex];
        gridposition.RemoveAt(randomindex);
        return rpois;
    }

    void boardsetup()
    {
        
        boardholder = new GameObject("Board").transform;
       
        for(int i = 0; i < m.rows; i++)
        {
            for(int j = 0; j< m.columns; j++)
            {
                if( m.mapbit[i,j] != 0)
                {
                    GameObject tomake = mapT[Random.Range(0, mapT.Length)];
                    Vector3 ranpios = new Vector3(i*25f, j*25f, 0f); 
                    GameObject instance = Instantiate(tomake, ranpios, Quaternion.identity) as GameObject;
                    //make Tunnel
                    instance.transform.SetParent(boardholder);
                }
            }
            
        }
    }

    //void


    public void setup()
    {
        //Initialiselist();
        m.Gnerator();
        boardsetup();
    }
    private void Awake()
    {
        m = GetComponent<GenerateMazeAlgoritnm>();
    }

}


