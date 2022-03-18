using System.Collections;
using System.Collections.Generic;
using Gamejam.Movement;
using UnityEngine;

namespace Gamejam.Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float speedRotation;
        Mover mover;
        Quaternion initialRotation;
        void Start()
        {
            mover = GetComponent<Mover>();
            
        }

        // Update is called once per frame
        void Update()
        {
            mover.RotationPlayer(speedRotation);
        }
    }    
}
