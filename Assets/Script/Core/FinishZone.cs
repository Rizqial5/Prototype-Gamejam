using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamejam.Core
{
    public class FinishZone : MonoBehaviour 
    {

        [SerializeField] int sceneIndex;
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag == "Finish")
            {
                print("Berhasil");
                SceneManager.LoadScene(sceneIndex);

            }
        }
    }   
}