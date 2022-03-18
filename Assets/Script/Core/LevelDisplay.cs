using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamejam.Core
{
    public class LevelDisplay : MonoBehaviour
    {
        [SerializeField] int levelNow;
        [SerializeField] string levelDescription;

        public int GetLevel()
        {
            return levelNow;
        }

        public string GetLevelDesc()
        {
            return levelDescription;
        }
    }
}
