using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Gamejam.Sound;


namespace Gamejam.SceneManagement
{
    public class FinishZone : MonoBehaviour 
    {

        [SerializeField] int transitionScene = 3;

        
        [SerializeField] GameObject Player;
        AudioSource audioSource;

        public bool isMoveAnotherScene = false;
        private void Start() {
            audioSource = GetComponent<AudioSource>();
        }
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag == "Player")
            {
                print("true");
                SceneManager.LoadScene(transitionScene);
                
                

            }
        }

        

        

        
    }   
}