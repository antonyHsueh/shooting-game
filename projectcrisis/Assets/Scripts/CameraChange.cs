using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{

    public GameObject cam;
    public GameObject []enemy;
    public GameObject control;
    private List<Vector3> gridposition = new List<Vector3>();

    private void Initialiselist()
    {
        gridposition.Clear();
        for (int x = -10; x <= 10; x++)
        {
            for (int y = -10; y < 10; y++)
            {
                gridposition.Add(new Vector3(x, y, 0));
            }
        }
    }


    //public GameObject borader;
    //public PolygonCollider2D c;
    // Start is called before the first frame update
    private void Awake()
    {
        control = GameObject.FindGameObjectWithTag("GameController");
    }
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
    private void Makenemy(int value)
    {
        Initialiselist();
        for (int i = 0; i< value;i++)
        {
            int randomindex = Random.Range(0, gridposition.Count);
            GameObject tomake = enemy[Random.Range(0, enemy.Length)];
            Vector3 ranpios = gridposition[randomindex] + transform.position;
            GameObject instance = Instantiate(tomake, ranpios, Quaternion.identity) as GameObject;
            gridposition.RemoveAt(randomindex);
            instance.transform.SetParent(transform);
        }
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            cam.SetActive(true);
            int tx = (int)transform.position.x / 25;
            int ty = (int)transform.position.y / 25;
            if (control.GetComponent<GenerateMazeAlgoritnm>().mapbit[tx,ty] == 1)
            {
                control.GetComponent<GenerateMazeAlgoritnm>().mapbit[tx, ty] = 2;
                Makenemy(5);
                
                Debug.Log("enemyappear");
            }




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
