using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 2f;
    [SerializeField] private float projectileHealth = 200f;
    [SerializeField] private float damage = 100f;

    void Update()
    {
        MoveProjectile();
    }
    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * (projectileSpeed * Time.deltaTime));
    }
    private void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<Health>();
        var enemy = other.GetComponent<Enemy>();

        if (!health || !enemy) return;
        health.DealDamage(damage);

        DestroyProjectile();
    }
    private void DestroyProjectile()
    {
        projectileHealth -= damage;
        if (projectileHealth <= 0)
            Destroy(gameObject);
    }
}
