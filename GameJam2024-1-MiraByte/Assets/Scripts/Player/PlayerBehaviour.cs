using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public PlayerType playerType;
        public RuntimeAnimatorController prisonerAnimator;
        public RuntimeAnimatorController guardAnimator;
        Animator playerAnimator;
        PlayerBase player;
        Rigidbody2D rb;

        List<AudioClip> clips = new List<AudioClip>();
        public AudioSource source;
        public float walkTime;
        public bool canMove = true;
        public bool isUsingMetalDetector = false;
        public GameObject[] StoppingUIElements;
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
                    player = new Prisoner(5, playerType);
                    playerAnimator.runtimeAnimatorController = guardAnimator;
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
            else
            {
                rb.velocity = new Vector2(0, 0);
                ValidateUIElements();
            }
        }

        void ValidateUIElements()
        {
            foreach (var item in StoppingUIElements)
            {
                if (item.activeInHierarchy)
                {
                    return;
                }
            }
            canMove = true;
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

        public void ActivateMetalDetector()
        {
            if(player.PlayerType == PlayerType.Prisoner && gameObject.activeInHierarchy)
            {
                isUsingMetalDetector = !isUsingMetalDetector;
                playerAnimator.SetBool("usingMetalDetector", isUsingMetalDetector);
            }
        }
    }
}

