using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


//bitmapvalue 0:wall 1:road 2:start 3:end
enum Dir { up,right,down,left}


public class GenerateMazeAlgoritnm : MonoBehaviour
{
    public boardmanager boardscript;
    public int columns;
    public int rows;
    public int[,] mapbit;
    struct Node
    {
        
        public int x, y;
        public Dir d;
        
    }

    private static List<Node> walls = new List<Node>();


    void Awake()
    {
        boardscript = GetComponent<boardmanager>();
        columns = boardscript.columns;
        rows = boardscript.rows;
        mapbit = new int[rows,columns];
        for (int i = 0; i < rows; i++) 
        {
            for (int j = 0; j < columns; j++)
            {
                mapbit[i, j] = 0;
            }
        }
    }
    private bool Bordertest(int x ,int y)
    {
        if (x < 0 || y < 0 || y > columns - 1 || x > rows - 1)
            return false;
        return true;
    }


    private void addnearbywall(int x, int y)
    {
        int count = 0;
        for (count = 0; count < 4; count++) 
        {
            switch (count)
            {
                case 0:
                    if (Bordertest(x,y+1) && mapbit[x, y + 1] == 0) 
                    {
                        Node temp = new Node();
                        temp.x = x;
                        temp.y = y + 1;
                        temp.d = Dir.up;
                        walls.Add(temp);
                    }
                    break;
                case 1:
                    if (Bordertest(x + 1, y) && mapbit[x + 1, y] == 0) 
                    {
                        Node temp = new Node();
                        temp.x = x + 1;
                        temp.y = y;
                        temp.d = Dir.right;
                        walls.Add(temp);
                    }
                    break;
                case 2:
                    if (Bordertest(x, y - 1) && mapbit[x, y - 1] == 0) 
                    {
                        Node temp = new Node();
                        temp.x = x;
                        temp.y = y - 1;
                        temp.d = Dir.down;
                        walls.Add(temp);
                    }
                    break;
                case 3:
                    if (Bordertest(x - 1, y) && mapbit[x - 1, y] == 0)
                    {
                        Node temp = new Node();
                        temp.x = x - 1;
                        temp.y = y;
                        temp.d = Dir.left;
                        walls.Add(temp);
                    }
                    break;
            }
        }
        

    }

    public void Gnerator()
    {
        int startx = 0;
        int starty = 0;

        mapbit[startx, starty] = 2;

        addnearbywall(startx, starty);

        while(walls.Count > 0)
        {
            int randomindex = Random.Range(0, walls.Count);
            Node temp = walls[randomindex];
            walls.RemoveAt(randomindex);
            switch(temp.d)
            {
                case Dir.up:
                    if (Bordertest(temp.x, temp.y + 1)) 
                    {
                        if(mapbit[temp.x, temp.y + 1] == 0)
                        {
                            mapbit[temp.x, temp.y] = 1;
                            mapbit[temp.x, temp.y + 1] = 1;
                            addnearbywall(temp.x, temp.y + 1);
                        }
                        
                    }
                    break;
                case Dir.right:
                    if (Bordertest(temp.x + 1, temp.y))
                    {
                        if (mapbit[temp.x + 1, temp.y] == 0)
                        {
                            mapbit[temp.x, temp.y] = 1;
                            mapbit[temp.x + 1, temp.y] = 1;
                            addnearbywall(temp.x + 1, temp.y);
                        }
                    }
                    break;
                case Dir.down:
                    if (Bordertest(temp.x, temp.y - 1))
                    {
                        if (mapbit[temp.x, temp.y - 1] == 0)
                        {
                            mapbit[temp.x, temp.y] = 1;
                            mapbit[temp.x, temp.y - 1] = 1;
                            addnearbywall(temp.x, temp.y - 1);
                        }
                    }
                    break;
                case Dir.left:
                    if (Bordertest(temp.x - 1, temp.y))
                    {
                        if (mapbit[temp.x - 1, temp.y] == 0)
                        {
                            mapbit[temp.x, temp.y] = 1;
                            mapbit[temp.x - 1, temp.y] = 1;
                            addnearbywall(temp.x - 1, temp.y);
                        }
                    }
                    break;
            }

        }

    }

}
