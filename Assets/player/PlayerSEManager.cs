using UnityEngine;
using System.Collections;

//プレーヤードッスンのオーディオ、SEを総括して管理する用のとこ
//各スクリプトからここのplayメソッド群を呼び出して再生する

public class PlayerSEManager : MonoBehaviour {

    public AudioClip HitGround;

    private AudioSource ASHitGnd;
	// Use this for initialization
	void Start () {

        ASHitGnd = gameObject.AddComponent<AudioSource>();
        ASHitGnd.playOnAwake = false;
        ASHitGnd.clip = HitGround;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    //Play method group

    public void playHitGnd()
    {
        ASHitGnd.PlayOneShot(HitGround);
    }
}
