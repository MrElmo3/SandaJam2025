using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {

	[SerializeField] float _velocity = 1;
	[SerializeField] float _raycastDistance;
	[SerializeField] LayerMask _groundLayer;

	float _gravityMultiplier = 1;
	Rigidbody2D _rb;
	Interactor _currentInteractor = null;

	float _moveInput;
	bool _isGrounded = false;

	private void Awake() {
		_rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if(!_isGrounded) _moveInput = 0;
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
		if (GameManager.Instance.GetPauseGame())
			return;
		else
		{ 
			CheckGround();
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

	}

	public void CheckGround() {
		// Debug.DrawLine((Vector2)transform.position + new Vector2(0.5f, 0), (Vector2)transform.position + Vector2.down * _raycastDistance, Color.red);
		// Debug.DrawLine((Vector2)transform.position + new Vector2(-0.5f, 0), (Vector2)transform.position + Vector2.down * _raycastDistance, Color.red);
		
		// Debug.DrawLine((Vector2)transform.position + new Vector2(0, 0.5f), (Vector2)transform.position + Vector2.left * _raycastDistance, Color.red);
		// Debug.DrawLine((Vector2)transform.position + new Vector2(0, -0.5f), (Vector2)transform.position + Vector2.left * _raycastDistance, Color.red);
		
		// Debug.DrawLine((Vector2)transform.position + new Vector2(0.5f, 0), (Vector2)transform.position + Vector2.right * _raycastDistance, Color.red);
		
		// Debug.DrawLine((Vector2)transform.position + new Vector2(0.5f, 0), (Vector2)transform.position + Vector2.up * _raycastDistance, Color.red);

		var downRay1 = Physics2D.Raycast((Vector2)transform.position + new Vector2(0.5f, 0), Vector2.down, _raycastDistance, _groundLayer);
		var downRay2 = Physics2D.Raycast((Vector2)transform.position + new Vector2(-0.5f, 0), Vector2.down, _raycastDistance, _groundLayer);
		
		var leftRay1 = Physics2D.Raycast((Vector2)transform.position + new Vector2(0, 0.5f), Vector2.left, _raycastDistance, _groundLayer);
		var leftRay2 = Physics2D.Raycast((Vector2)transform.position + new Vector2(0, -0.5f), Vector2.left, _raycastDistance, _groundLayer);
		
		var rightRay1 = Physics2D.Raycast((Vector2)transform.position + new Vector2(0, 0.5f), Vector2.right, _raycastDistance, _groundLayer);
		var rightRay2 = Physics2D.Raycast((Vector2)transform.position + new Vector2(0, -0.5f), Vector2.right, _raycastDistance, _groundLayer);
		
		var upRay1 = Physics2D.Raycast((Vector2)transform.position + new Vector2(0.5f, 0), Vector2.up, _raycastDistance, _groundLayer);
		var upRay2 = Physics2D.Raycast((Vector2)transform.position + new Vector2(-0.5f, 0), Vector2.up, _raycastDistance, _groundLayer);

		_isGrounded = 
			downRay1.collider ||
			downRay2.collider ||
			leftRay1.collider ||
			leftRay2.collider ||
			rightRay1.collider ||
			rightRay2.collider ||
			upRay1.collider ||
			upRay2.collider;
	}

	void OnTriggerStay2D(Collider2D collision) {
		_currentInteractor = collision.gameObject.GetComponentInParent<Interactor>();
	}

	void OnTriggerExit2D(Collider2D collision) {
		_currentInteractor = null;
	}
}