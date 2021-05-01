namespace Amity
{
    public class FallingState : CharacterState
    {
		public FallingState(PlayerCharacter character) : base(character) {; }

		public override void OnEnter() {
			NotifyListeners(this);
		}

		public override CharacterState OnUpdate() {
			if (character.footHitbox.isHitting)
				return new GroundedState(character);
			return null;
		}
	}
}
