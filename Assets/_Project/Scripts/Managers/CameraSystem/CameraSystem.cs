using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class CameraSystem : StaticInstance<CameraSystem> {
	
	private Transform mainCamera;
	[SerializeField] private float _displacementAngle = 30f;
	[SerializeField] private float _displacementSpeed = 0.5f;
	[SerializeField] private float _rotationSpeed = 0.25f;
	private bool isRotating = false;

	protected override void Awake() {
		base.Awake();
		mainCamera = Camera.main.transform;
	}

	public void RotateRight() {
		if(isRotating) return;

		PerformRotation(_displacementAngle, _displacementSpeed, () => {
			PerformRotation( -1 * (_displacementAngle + 90), _rotationSpeed);
		});
	}

	public void RotateLeft() {
		if(isRotating) return;

		PerformRotation( -1 * _displacementAngle, _displacementSpeed, () => {
			PerformRotation(_displacementAngle + 90, _rotationSpeed);
		});
	}

	public void Rotate180() {
		if(isRotating) return;
		PerformRotation( -1 * _displacementAngle, _displacementSpeed, () => {
			PerformRotation(_displacementAngle + 180, _rotationSpeed);
		});
	}

	private void PerformRotation(float displacement, float performTime, UnityAction OnComplete = null) {
		isRotating = true;
		mainCamera.DORotate(
			new Vector3(0, 0, displacement), 
			performTime, 
			RotateMode.LocalAxisAdd)

		.onComplete = () => { 
			isRotating = false;
			OnComplete?.Invoke(); 
		};
	}

}