using UnityEngine.InputSystem;
using System;

namespace Amity
{
	public abstract class CharacterState {
		protected PlayerCharacter character;

		public event Action<CharacterState> onStateEnter;

		public CharacterState(PlayerCharacter character) { this.character = character; }

		protected void NotifyListeners(CharacterState state) { onStateEnter?.Invoke(state); }

		public virtual void OnEnter() { ; }
		public virtual void OnExit() { ; }
		public virtual CharacterState OnUpdate() { return null; }
		public virtual CharacterState OnJump(InputValue inputValue = null) { return null; }
    }
}
