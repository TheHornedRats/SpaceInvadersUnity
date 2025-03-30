using UnityEngine;

public class EnemyGroupController : MonoBehaviour
{
    public GameObject enemyType1;
    public GameObject enemyType2;
    public GameObject enemyType3;

    public int rows = 5;
    public int columns = 10;
    public float spacing = 1f;
    public float speed = 2f;
    public float moveDownAmount = 0.5f;
    public float dangerY = -2.5f;

    private Vector2 direction = Vector2.right;

    void Start()
    {
        SpawnEnemies();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        foreach (Transform enemy in transform)
        {
            if (enemy == null) continue;

            if (enemy.position.x > 8f || enemy.position.x < -8f)
            {
                direction *= -1;
                transform.position += Vector3.down * moveDownAmount;
                break;
            }

            if (enemy.position.y <= dangerY)
            {
                GameManager.Instance.ForceGameOver();
                break;
            }
        }
    }

    void SpawnEnemies()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 position = new Vector3(col * spacing, -row * spacing, 0);
                GameObject prefabToUse;

                if (row == 0)
                    prefabToUse = enemyType3;
                else if (row <= 2)
                    prefabToUse = enemyType2;
                else
                    prefabToUse = enemyType1;

                Instantiate(prefabToUse, transform.position + position, Quaternion.identity, transform);
            }
        }
    }
}
