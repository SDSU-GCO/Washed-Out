using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WO
{
    public class PlayableAreaMovement : MonoBehaviour
    {

        private GameManager GM;
        public float ScrollingSpeed = 1.0f;

        //void OnEnable()
        private void Start()
        {
            GM = GameManager.Instance;
        }

        void FixedUpdate()
        {
            if(GM.ScrollingActive == true)
            {
                transform.Translate(0, ScrollingSpeed * Time.deltaTime, 0);
            }
        }
    }
}