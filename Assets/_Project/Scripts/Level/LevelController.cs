using UnityEngine;

public class LevelController : MonoBehaviour {

	[SerializeField] Transform _playerStartPosition;


	public void StartLevel() {

	}

	public Transform GetPlayerStartPosition() {
		return _playerStartPosition;
	}
}