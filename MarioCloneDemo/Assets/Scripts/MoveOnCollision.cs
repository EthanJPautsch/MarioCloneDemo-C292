using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnCollision : MonoBehaviour
{
    [SerializeField] float speed = 0;
    private float startLocation;
    private float endLocation;
    [SerializeField] float distance;
    private Vector3 direction = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        startLocation = transform.position.y;

        endLocation = startLocation + distance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speed = 20;
            transform.Translate(direction * speed * Time.deltaTime);

            if (transform.position.y >= endLocation)
            {
                direction = Vector3.down;
            }
            else if (transform.position.y < startLocation)
            {
                direction = Vector3.up;
            }
        }
    }
}
