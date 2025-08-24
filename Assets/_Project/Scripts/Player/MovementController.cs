using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {

	[SerializeField] float _velocity = 1;

	float _gravityMultiplier = 1;
	Rigidbody2D _rb;
	Interactor _currentInteractor = null;
	float _moveInput;

	private void Awake() {
		_rb = GetComponent<Rigidbody2D>();
	}

	public void OnInteract(InputValue value) {
		if(_currentInteractor == null) return;
		_currentInteractor.Interact();
	}

	public void OnInverse(InputValue value) {
		_gravityMultiplier *=-1;
	}

	public void OnMove(InputValue value){
		_moveInput = value.Get<float>();
	}

	private void FixedUpdate() {
		Vector2 currentGravity = GravitySystem.Instance.GetCurrentGravityValue() * _gravityMultiplier;
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

	void OnTriggerStay2D(Collider2D collision) {
		_currentInteractor = collision.gameObject.GetComponentInParent<Interactor>();
	}

	void OnTriggerExit2D(Collider2D collision) {
		_currentInteractor = null;
	}
}