using System;
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

	public void RotateRight(UnityAction OnComplete = null) {
		if(isRotating) return;

		PerformRotation(_displacementAngle, _displacementSpeed, () => {
			PerformRotation( -1 * (_displacementAngle + 90), _rotationSpeed,
			() => { OnComplete?.Invoke(); });
		});
	}

	public void RotateLeft(UnityAction OnComplete = null) {
		if(isRotating) return;

		PerformRotation( -1 * _displacementAngle, _displacementSpeed, () => {
			PerformRotation(_displacementAngle + 90, _rotationSpeed,
			() => { OnComplete?.Invoke(); });
		});
	}

	public void Rotate180(UnityAction OnComplete = null) {
		if(isRotating) return;
		PerformRotation( -1 * _displacementAngle, _displacementSpeed, () => {
			PerformRotation(_displacementAngle + 180, _rotationSpeed,
			() => { OnComplete?.Invoke(); });
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

	public void ResetCamera(UnityAction OnComplete = null)
	{
		mainCamera.DORotate(
		new Vector3(0, 0, 0),
		0.5f,
		RotateMode.Fast)
		.onComplete = () => { OnComplete?.Invoke(); };
		
    }
}