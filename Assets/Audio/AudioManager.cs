using UnityEngine;
using System.Collections;

//(仮）
//オーディオ関係のスーパークラス作ろうとしたけどやっぱやめた

public class AudioManager : MonoBehaviour {

    public AudioClip audioClip;

    private AudioSource AS;
	// Use this for initialization


	void Start () {

        AS = this.gameObject.AddComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void adPlay()
    {

    }



}
