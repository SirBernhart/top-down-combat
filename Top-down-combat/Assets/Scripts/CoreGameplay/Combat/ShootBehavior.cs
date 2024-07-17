using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;

    public void Shoot(Vector2 direction, Vector2 origin)
    {
        Instantiate(projectilePrefab, origin, Quaternion.identity).SetUp(direction);
    }
}
