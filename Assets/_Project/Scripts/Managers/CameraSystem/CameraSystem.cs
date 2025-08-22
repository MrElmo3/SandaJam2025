using System.Collections;
using UnityEngine;

public class CameraSystem : StaticInstance<CameraSystem> {
	
	private Transform mainCamera;

	private bool isRotating = false;

	protected override void Awake() {
		base.Awake();
		mainCamera = Camera.main.transform;
	}

	public void RotateRight() {
		if(isRotating) return;
		StartCoroutine(PerformRotation(Quaternion.Euler(0, 0, mainCamera.rotation.eulerAngles.z + 90)));
	}

	public void RotateLeft() {
		if(isRotating) return;
		StartCoroutine(PerformRotation(Quaternion.Euler(0, 0, mainCamera.rotation.eulerAngles.z - 90)));
	}

	public void Rotate180() {
		if(isRotating) return;
		StartCoroutine(PerformRotation(Quaternion.Euler(0, 0, mainCamera.rotation.eulerAngles.z + 180)));
	}

	private IEnumerator PerformRotation (Quaternion targetRotation) {
		isRotating = true;
		float progress = 0f;
		float speed = 0.5f;

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