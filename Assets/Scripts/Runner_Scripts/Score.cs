using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EndlessRunner
{
    public class Score : MonoBehaviour {
        public Text scoreText;
        private float score = 0.0f;
        private bool isPlayerDead = false;
        public GameOver gameOver; 

	    // Update is called once per frame
	    void Update () {
            if(isPlayerDead)
            {
                return;
            }
            score += Time.deltaTime;
            scoreText.text = ((int)score).ToString();
	    }

        public void OnDeath()
        {
            isPlayerDead = true;

            gameOver.ToggleGameOverMenu(score);
        }
    }
}

