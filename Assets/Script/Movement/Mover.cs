using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamejam.Core;

namespace Gamejam.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed = 0f;
        [SerializeField] GameObject respawnPlace;
        
        
        
        public float accel;
    
        private void Start() 
        {
            
        }
    
        // Start is called before the first frame update
    
        // Update is called once per frame
        void Update()
        {
            
        }

        public void RotationPlayer(float speedRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.zero), Time.deltaTime * speedRotation);
        }

        public void RotationPlayerReposition(Quaternion initialRotation)
        {
            transform.rotation = initialRotation;
        }

        public void Move(float accel)
        {
            transform.Translate(Vector3.right * accel * Time.deltaTime);
        }

        public void Reposition(Vector3 initialPosition)
        {
            // transform.position = respawnPlace.transform.position;
            transform.position = initialPosition;
            
            
        }

        public void BackwardReposition(float accel)
        {
            transform.Translate(Vector3.left * accel * Time.deltaTime);
        }
    }


}
