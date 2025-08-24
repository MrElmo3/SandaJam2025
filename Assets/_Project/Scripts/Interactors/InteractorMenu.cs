using Scripts.UI;
using UnityEngine;

public class InteractorMenu : MonoBehaviour, IInteractable {
	
	private enum MainMenuAction {
		StartGame,
		Settings
	}

    [SerializeField] MainMenuAction action;
	
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

		switch(action) {
			case MainMenuAction.StartGame:
				GameManager.Instance.LoadLevel("Cocina");
				break;
			
			case MainMenuAction.Settings:
                UIManager.Instance.OnActiveSettings();
				break;
		}
		_triggerCollider.enabled = true;
		canInteract = true;
	}
}