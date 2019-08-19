using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunner
{
    public class PlayerController : MonoBehaviour {
        private CharacterController playerController;
        private Vector3 moveVector;
        public float speed = 5.0f;
        public float jumpForce;
		public float time = 1f;
        private float verticalVelocity = 0.0f;
        private float gravityValue = 9.8f;
        private bool isPlayerDead = false;

	    void Start () {
            playerController = GetComponent<CharacterController>();
			time = Time.deltaTime;
	    }
	
	    void Update () {
//			if (Time.deltaTime > time + 10) {
//				speed += 1;
//				time = Time.deltaTime;
//			}

            if(isPlayerDead)
            {
                return;
            }

            moveVector = Vector3.zero;
            //if(playerController.isGrounded)
            if (playerController.isGrounded && Input.GetKeyUp(KeyCode.Space))
            {
                //verticalVelocity = -0.5f;
                verticalVelocity = jumpForce;
            }
            else
            {
                verticalVelocity = verticalVelocity - gravityValue * Time.deltaTime;

            }

            moveVector.x = Input.GetAxisRaw("Horizontal");
            moveVector.y = verticalVelocity;
            moveVector.z = speed;

            playerController.Move(moveVector * Time.deltaTime);
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if(hit.transform.CompareTag("Obstacle"))
            {
                isPlayerDead = true;
                GetComponent<Score>().OnDeath();
            }
            else if(hit.transform.CompareTag("Collective"))
            {
                Destroy(hit.gameObject);
            }
        }
    }
}

