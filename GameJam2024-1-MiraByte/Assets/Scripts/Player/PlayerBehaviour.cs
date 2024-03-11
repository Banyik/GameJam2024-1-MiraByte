using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public PlayerType playerType;
        public AnimatorController prisonerAnimator;
        public AnimatorController guardAnimator;
        Animator playerAnimator;
        PlayerBase player;
        Rigidbody2D rb;

        List<AudioClip> clips = new List<AudioClip>();
        public AudioSource source;
        public float walkTime;
        public bool canMove = true;

        public bool CanMove { get => canMove; set => canMove = value; }

        void Start()
        {
            playerAnimator = gameObject.GetComponent<Animator>();
            switch (playerType)
            {
                case PlayerType.Prisoner:
                    player = new Prisoner(5, playerType);
                    playerAnimator.runtimeAnimatorController = prisonerAnimator;
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
            if (canMove)
            {
                MovementHandler();
            }
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
                playerAnimator.SetBool("isRunning", true);
                if (!IsInvoking(nameof(PlayRandomClip)))
                {
                    Invoke(nameof(PlayRandomClip), walkTime);
                }
            }
            else
            {
                player.ChangePlayerState(PlayerState.Idle);
                playerAnimator.SetBool("isRunning", false);
                CancelInvoke(nameof(PlayRandomClip));
                source.Pause();
            }
        }

        public void SetClip(List<AudioClip> clips)
        {
            
            if(this.clips.Count > 0 && clips[0] == this.clips[0])
            {
                return;
            }
            this.clips.Clear();
            this.clips.AddRange(clips);
        }

        void PlayRandomClip()
        {
            source.clip = clips[Random.Range(0, clips.Count)];
            source.Play();
        }
    }
}

