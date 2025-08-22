using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour {

	Rigidbody2D rb;
	Vector2 moveDirection = new();

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	public void OnMove(InputValue value){
		moveDirection = new(value.Get<float>(), 0);
	}

	private void FixedUpdate() {
		rb.linearVelocity = moveDirection;
	}
}