﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PushAnyKeyScript : MonoBehaviour {

    string SceneName = "menu";


	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            Debug.Log("pushed anykey");
            SceneManager.LoadScene(SceneName);
        }

	}
}
