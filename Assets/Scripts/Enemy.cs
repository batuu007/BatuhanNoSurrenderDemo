using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject center;
    private Transform target;
  
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Center").transform;
    }

    void Update()
    {
        EnemyMove();
    }
    private void EnemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
