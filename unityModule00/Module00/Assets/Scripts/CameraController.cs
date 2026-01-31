using UnityEngine;

public class CameraOrbitController : MonoBehaviour
{
    public Transform target;

    public float distance = 7f;
    public float height = 4f;
    public float rotationSpeed = 90f;

    float currentAngle = 0f;

    void LateUpdate()
    {
        if (target == null) return;

        if (Input.GetKey(KeyCode.LeftArrow))
            currentAngle -= rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
            currentAngle += rotationSpeed * Time.deltaTime;

        float rad = currentAngle * Mathf.Deg2Rad;

        float x = Mathf.Sin(rad) * distance;
        float z = Mathf.Cos(rad) * distance;

        Vector3 newPos = new Vector3(
            target.position.x + x,
            target.position.y + height,
            target.position.z + z
        );

        transform.position = newPos;

        transform.LookAt(target);
    }
}
