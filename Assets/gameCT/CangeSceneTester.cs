using UnityEngine;
using System.Collections;

//とりあえずタイトルでなんかボタン押したらシーン遷移

public class CangeSceneTester : MonoBehaviour {

    public string nextScene = "";
    public int nextsceneIndex = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            Application.LoadLevel(nextsceneIndex);
        }
	
	}
}
