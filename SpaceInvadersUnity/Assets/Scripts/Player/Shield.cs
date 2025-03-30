using UnityEngine;

public class Shield : MonoBehaviour
{
    public int maxHits = 15;
    private int currentHits;
    private Vector3 originalScale;

    void Start()
    {
        currentHits = 0;
        originalScale = transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet") || other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            currentHits++;

            float scaleFactor = 1f - (currentHits / (float)maxHits);
            transform.localScale = new Vector3(originalScale.x * scaleFactor, originalScale.y * scaleFactor, 1f);

            if (currentHits >= maxHits)
            {
                Destroy(gameObject);
            }
        }
    }
}
