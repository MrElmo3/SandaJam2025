public class GameManager : StaticInstance<GameManager> {
	
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