using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamejam.Movement;
using Gamejam.Core;

namespace Gamejam.Controller
{
    public class PlayerController : MonoBehaviour
    {
        
        [SerializeField] GameObject boxStage;
        [SerializeField] GameObject player;
        [SerializeField] GameObject respawnPlace;
        [SerializeField] float timeReposition = 2f;
        [SerializeField] float backwardTime = 0.5f;
        [SerializeField] float damageCooldown = 0;
        Mover mover;
        RotationMover rotationMover;

        Quaternion initialRotationPosition;
        Vector3 initialPosition;

        bool isReposition = false;
        bool isCrashed = false;


        [SerializeField] float initalAccel = 2 ;
        float accel = 0;

        private void Start() 
        {
            mover = GetComponent<Mover>();   
            rotationMover = GetComponent<RotationMover>();
            accel = initalAccel;
            initialRotationPosition = transform.rotation; 
            initialPosition = transform.position;
            
            
        }
        // Update is called once per frame
        void Update()
        {
            if(isStopped()) return;
            if(!isReposition)
            if(isCrashed)
            {
                accel = 0;
                if(transform.rotation == initialRotationPosition)
                {
                    accel = initalAccel;
                }
                
                
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                isReposition = true;
                StartCoroutine(RepositionTime(timeReposition));
            }

            mover.Move(accel);
            mover.RotationPlayer(6);


            
            
        }

        public bool isStopped()
        {
            if(!boxStage.GetComponent<RotationMover>().isSpinning())
            {
                return false;
            }
            // else if(boxStage.GetComponent<RotationMover>().isSpinning())
            // {
            //     accel = 0;
                
            // }
            
            accel = initalAccel;
            return true;
        }

        public void Respawn()
        {
            isReposition = true;

            StartCoroutine(RepositionTime(timeReposition));
            StartCoroutine(MoveAgain(damageCooldown));
        }

        //for game manager
        public bool PlayerStop()
        {
            return isReposition;
        }

        public IEnumerator MoveAgain(float damageCooldown)
        {
            yield return new WaitForSeconds(damageCooldown);
            isReposition = false;
        }

        public IEnumerator RepositionTime(float timeReposition)
        {
            GetComponent<SpriteRenderer>().enabled = false; //die animation
            accel = 0;
            yield return new WaitForSeconds(timeReposition);
            GetComponent<SpriteRenderer>().enabled = true;
            mover.RotationPlayerReposition(initialRotationPosition);
            mover.Reposition(initialPosition);
            accel = initalAccel;
            isReposition = false;
        }

        
        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.tag == "Wall")
            {
                isCrashed = true;
            }
            
        }
    }

    
}
