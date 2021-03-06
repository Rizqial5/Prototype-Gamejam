using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gamejam.Attributes
{
    public class HealthDisplay : MonoBehaviour
    {
        Health health;
        Text text;

        private void Awake() 
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
            text = GetComponent<Text>();

        }

        private void Update() 
        {
            text.text = String.Format("{0}", health.GetHealth());
        }
    }
}
