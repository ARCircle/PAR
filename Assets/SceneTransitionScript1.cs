using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionScript1 : MonoBehaviour {

    string SceneName = "Opening";

    public void SceneLoad(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        
        //5.3から非推奨
        //Application.LoadLevel("Opening");
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
