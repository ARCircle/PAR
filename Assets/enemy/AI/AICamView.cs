using UnityEngine;
using System.Collections;

public class AICamView : MonoBehaviour {

    public Vector2 scrPos;
    public Vector3 wldPos;
    public int weight;

    public int weightMax = 999999;



    //=============================




	// Use this for initialization
	void Start () {
        Debug.Log("AICamView:" + scrPos + "," + wldPos + "," + weight);
	}

    //使わないかも  
    public static AICamView Instantiate(AICamView Pf,Vector2 parm1, Vector3 parm2, int parm3)
    {
        AICamView obj = Instantiate(Pf) as AICamView;
        obj.scrPos = parm1;
        obj.wldPos = parm2;
        obj.weight = parm3;

        return obj;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
