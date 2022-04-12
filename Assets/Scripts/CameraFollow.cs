using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 1.825f;
    [SerializeField] private Vector3 offset = new Vector3(0, 15, -25);
    private void LateUpdate()
    {
        Vector3 desirePosition = target.position + offset;
        Vector3 smothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed * Time.deltaTime);
        transform.position = smothedPosition;
    }
}
