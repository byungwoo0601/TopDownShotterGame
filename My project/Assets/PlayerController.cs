using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // 플레이어 이동
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // 플레이어가 화면 밖으로 나가지 않도록 제한
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -screenWidth, screenWidth),
            Mathf.Clamp(transform.position.y, -screenHeight, screenHeight),
            transform.position.z
        );
    }
}
