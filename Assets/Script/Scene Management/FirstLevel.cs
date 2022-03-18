using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamejam.SceneManagement
{
    public class FirstLevel : MonoBehaviour 
    {
        [SerializeField] int firstLevel;
        public void FirstStage()
        {
            SceneManager.LoadScene(firstLevel);
        }
    
    }
}