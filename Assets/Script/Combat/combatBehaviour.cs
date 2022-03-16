using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamejam.Attributes;
using Gamejam.Movement;
using Gamejam.Controller;

namespace Gamejam.Combat
{
    public class combatBehaviour : MonoBehaviour
    {
        
        
        private  void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag == "Enemy")
            {
                GetComponent<Health>().TakeDamage(1);
                GetComponent<PlayerController>().Respawn();;
                

            }
        }

       
        
            
        
    }
}
