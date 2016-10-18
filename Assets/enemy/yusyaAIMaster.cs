using UnityEngine;
using System.Collections;

//AIのマスター　総括管理（休止中）

public class yusyaAIMaster : MonoBehaviour {


    public float speed = 0;


    //そのうち消す
    public bool randomspeedStart = true;
    public float maxspd = 10;

	// Use this for initialization
	void Start () {

        if (randomspeedStart)
        {
            speed = Random.Range(1.0f, maxspd);
        }
	
	}
	
	// Update is called once per frame
	void Update () {

        moveLeft();
	
	}

    void moveLeft()
    {
        gameObject.transform.Translate(speed * Time.fixedDeltaTime , 0 , 0);
    }
}
