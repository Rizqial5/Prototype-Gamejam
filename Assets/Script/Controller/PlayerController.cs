using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamejam.Movement;
using Gamejam.Core;
using Gamejam.Attributes;

namespace Gamejam.Controller
{
    public class PlayerController : MonoBehaviour
    {
        
        [SerializeField] GameObject boxStage;
        [SerializeField] GameObject player;
        
        [SerializeField] float timeReposition = 2f;
        [SerializeField] float damageCooldown = 0;

        public Animator animator;

        Mover mover;
        Health health;
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
            health = GetComponent<Health>();
            rotationMover = GetComponent<RotationMover>();
            accel = initalAccel;
            initialRotationPosition = transform.rotation; 
            initialPosition = transform.position;
            
            
        }
        // Update is called once per frame
        void Update()
        {   
            
            animator.SetFloat("speed", accel);
            
            if(gameObject == null) return;
            
            if(isStopped()) return;

            if(health.GetDead())
            {
                accel = 0;
            } 
        
            if(isCrashed)
            {
                accel = 0;
                if(transform.rotation == initialRotationPosition)
                {
                    accel = initalAccel;
                }
            }

            
            
            
           
            
            mover.Move(accel);
            mover.RotationPlayer(6);


            
            
        }

        public bool isStopped()
        {
            if(!boxStage.GetComponent<RotationMover>().isSpinning())
            {
                accel = initalAccel;
                return false;
            }
            else if(boxStage.GetComponent<RotationMover>().isSpinning())
            {
                
                accel = 0;
                return true;
            }
            
            return true;
        }

        public void Respawn()
        {
            isReposition = true;
            accel = 0;
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
            mover.enabled = false; 
            GetComponent<SpriteRenderer>().enabled = false;
            //die animation
            
            
            yield return new WaitForSeconds(timeReposition);
            
            GetComponent<SpriteRenderer>().enabled = true;
            mover.RotationPlayerReposition(initialRotationPosition);
            mover.Reposition(initialPosition);
            mover.enabled = true;
            
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
