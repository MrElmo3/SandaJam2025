using System;
using UnityEngine;

public enum GravityState {
	None 	= -1,
	Down 	= 0,
	Right 	= 1,
	Up		= 2,
	Left	= 3,
}

public class GravitySystem : StaticInstance<GravitySystem> {

	[SerializeField] float _gravityIntensity = 9.81f;

	[SerializeField] GravityState _actualState;

	protected override void Awake() {
		base.Awake();
		_actualState = GravityState.Down;
	}

	public void RotateRight(){
		_actualState = (GravityState)(((int)_actualState + 1) % 4);
	}

	public void RotateLeft() {
		_actualState = (GravityState)(((int)_actualState + 3) % 4);
	}

	public void Inverse() {
		_actualState = (GravityState)(((int)_actualState + 2) % 4);
	}

	public GravityState GetCurrentGravityState() {
		return _actualState;
	}

	public Vector2 GetCurrentGravityValue()
	{
		if (!GameManager.Instance.GetPauseGame())
		{
			var currentGravity = _actualState switch
			{
				GravityState.Down => Vector2.down,
				GravityState.Right => Vector2.right,
				GravityState.Up => Vector2.up,
				GravityState.Left => Vector2.left,
				_ => Vector2.zero,
			};

			return currentGravity * _gravityIntensity;

		}
		else
		{ 
			return Vector2.zero;
		}
		
	}

    public void ResetGravity()
    {
		_actualState = GravityState.Down;
    }
}