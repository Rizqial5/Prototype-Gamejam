using System;
using System.Collections;
using System.Collections.Generic;
using Gamejam.Core;
using UnityEngine;
using UnityEngine.UI;

public class LevelDesc : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text levelValue;
    [SerializeField] Text levelDesc;

   

    LevelDisplay levelDisplay;

    private void Awake() {
        levelDisplay= GetComponent<LevelDisplay>();;
    }

    private void Update() {
        levelValue.text = String.Format("{0}",levelDisplay.GetLevel());
        levelDesc.text = String.Format("{0}",levelDisplay.GetLevelDesc());
    }
}
