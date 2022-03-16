using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamejam.Attributes
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 0;
        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health-damage, 0);
            
            print("kena");

            if(health <= 0)
            {
                print("Mati");
            }
        }
    }
}
