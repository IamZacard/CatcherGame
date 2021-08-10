using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidBody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Danger"))
        {
            Destroy(gameObject);
        }
    }
}

