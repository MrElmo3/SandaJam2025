using Scripts.UI;
using UnityEngine;

public class InteractorMenu : MonoBehaviour {

    private enum MainMenuAction
    {
        StartGame,
        Settings,
        NextLevel
	}

    [SerializeField] MainMenuAction action;
    [SerializeField] private string nextLevelName;
	
	Collider2D _triggerCollider;
	bool canInteract;

	private void Awake() {
		_triggerCollider = GetComponentInChildren<Collider2D>();
		canInteract = true;
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canInteract) return;
        canInteract = false;
        _triggerCollider.enabled = false;

        switch (action)
        {
            case MainMenuAction.StartGame:
                Debug.Log("Cocina");
                GameManager.Instance.LoadLevel("Cocina");
                break;

            case MainMenuAction.Settings:
                Debug.Log("Settings");
                UIManager.Instance.OnActiveSettings();
                break;

            case MainMenuAction.NextLevel:
                Debug.Log("NextLevel");
                GameManager.Instance.LoadLevel(nextLevelName);
                break;
        }
        _triggerCollider.enabled = true;
        canInteract = true;
    }
}