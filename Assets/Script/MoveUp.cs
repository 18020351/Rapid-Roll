using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 10f;


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
}
