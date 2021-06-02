using UnityEngine.InputSystem;
using System;

namespace Amity
{
	public abstract class CharacterState {
		protected PlayerCharacter character;

		public CharacterState(PlayerCharacter character) { this.character = character; }

		public virtual void OnEnter() { ; }
		public virtual void OnExit() { ; }
		public virtual CharacterState OnLogicUpdate() { return null; }
		public virtual CharacterState OnPhysicsUpdate() { return null; }
		public virtual CharacterState OnPound(int input = 0) { return null; }
		public virtual CharacterState OnJump() { return null; }
		public virtual CharacterState OnRun() { return null; }
	}
}
