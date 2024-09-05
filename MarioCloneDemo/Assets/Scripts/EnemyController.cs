using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    [SerializeField] float speed;
    private float startLocation;
    private float endLocation;
    [SerializeField] float distance;
    private Vector3 direction = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startLocation = transform.position.y;

        endLocation = startLocation + distance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y >= endLocation)
        {
            direction = Vector3.right;
        }
        else if (transform.position.y < startLocation)
        {
            direction = Vector3.left;
        }
        Move();
    }

    private void Move()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
