using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamejam.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvasGroup;

        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void FadeOutImmediate()
        {
            canvasGroup.alpha = 1;
        }

        public void FadeInImmediate()
        {
            canvasGroup.alpha = 0;
        }

        public IEnumerator FadeOut(float time)
        {
            while (canvasGroup.alpha < 1) //alpha is not 1
            {
                canvasGroup.alpha += Time.deltaTime/time;
                yield return null;
            }
        }

        public IEnumerator FadeIn(float time)
        {
            print("bisa");
            while (canvasGroup.alpha > 0) //alpha is  1
            {
                
                canvasGroup.alpha -= Time.deltaTime/time;
                yield return null;
            }
            
        }

    }
}
