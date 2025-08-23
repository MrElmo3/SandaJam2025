using UnityEngine;

public class Interactor : MonoBehaviour, IInteractable {
	
	private enum RotateDirection {
		Right,
		Left,
		Inverse
	}
	
	[SerializeField] RotateDirection _direction = RotateDirection.Right;

	bool canInteract;

	void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log("PatataAtomica UwU");
	}

	public void Interact() {
		if(!canInteract) return;
		canInteract = false;
		//Disable collider

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
	}
}