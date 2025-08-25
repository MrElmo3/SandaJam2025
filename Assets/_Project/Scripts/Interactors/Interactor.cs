using UnityEngine;

public class Interactor : MonoBehaviour, IInteractable {
	
	private enum RotateDirection {
		Right,
		Left,
		Inverse
	}
	
	[SerializeField] RotateDirection _direction = RotateDirection.Right;
	
	Collider2D _triggerCollider;
	bool canInteract;

	private void Awake() {
		_triggerCollider = GetComponentInChildren<Collider2D>();
		canInteract = true;
	}

	public void Interact() {
		if(!canInteract) return;
		canInteract = false;
		_triggerCollider.enabled = false;

		AudioManager.Instance.Play("Lever");

		switch(_direction) {
			case RotateDirection.Right:
				GameManager.Instance.RotateRight();
				break;
			
			case RotateDirection.Left:
				GameManager.Instance.RotateLeft();
				break;

			case RotateDirection.Inverse:
				GameManager.Instance.Rotate180();
				break;
		}
		_triggerCollider.enabled = true;
		canInteract = true;
	}
}