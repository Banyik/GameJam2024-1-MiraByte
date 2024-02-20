using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public PlayerType playerType;
        PlayerBase player;
        Rigidbody2D rb;

        void Start()
        {
            switch (playerType)
            {
                case PlayerType.Prisoner:
                    player = new Prisoner(5, playerType);
                    break;
                case PlayerType.Guard:
                    break;
                default:
                    break;
            }
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        void FixedUpdate()
        {
            MovementHandler();
        }

        void MovementHandler()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector2 movement = new Vector2(horizontal, vertical);
            rb.velocity = Vector2.Lerp(rb.velocity, movement, player.Speed) * player.Speed;
            if (rb.velocity != new Vector2(0, 0) )
            {
                if (horizontal != 0)
                {
                    GetComponent<SpriteRenderer>().flipX = horizontal != -1;
                }
                player.ChangePlayerState(PlayerState.Run);
            }
            else
            {
                player.ChangePlayerState(PlayerState.Idle);
            }
        }
    }
}

