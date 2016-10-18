using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


//ゲーム管理
//1ゲーム中のクリアとかを見てる
//
//ポーズ判定(未実装)
//複数ゲームモード(未実装)　＊勇者が複数人のパターンとか
//ゲームタイムとかlogとかの情報(未実装）
//ゲーム終了後の遷移（未実装）

public class CT : MonoBehaviour {


    public GameObject clearbarner;
    public GameObject falsebarner;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void gameClear()
    {

        Quaternion rot = new Quaternion();
        Vector3 pos = new Vector3( 0,0, 0);
        GameObject.Instantiate(clearbarner, pos, rot);
        Debug.Log("Clear");

		//yield WaitForSeconds(3); 
		//タイトルに遷移
		SceneManager.LoadScene("title");
    }

    void gameFalse()
    {
        Quaternion rot = new Quaternion();
        Vector3 pos = new Vector3(0,0,0);
        GameObject.Instantiate(falsebarner, pos, rot);
        Debug.Log("Failed");

		//yield WaitForSeconds(3); 
		//タイトルに遷移
		SceneManager.LoadScene("title");

    }

    public void gameRestart()
    {
        Application.LoadLevel("tst");
    }
}
