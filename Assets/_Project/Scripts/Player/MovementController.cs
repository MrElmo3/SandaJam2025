using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour {

	Rigidbody2D rb;
	Vector2 moveDirection = new();

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void Start() {
		StartCoroutine(TestCorrutine());
	}

	public void OnMove(InputValue value){
		if (Mathf.Abs(value.Get<float>()) <= 0.01f) return;
		moveDirection = new(value.Get<float>(), 0);
	}

	private void FixedUpdate() {
		//TODO: this needs a fix
		//rb.linearVelocity = moveDirection;
		//TODO: create a class for the objects affected by this gravity
		rb.AddForce(GravitySystem.Instance.GetCurrentGravity());
	}

	private IEnumerator TestCorrutine() {
		while(true) {
			yield return new WaitForSeconds(5);
			GravitySystem.Instance.RotateRight();
			CameraSystem.Instance.RotateLeft();
		}
	}
}