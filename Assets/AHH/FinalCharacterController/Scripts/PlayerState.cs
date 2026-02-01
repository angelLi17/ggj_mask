using UnityEngine;

namespace AHH.FinalCharacterController
{
    public class PlayerState : MonoBehaviour
    {
        [field: SerializeField]
        public PlayerMovementState CurrentPlayerMovementState { get; private set; } = PlayerMovementState.Idling;

        public void SetPlayerMovementState(PlayerMovementState playerMovementState)
        {
            CurrentPlayerMovementState = playerMovementState;
        }

        public bool InGroundedState()
        {
            return CurrentPlayerMovementState == PlayerMovementState.Running ||
                   CurrentPlayerMovementState == PlayerMovementState.Sprinting||
                   CurrentPlayerMovementState == PlayerMovementState.Idling ||
                   CurrentPlayerMovementState == PlayerMovementState.Walking;
        }
    }
    public enum PlayerMovementState
    {
        Idling = 0,
        Walking = 1,
        Running = 2,
        Sprinting = 3,
        Jumping = 4,
        Falling = 5,
        Strafing = 6,
    }
}
