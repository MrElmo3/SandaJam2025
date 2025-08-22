using UnityEngine;

public class GravitySystem : StaticInstance<GravitySystem> {
	private enum GravityState {
		None 	= -1,
		Down 	= 0,
		Right 	= 1,
		Up		= 2,
		Left	= 3,
	}

	[SerializeField] float gravityIntensity = 9.81f;

	[SerializeField] GravityState actualState;

	protected override void Awake() {
		base.Awake();
		actualState = GravityState.Down;
	}

	public void RotateRight(){
		actualState = (GravityState)(((int)actualState + 1) % 4);
	}

	public void RotateLeft() {
		actualState = (GravityState)(((int)actualState - 1) % 4);
	}

	public void Inverse() {
		actualState = (GravityState)(((int)actualState + 2) % 4);
	}

	public Vector2 GetCurrentGravity(){
		var currentGravity = actualState switch {
			GravityState.Down => Vector2.down,
			GravityState.Right => Vector2.right,
			GravityState.Up => Vector2.up,
			GravityState.Left => Vector2.left,
			_ => Vector2.zero,
		};

		return currentGravity * gravityIntensity;
	}
}