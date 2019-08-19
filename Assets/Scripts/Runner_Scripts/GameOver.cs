using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EndlessRunner
{
    public class GameOver : MonoBehaviour {
        public Text scoreText;

	    // Use this for initialization
	    void Start () {
            gameObject.SetActive(false);
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        public void ToggleGameOverMenu(float score)
        {
            gameObject.SetActive(true);
            scoreText.text = ((int)score).ToString();
        }
    }
}

