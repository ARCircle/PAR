using UnityEngine;
using System.Collections;

//BGM管理スクリプト
//イントロと、ループ音源をそれぞれ用意すれば後は勝手にやってくれる
//スタートディレイ機能付き

public class BGMManager : MonoBehaviour {

    public AudioClip BGMIntro;
    public AudioClip BGMLoop;

    public float DeraydStartTime = 0.0f;
    private bool IntroPlayed = false;

    private AudioSource ASIntro;
    private AudioSource ASLoop;
    private float IntroLeng;

    private float timer = 0.0f;
    private float audioTimer = 0.0f;
	// Use this for initialization
	void Start () {

        ASIntro = gameObject.AddComponent<AudioSource>();
        ASIntro.clip = BGMIntro;
        ASIntro.playOnAwake = false;
        ASLoop = gameObject.AddComponent<AudioSource>();
        ASLoop.clip = BGMLoop;
        ASLoop.loop = true;
        ASLoop.playOnAwake = false;

        IntroLeng = BGMIntro.length;

        //読み込みデータ表示
        //StartDebug();


	}

    private void StartDebug()
    {
        Debug.Log("BGMIntro:" + BGMIntro.frequency + "," + BGMIntro.channels + "," + BGMIntro.length);
        Debug.Log("BGMLoop:" + BGMLoop.frequency + "," + BGMLoop.channels + "," + BGMLoop.length);
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if(timer < DeraydStartTime)
        {
            return;
        }

        AudioPlayer();
	
	}

    private void AudioPlayer()
    {
        if (!IntroPlayed)
        {
            ASIntro.Play();
            ASLoop.PlayDelayed(IntroLeng);
            IntroPlayed = true;
            audioTimer = 0.0f;
        }
        audioTimer += Time.deltaTime;

        //AudioPLayerDebug();
    }

    private void AudioPLayerDebug()
    {
        Debug.Log(ASLoop.time);
    }
}
