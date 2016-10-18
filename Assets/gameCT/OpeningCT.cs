using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//　ゲーム起動時のスプラッシュなどのオープニングを管理・制御

public class OpeningCT : MonoBehaviour {

    public string nextScene = "";


    private int stage = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        switch (stage)
        {
            case 0: SplashARLogo(); break;
            case 1: Application.LoadLevel(nextScene); break;
        }
	
	}

    public Image ARlogo;
    public float fadeTime;
    public float stayTime;
    private int ARlogoMode = 0;
    private float fadeTimer = 0f;
    private void SplashARLogo()
    {
        switch (ARlogoMode)
        {
            case 0:
                ARlogo.color = new Color(1, 1, 1, 0);
                ARlogoMode = 1;
                fadeTimer = 0.0f;
                break ;

            case 1:
                fadeTimer += Time.deltaTime;
                ARlogo.color = new Color(1, 1, 1, 1.0f / fadeTime * fadeTimer);
                if(fadeTimer > fadeTime)
                {
                    fadeTimer = 0.0f;
                    ARlogoMode = 2;
                    ARlogo.color = new Color(1, 1, 1, 1);
                }
                break;

            case 2:
                fadeTimer += Time.deltaTime;
                if(fadeTimer >= stayTime)
                {
                    fadeTimer = fadeTime;
                    ARlogoMode = 3;
                }
                break;

            case 3:
                fadeTimer -= Time.deltaTime;
                ARlogo.color = new Color(1, 1, 1, 1.0f / fadeTime * fadeTimer);
                if (fadeTimer <= 0.0)
                {
                    fadeTimer = 0.0f;
                    ARlogoMode = 4;
                }
                break;

            case 4:
                stage = 1;
                break;

        }
    }
}
