using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamejam.UI
{
    public class ShowPanel : MonoBehaviour
    {
        [SerializeField] GameObject congratulationsPanel;
        GameObject Player;

        private void Awake() 
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.gameObject.tag == "Player")
            {
                congratulationsPanel.SetActive(true);
                Player.SetActive(false);

                
                

            }
        }
    }
}
