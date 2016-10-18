using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//AIのデバッグ用
//休止中

public class yAIDebug : MonoBehaviour {

    public bool showDebug = false;
   
    private int cellH, cellW;

    //GameObject Cell;
    string[,] Cellinfo;


	// Use this for initialization
	void Start () {
	
	}

    public void setUp(int i, int j)
    {
        cellH = i;
        cellW = j;
        Cellinfo = new string[i, j];
       // DispPosSet();
    }


	
	// Update is called once per frame
	void Update () {
           
  
       
	
	}

    void OnGUI()
    {
        if (showDebug)
        {
            for (int i = 0; i < cellH; i++)
                    {
                        for (int j = 0; j < cellW; j++)
                        {
                             GUI.Label(new Rect((float)j / (float)cellW *(float)Screen.width, (float)i / (float)cellH *(float)Screen.height, Screen.width /cellW , Screen.height / cellH), Cellinfo[i, j]);
                        }
                    }
        }
        
    }

    void DispPosSet()
    {
        for(int i = 0; i < cellH; i++)
        {
            for(int j = 0; j < cellW; j++)
            {
                
               
               
            }
        }
    }

    public void setCellinfo(int i, int j ,string str)
    {
        Cellinfo[i, j] = str;

    }
}
