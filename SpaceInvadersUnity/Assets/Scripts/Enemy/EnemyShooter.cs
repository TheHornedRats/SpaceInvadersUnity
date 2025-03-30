using UnityEngine;
using System.Collections.Generic;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootInterval = 1f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootInterval)
        {
            ShootFromRandomEnemy();
            timer = 0f;
        }
    }

    void ShootFromRandomEnemy()
    {
        List<Transform> enemies = new List<Transform>();

        foreach (Transform enemy in transform)
        {
            if (enemy != null)
                enemies.Add(enemy);
        }

        if (enemies.Count == 0) return;

        Transform shooter = enemies[Random.Range(0, enemies.Count)];
        Instantiate(bulletPrefab, shooter.position, Quaternion.identity);
    }
}
