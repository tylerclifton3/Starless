using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField] float speed = 20f;

    public void Shoot(Vector3 targetPosition) {
        Rigidbody2D newProjectileRB = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        targetPosition.z = 0;
        newProjectileRB.MoveRotation(Quaternion.LookRotation(transform.forward, (targetPosition - transform.position)));
        newProjectileRB.velocity = (targetPosition - transform.position).normalized * speed;
    }
}
