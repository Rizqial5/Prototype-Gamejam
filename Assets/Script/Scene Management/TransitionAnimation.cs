using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamejam.SceneManagement
{
    public class TransitionAnimation : MonoBehaviour
    {

        [SerializeField] int nextLevel = 3;
        [SerializeField] float FadeOutTime = 0;
        [SerializeField] float BetweenFadeTime;


        // Start is called before the first frame update
        public void Start()
        {
            StartCoroutine(Transition());
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public IEnumerator Transition()
        {
            Fader fade = FindObjectOfType<Fader>();

        
            gameObject.transform.parent = null;
            DontDestroyOnLoad(gameObject);
            yield return fade.FadeOut(FadeOutTime);

            yield return new WaitForSeconds(BetweenFadeTime);

            
            
            
            yield return SceneManager.LoadSceneAsync(nextLevel);
            
            fade.FadeInImmediate();
            

            

            
            
        }

        
    }

}