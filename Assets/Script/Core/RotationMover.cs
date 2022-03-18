using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamejam.Sound;

namespace Gamejam.Core
{
    public class RotationMover : MonoBehaviour
    {
        [SerializeField] float tiltAngle = 5f;
        [SerializeField] float speed = 2f;
        [SerializeField] float timeRotation = 2f;
        public bool isRotate ;
        float rotationAngleStart = 0f;
        float rotationAngle = 0f;
        GameManager gameManager;
        Quaternion boxStartPosisiton;
        SoundEffect soundEffect;
        

        private void Start() {
            isRotate = true;
            gameManager = GetComponent<GameManager>();
            soundEffect = GetComponent<SoundEffect>();
            boxStartPosisiton = transform.rotation;
            rotationAngleStart = rotationAngle;
        }

        // Update is called once per frame
        void Update()
        {   
           
            if(!gameManager.PlayGame())
            {
                if(gameManager.isOver()) return;
            
                if(gameManager.GetPlayer() == null) return;
                
    
                rotationAngle = 0;
                soundEffect.PlaySoundFX();
                transform.rotation = Quaternion.Slerp(transform.rotation,boxStartPosisiton,Time.deltaTime*speed);
            }
            
            

            if(isRotate)
            {
                RotateController();
            }

            
            transform.rotation = Quaternion.Slerp(transform.rotation,RotationAngle(rotationAngle),Time.deltaTime*speed);
            
            
           
        }

        private void RotateController()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                rotationAngle += tiltAngle;
                soundEffect.PlaySoundFX();
                BetweenRotate();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                rotationAngle -= tiltAngle;
                soundEffect.PlaySoundFX();
                BetweenRotate();
            }
        }

        private void BetweenRotate()
        {
            isRotate = false;
            
            StartCoroutine(RotateCooldown(timeRotation));
        }

        public IEnumerator RotateCooldown(float timeRotation)
        {

            yield return new WaitForSeconds(timeRotation);
            
            isRotate = true;

        }

        public Quaternion RotationAngle(float rotationAngle)
        {
            ;
            Vector3 MovementRotation = new Vector3(0, 0, rotationAngle);
            return Quaternion.Euler(MovementRotation);
        }

        public bool  isSpinning()
        {
            if (!isRotate)
            {
                return true;
            }
            if(isRotate) return false;

            return false;
  
        }

        

       


        

    }
}
