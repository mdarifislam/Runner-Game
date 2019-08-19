using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunner
{
    public class CameraController : MonoBehaviour {
        private Transform cameraTarget;
        private Vector3 cameraStartOffset;
        private Vector3 moveVector;
        public float yValue = 0.0f;

        void Start ()
        {
            cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
            cameraStartOffset = transform.position - cameraTarget.position;
	    }
	
	    void Update ()
        {
            moveVector = cameraTarget.position + cameraStartOffset;

            moveVector.x = 0;
            moveVector.y = Mathf.Clamp(moveVector.y, yValue, yValue);

            transform.position = moveVector;
	    }
    }
}

