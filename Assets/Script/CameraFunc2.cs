﻿using UnityEngine;

public class CameraFunc2 : MonoBehaviour {
	public GameObject MainCamera;
	private Vector3 lastMousePosition;
	private Vector3 newAngle = new Vector3(0, 0, 0);

	private void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			// マウスクリック開始(マウスダウン)時にカメラの角度を保持(Z軸には回転させないため).
			newAngle = MainCamera.transform.localEulerAngles;
			lastMousePosition = Input.mousePosition;
		}
		else if (Input.GetMouseButton(0))
		{
			// マウスの移動量分カメラを回転させる.
			newAngle.y += (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
			newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * 0.1f;
			MainCamera.gameObject.transform.localEulerAngles = newAngle;

			lastMousePosition = Input.mousePosition;
		}

	}
}