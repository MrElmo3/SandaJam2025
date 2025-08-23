using UnityEngine;

public class GameManager : StaticInstance<GameManager> {

	[Header("Prefabs")]
	[SerializeField] GameObject _playerPrefab;

	public GameObject Player { get; private set; }

	public void LoadLevel(string levelName) {
		var levelController = LevelSystem.Instance.LoadLevel(levelName);
		Player = Instantiate(_playerPrefab, levelController.GetPlayerStartPosition());
	}

	public void RotateRight() {
		CameraSystem.Instance.RotateLeft(() => {
			GravitySystem.Instance.RotateRight();
		});
	}

	public void RotateLeft() {
		CameraSystem.Instance.RotateRight(() => {
			GravitySystem.Instance.RotateLeft();
		});
	}

	public void Rotate180() {
		CameraSystem.Instance.Rotate180(() => {
			GravitySystem.Instance.Inverse();
		});
	}
}