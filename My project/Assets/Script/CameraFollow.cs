using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        // 플레이어의 현재 위치를 받아옵니다.
        Vector3 desiredPosition = target.position + offset;

        // 카메라를 부드럽게 이동시킵니다.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // 카메라가 플레이어를 항상 바라보도록 합니다.
        transform.LookAt(target.position);
    }
}
