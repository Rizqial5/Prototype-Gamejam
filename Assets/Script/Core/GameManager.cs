using UnityEngine;
using Gamejam.Controller;

namespace Gamejam.Core
{
    public class GameManager : MonoBehaviour 
    {
        [SerializeField] GameObject player;
        public bool PlayGame()
        {
            if(player.GetComponent<PlayerController>().PlayerStop()) return false;
            return true;
        }

    }

}