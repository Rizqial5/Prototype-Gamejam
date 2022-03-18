using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamejam.UI
{
    public class ConfirmationPanel : MonoBehaviour
    {
        public void ShowPanel()
        {
            gameObject.SetActive(true);
        }

        public void ExitDesktop()
        {
            Application.Quit();
            print("Bisa");
        }

        public void HidePanel()
        {
            gameObject.SetActive(false);
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
