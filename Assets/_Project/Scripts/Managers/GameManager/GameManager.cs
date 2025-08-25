using UnityEngine;

public class GameManager : StaticInstance<GameManager>
{

	[Header("Prefabs")]
	[SerializeField] GameObject _playerPrefab;

	public GameObject Player { get; private set; }
	[SerializeField] bool pauseGame;

	private void Start()
	{
		LoadLevel("MainMenu");
		AudioManager.Instance.PlayBGM("Fondo");
    }

    public void LoadLevel(string levelName)
	{
		var levelController = LevelSystem.Instance.LoadLevel(levelName);
		Player = Instantiate(_playerPrefab, levelController.GetPlayerStartPosition());
	}

	public void RotateRight()
	{
		CameraSystem.Instance.RotateLeft(() =>
		{
			AudioManager.Instance.Play("Rotate");
			GravitySystem.Instance.RotateRight();
		});
	}

	public void RotateLeft()
	{
		CameraSystem.Instance.RotateRight(() =>
		{
			AudioManager.Instance.Play("Rotate");
			GravitySystem.Instance.RotateLeft();
		});
	}

	public void Rotate180()
	{
		CameraSystem.Instance.Rotate180(() =>
		{
			GravitySystem.Instance.Inverse();
		});
	}
	public bool GetPauseGame()
	{
		return pauseGame;
	}

	public void SetPauseGame(bool pause)
	{
		pauseGame = pause;
	}

}