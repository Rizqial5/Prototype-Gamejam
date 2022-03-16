using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamejam.Movement;
using Gamejam.Core;

namespace Gamejam.Controller
{
    public class PlayerController : MonoBehaviour
    {
        
        [SerializeField] GameObject boxStage;
        [SerializeField] GameObject respawnPlace;
        [SerializeField] float timeReposition = 2f;
        [SerializeField] float damageCooldown = 0;
        Mover mover;

        bool isDamaged = false;


        [SerializeField] float playerAccel = 2 ;

        private void Start() 
        {
            mover = GetComponent<Mover>();    
            
        }
        // Update is called once per frame
        void Update()
        {
            if(isStopped()) return;
            if(!isDamaged)
            mover.Move(playerAccel);
            
        }

        public bool isStopped()
        {
            if(!boxStage.GetComponent<RotationMover>().isSpinning())
            {
                return false;
            }
            return true;
        }

        public void Respawn()
        {
            isDamaged = true;

            StartCoroutine(RepositionTime(timeReposition));
            StartCoroutine(MoveAgain(damageCooldown));
        }

        //for game manager
        public bool PlayerStop()
        {
            return isDamaged;
        }

        public IEnumerator MoveAgain(float damageCooldown)
        {
            yield return new WaitForSeconds(damageCooldown);
            isDamaged = false;
        }

        public IEnumerator RepositionTime(float timeReposition)
        {
            yield return new WaitForSeconds(timeReposition);
            GetComponent<Mover>().Reposition();
            isDamaged = false;
        }
    }

    
}
