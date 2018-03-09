using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WO
{

    public class PlayerMovement : MonoBehaviour
    {

        public Vector2 Speed = new Vector2(1.0f,1.0f);
        private Rigidbody2D RB;
        private GameManager GM;

        // Use this for initialization
        //void OnEnable()
        private void Start()
        {
            RB = GetComponent<Rigidbody2D>();
            GM = GameManager.Instance;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (GM.GameplayActive == true)
            {
                float inputX = Input.GetAxis("Horizontal");
                float inputY = Input.GetAxis("Vertical");

                RB.velocity = new Vector2(inputX, inputY) * Speed;
            }
        }
    }

}