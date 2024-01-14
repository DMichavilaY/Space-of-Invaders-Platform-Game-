using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float minX = -5f; // Establece el límite mínimo a la izquierda en el Inspector
    public float maxX = 5f;  // Establece el límite máximo a la derecha en el Inspector

    void LateUpdate()
    {
        if (target != null)
        {
            float targetX = Mathf.Clamp(target.position.x, minX, maxX);
            Vector3 desiredPosition = new Vector3(targetX, transform.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}