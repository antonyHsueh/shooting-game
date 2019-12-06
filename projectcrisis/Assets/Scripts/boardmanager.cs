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
    public int rows = 7;
    public GameObject[] mapT;
    public GameObject[] Player;
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
        GameObject player = Instantiate(Player[0], new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
        player.transform.SetParent(boardholder);
        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j< columns; j++)
            {
                if( m.mapbit[i,j] != 0)
                {
                    GameObject tomake = mapT[Random.Range(0, mapT.Length)];
                    Vector3 ranpios = new Vector3(i*25f, j*25f, 0f); 
                    GameObject instance = Instantiate(tomake, ranpios, Quaternion.identity) as GameObject;

                    maketunnel(i, j, instance);

                    instance.transform.SetParent(boardholder);
                }
            }
            
        }
        
    }

    void maketunnel(int i,int j,GameObject inst)
    {
        for(int k = 0; k < 4; k++)
        {
            switch (k)
            {
                case 0:
                    if(i + 1 < rows)
                    {
                        if(m.mapbit[i+1,j] != 0)
                        {
                            inst.transform.Find("Tunnel_Right").gameObject.SetActive(true);
                        }
                        else
                        {
                            inst.transform.Find("Board_Right").gameObject.SetActive(true);
                        }
                    }
                    else
                    {
                        inst.transform.Find("Board_Right").gameObject.SetActive(true);
                    }
                    break;
                case 1:
                    if (i - 1  >=  0)
                    {
                        if (m.mapbit[i - 1, j] != 0)
                        {
                            inst.transform.Find("Tunnel_Left").gameObject.SetActive(true);
                        }
                        else
                        {
                            inst.transform.Find("Board_Left").gameObject.SetActive(true);
                        }
                    }
                    else
                    {
                        inst.transform.Find("Board_Left").gameObject.SetActive(true);
                    }
                    break;
                case 2:
                    if (j + 1 < columns)
                    {
                        if (m.mapbit[i , j + 1] != 0)
                        {
                            inst.transform.Find("Tunnel_Up").gameObject.SetActive(true);
                        }
                        else
                        {
                            inst.transform.Find("Board_Up").gameObject.SetActive(true);
                        }
                    }
                    else
                    {
                        inst.transform.Find("Board_Up").gameObject.SetActive(true);
                    }
                    break;
                case 3:
                    if (j - 1 >= 0)
                    {
                        if (m.mapbit[i, j - 1 ] != 0)
                        {
                            inst.transform.Find("Tunnel_Down").gameObject.SetActive(true);
                        }
                        else
                        {
                            inst.transform.Find("Board_Down").gameObject.SetActive(true);
                        }
                    }
                    else
                    {
                        inst.transform.Find("Board_Down").gameObject.SetActive(true);
                    }
                    break;
            }

        }
    }


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


