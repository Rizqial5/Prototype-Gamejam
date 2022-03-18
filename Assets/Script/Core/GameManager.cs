using UnityEngine;
using Gamejam.Controller;
using Gamejam.Attributes;

namespace Gamejam.Core
{
    public class GameManager : MonoBehaviour 
    {
        [SerializeField] GameObject player;
        public bool PlayGame()
        {
            if(GetPlayer() == null) return false;
            if(player.GetComponent<Health>().GetDead()) return false;
            if (player.GetComponent<PlayerController>().PlayerStop()) return false;
            return true;
        }

        public GameObject GetPlayer()
        {
            return player;
        }

        public bool isOver()
        {
            if(GetPlayer() == null) return true;
            return player.GetComponent<Health>().GetDead();
        }
    }

}