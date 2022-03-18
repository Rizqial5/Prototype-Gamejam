using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamejam.Attributes
{
    public class Health : MonoBehaviour
    {

        [SerializeField] float health = 0;
        
        public Animator animator;
        public GameObject gameOverPanel;
        AudioSource audioSource;
        
        
        
        public bool isDead = false;
        

        public void TakeDamage(float damage)
        {
            
            audioSource = GetComponent<AudioSource>();
            health = Mathf.Max(health-damage, 0);
            
            print(health);

            if(health <= 0)
            {
                print("true");
                animator.SetTrigger("die");
                isDead = true;
            }
        }

        public void PlayerDeath()
        {
            Destroy(gameObject);
            gameOverPanel.SetActive(true);
            

        }

        public bool GetDead()
        {
            return isDead;
        }

        public float GetHealth()
        {
            return health;
        }

        
    }
}
