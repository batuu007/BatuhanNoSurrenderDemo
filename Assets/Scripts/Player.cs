using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    bool isDeath=false;
    float horizontal;
    float vertical;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal * moveSpeed, 0.0f, vertical * moveSpeed);
        rb.AddForce(move);  
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Death")
        {
            isDeath = true;
            SceneManager.LoadScene(0);
        }
    }
}
