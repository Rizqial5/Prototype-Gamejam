using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamejam.Core
{
    public class RotationMover : MonoBehaviour
    {
        [SerializeField] float tiltAngle = 5f;
        [SerializeField] float speed = 2f;
        [SerializeField] float timeRotation = 2f;
        bool isRotate ;
        float rotationAngle = 0f;
    
        

        private void Start() {
            isRotate = true;
        }

        // Update is called once per frame
        void Update()
        {   
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
                BetweenRotate();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                rotationAngle -= tiltAngle;
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
            print("bisa");
            isRotate = true;

        }

        public Quaternion RotationAngle(float rotationAngle)
        {
            ;
            Vector3 MovementRotation = new Vector3(0, 0, rotationAngle);
            return Quaternion.Euler(MovementRotation);
        }

       


        

    }
}
