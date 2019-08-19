using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("Start Method");
	}
	
	// Update is called once per frame
	void Update () {
        print("Update Method");
	}

    private void Awake()
    {
        print("Awake Method");
    }
}
