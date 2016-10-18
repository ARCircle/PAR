using UnityEngine;
using System.Collections;

public class yAICamModure : MonoBehaviour {

    public int cellScale = 10;

    [SerializeField] private AICamView AiCamBase;
    [SerializeField] private AICamView[,] AIViewGrid;

    [SerializeField] yAIDebug yAI_debug;
    
    

    [SerializeField] private int scrCellW;
    [SerializeField] private int scrCellH;

    [SerializeField] private bool showDebug = false;
    enum DebugState
    {
        screenPodition,
        worldPosition,
        weight
    };
    [SerializeField]
    private DebugState sDs = DebugState.weight;

    Camera Cam;
    Vector3 scpos;
    Vector3 wlpos;


    // Use this for initialization
    void Start () {

        AiCamBase = GetComponent<AICamView>();
        yAI_debug = GetComponentInChildren<yAIDebug>();
        Cam = GetComponent<Camera>();
        scrCellW = Screen.width / cellScale;
        scrCellH = Screen.height / cellScale;

        AIViewGrid = new AICamView[scrCellH,scrCellW];
        //Debug.Log("grid:" + AIViewGrid.GetLength(0) + "," + AIViewGrid.GetLength(1));

        
        int weg = AiCamBase.weightMax;

        for(int i = 0; i < scrCellH ; i++)
        {
            for(int j = 0; j < scrCellW; j++)
            {
               // Debug.Log(i + "," + j);
                AIViewGrid[i, j] = new AICamView();
                scpos = new Vector3((float)j / (float)scrCellW  * Screen.width, (float)(scrCellH - i) / (float)scrCellH * Screen.height, 0);
                AIViewGrid[i, j].scrPos = scpos;

                scpos.z = Cam.nearClipPlane;
                wlpos = Cam.ScreenToWorldPoint(scpos);
                
                AIViewGrid[i, j].wldPos = wlpos;
                AIViewGrid[i, j].weight = weg;

            }
        }

        //Debug.Log("grid[1,1]:" + AIViewGrid[1, 1].weight + "," + AIViewGrid[1,1].wldPos + "," + AIViewGrid[1, 1].scrPos);

        yAI_debug.setUp(scrCellH,scrCellW);
    }

    // Update is called once per frame
    void FixedUpdate () {

        // Debug.Log("grid[1,1]:" + AIViewGrid[1,1].weight.GetType() + "," + AIViewGrid.GetLength(1));
        for (int i = 0; i < scrCellH; i++)
        {
            for (int j = 0; j < scrCellW; j++)
            {
                scpos = new Vector3( (float)j / (float)scrCellW * Screen.width, (float)(scrCellH - i) / (float)scrCellH * Screen.height, 0);
                scpos.z = Cam.nearClipPlane;
                wlpos = Cam.ScreenToWorldPoint(scpos);
                wlpos.z = 0;
                AIViewGrid[i, j].wldPos = wlpos; ;
            }
        }



                DebugMode();
	    
	}

    void makeCell()
    {

    }

    void DebugMode()
    {
        if (showDebug)
        {
            yAI_debug.showDebug = true;

            for (int i = 0; i < scrCellH; i++) {
                for (int j = 0; j < scrCellW; j++) {
                    
                    switch (sDs)
                    {

                        case DebugState.screenPodition:
                            yAI_debug.setCellinfo(i, j, AIViewGrid[i, j].scrPos.ToString()); break;

                        case DebugState.worldPosition:
                            yAI_debug.setCellinfo(i, j, AIViewGrid[i, j].wldPos.ToString()); break;

                        case DebugState.weight:
                            yAI_debug.setCellinfo(i, j, AIViewGrid[i, j].weight.ToString()); break;

                    }
                }
            }
        }
        else
        {
            yAI_debug.showDebug = false;
        }
    }
}
