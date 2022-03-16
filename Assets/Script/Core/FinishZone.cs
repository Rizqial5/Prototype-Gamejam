using UnityEngine;

namespace Gamejam.Core
{
    public class FinishZone : MonoBehaviour 
    {
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag == "Finish")
            {
                print("Berhasil");

            }
        }
    }   
}