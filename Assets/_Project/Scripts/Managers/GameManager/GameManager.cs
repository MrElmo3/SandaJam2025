using UnityEngine;

public class GameManager : StaticInstance<GameManager> {

	[Header("Prefabs")]
	[SerializeField] GameObject _playerPrefab;

	public GameObject Player { get; private set; }

	private void Start() {
		Player = GameObject.FindWithTag("Player");
	}

	public void RotateRight() {
		GravitySystem.Instance.RotateRight();
		CameraSystem.Instance.RotateLeft();
	}

	public void RotateLeft() {
		GravitySystem.Instance.RotateLeft();
		CameraSystem.Instance.RotateRight();
	}

	public void Rotate180() {
		GravitySystem.Instance.Inverse();
		CameraSystem.Instance.Rotate180();
	}
}