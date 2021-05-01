using UnityEngine.InputSystem;
using System.Timers;
using System;

namespace Amity
{
    public class GroundedState : CharacterState
    {
		private bool calculatingCoyoteTime = false;
		private float remainingCoyoteTime;

		public GroundedState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			NotifyListeners(this);
		}

		public override CharacterState OnPhysicsUpdate() {
			if (!character.footHitbox.isHitting && !calculatingCoyoteTime) {
				calculatingCoyoteTime = true;
				remainingCoyoteTime = 0.2f;
				System.Timers.Timer coyoteTimer = new System.Timers.Timer(0.2f);
				coyoteTimer.Elapsed += EndCoyoteEffect;
				while (remainingCoyoteTime > 0f) { continue; }
				return new FallingState(character);
			}
			return null;
		}

		private void EndCoyoteEffect(object source, ElapsedEventArgs e) { remainingCoyoteTime = 0f; }

		public override CharacterState OnJump(InputValue inputValue = null) {
			return new JumpingState(character);
		}
	}
}
