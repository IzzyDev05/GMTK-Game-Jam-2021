using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float cameraMoveSpeed = 5.0f;

    private Transform cameraTransform;

    private void Start() {
        cameraTransform = GetComponent<Transform>();
    }

    private void Update() {
        var currentPos = cameraTransform.localPosition.y;
        var newPos = currentPos + cameraMoveSpeed * Time.deltaTime;

        cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, newPos, cameraTransform.localPosition.z);
    }
}