using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    private float speed = 8f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void LateUpdate()
    {

        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (GameManager.instanceGameManager.lives == 0)
        {
            this.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bound"))
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        if (GameManager.instanceGameManager.lives == 0)
        {
            Destroy(gameObject);
        }
    }
}
