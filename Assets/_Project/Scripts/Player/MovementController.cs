using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {

	[SerializeField] float _velocity = 1;

	Rigidbody2D _rb;
	float _moveInput = new();

	private void Awake() {
		_rb = GetComponent<Rigidbody2D>();
	}

	public void OnInteract(InputValue value) {

	}

	public void OnMove(InputValue value){
		_moveInput = value.Get<float>();
	}

	private void FixedUpdate() {
		Vector2 currentGravity = GravitySystem.Instance.GetCurrentGravityValue();
		_rb.AddForce(currentGravity);

		GravityState state = GravitySystem.Instance.GetCurrentGravityState();

		var moveDirection = state switch {
			GravityState.Down 	=> new Vector2(_moveInput * _velocity, _rb.linearVelocity.y),
			GravityState.Right 	=> new Vector2(_rb.linearVelocity.x, _moveInput * _velocity),
			GravityState.Up 	=> new Vector2(-1 * _moveInput * _velocity, _rb.linearVelocity.y),
			GravityState.Left 	=> new Vector2(_rb.linearVelocity.x, -1 * _moveInput * _velocity),
			_ => Vector2.zero,
		};

		_rb.linearVelocity = moveDirection;
	}
}