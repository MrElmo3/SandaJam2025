using System.Collections;
using UnityEngine;

public class CameraSystem : StaticInstance<CameraSystem> {
	
	private Transform mainCamera;
	[SerializeField] private float _speed = 1f;
	private bool isRotating = false;

	protected override void Awake() {
		base.Awake();
		mainCamera = Camera.main.transform;
	}

	public void RotateRight() {
		if(isRotating) return;
        StartCoroutine(PerformRotation(
            Quaternion.Euler(0, 0, mainCamera.rotation.eulerAngles.z - 90),
            _speed
        ));
    }

	public void RotateLeft() {
		if(isRotating) return;
        StartCoroutine(PerformRotation(
            Quaternion.Euler(0, 0, mainCamera.rotation.eulerAngles.z + 90),
            _speed
        ));
    }

	public void Rotate180() {
		if(isRotating) return;
        StartCoroutine(PerformRotation(
			Quaternion.Euler(0, 0, mainCamera.rotation.eulerAngles.z + 180),
			_speed
		));
	}

	private IEnumerator PerformRotation (Quaternion targetRotation,float _speed) {
		isRotating = true;
		float progress = 0f;
		float speed = _speed;

		while (progress < 1f) {
			mainCamera.rotation = Quaternion.Slerp (mainCamera.rotation, targetRotation, progress);
			progress += Time.deltaTime * speed;

			if (progress <= 1f) {
				yield return null;
			}
		}
		isRotating = false;
	}

}