using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBase
    {
        float speed;
        PlayerType playerType;
        PlayerState playerState;
        public PlayerBase(float speed, PlayerType playerType, PlayerState playerState)
        {
            this.speed = speed;
            this.playerType = playerType;
            this.playerState = playerState;
        }

        public float Speed { get => speed; set => speed = value; }
        public PlayerType PlayerType { get => playerType; set => playerType = value; }
        public PlayerState PlayerState { get => playerState; set => playerState = value; }

        public PlayerState GetPlayerState()
        {
            return playerState;
        }

        public virtual void ChangePlayerState(PlayerState playerState) {}
    }
}

