using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Prisoner : PlayerBase
    {
        bool hasMetalDetector;
        public Prisoner(float speed, PlayerType playerType) : base(speed, playerType, PlayerState.Idle)
        {
            hasMetalDetector = false;
        }
        public override void ChangePlayerState(PlayerState playerState)
        {
            switch (playerState)
            {
                case PlayerState.Idle:
                    if (hasMetalDetector)
                    {
                        ChangePlayerState(PlayerState.MetalDetectorIdle);
                    }
                    break;
                case PlayerState.Run:
                    if (hasMetalDetector)
                    {
                        ChangePlayerState(PlayerState.MetalDetectorRun);
                    }
                    break;
                case PlayerState.MetalDetectorIdle:
                    break;
                case PlayerState.MetalDetectorRun:
                    break;
                default:
                    break;
            }
        }
    }
}

