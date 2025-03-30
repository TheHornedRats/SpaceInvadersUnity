using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float boundary = 8f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {

        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 newPos = transform.position + Vector3.right * move;

      
        newPos.x = Mathf.Clamp(newPos.x, -boundary, boundary);
        transform.position = newPos;

   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}
