
using UnityEngine;


namespace Gamejam.Movement
{
    public class Mover : MonoBehaviour
    {

        
        
        
        
        public float accel;
    
        private void Start() 
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
