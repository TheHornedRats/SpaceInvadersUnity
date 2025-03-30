using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float boundary = 8f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 newPos = transform.position + Vector3.right * move;

  
        newPos.x = Mathf.Clamp(newPos.x, -boundary, boundary);
        transform.position = newPos;
    }
}
