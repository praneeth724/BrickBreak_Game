using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 10f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 currentPosition = transform.position;
        currentPosition.x += horizontalInput * moveSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }
}
