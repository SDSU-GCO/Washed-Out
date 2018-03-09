using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WO
{
    public class GameManager : MonoBehaviour
    {
        public bool ScrollingActive
        {
            get; private set;
        }
        public bool GameplayActive
        {
            get; private set;
        }

        #region Singleton
        public static GameManager Instance
        {
            get; private set;
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
        #endregion

        private void Start()
        {
            ScrollingActive = true;
            GameplayActive = true;
        }
    }
}