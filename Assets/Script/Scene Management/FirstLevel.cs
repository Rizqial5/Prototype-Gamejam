using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamejam.SceneManagement
{
    public class FirstLevel : MonoBehaviour 
    {

        public void FirstStage()
        {
            SceneManager.LoadScene(3);
        }
    
    }
}