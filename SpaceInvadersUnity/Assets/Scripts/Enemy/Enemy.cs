using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameManager.Instance.AddScore(scoreValue);
        }
    }
}
