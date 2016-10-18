using UnityEngine;
using System.Collections;

//勇者のSE総括管理
//Playメソッド群を呼び出して再生

public class yusyaSEManager : MonoBehaviour {

    public AudioClip jump;
    public AudioClip walk;
    public AudioClip death;
    public AudioClip apeal;

    private AudioSource ASjump;
    private AudioSource ASwalk;
    private AudioSource ASdeath;
    private AudioSource ASApeal;

    //歩行音は移動中毎フレーム呼び出しがかかるのでそのままならマシンガン再生となるので間隔を開けて再生させる用のタイマー
    public float walkRepeatTime = 0.5f;
    private float WRTclock = 0.0f;

	// Use this for initialization
	void Start () {

        ASjump = gameObject.AddComponent<AudioSource>();
        ASjump.clip = jump;
        ASjump.playOnAwake = false;
        ASwalk = gameObject.AddComponent<AudioSource>();
        ASwalk.clip = walk;
        ASwalk.playOnAwake = false;
        ASdeath = gameObject.AddComponent<AudioSource>();
        ASdeath.clip = death;
        ASdeath.playOnAwake = false;
        ASApeal = gameObject.AddComponent<AudioSource>();
        ASApeal.clip = apeal;
        ASApeal.playOnAwake = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        WRTclock += Time.deltaTime;
	
	}

    //SEPlayメソッド群
    public void playJump()
    {
        ASjump.PlayOneShot(jump);
    }
    public void playWalk()
    {
        ASwalk.PlayOneShot(walk);
    }
    public void playDeath()
    {
        ASdeath.PlayOneShot(death);
    }
    public void playApeal()
    {
        ASApeal.PlayOneShot(apeal);
    }

    //walkRepeatTimeで設定した間隔で歩行音を再生する　特殊Playメソッド
    //基本こっち使う
    public void playWalkInterval()
    {
        if(WRTclock <= walkRepeatTime)
        {

        }
        else
        {
            ASwalk.PlayOneShot(walk);
            WRTclock = 0.0f;
        }
    }


}
