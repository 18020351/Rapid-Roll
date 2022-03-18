using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private float horizontalInput;
    public float speed = 100f;
    public float timeWait = 1f;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector2.right * horizontalInput * speed * Time.deltaTime, ForceMode2D.Impulse);
        GameManager.instanceGameManager.addSocre(playerRb);
    }
    private void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Bottom" || other.gameObject.tag == "Bound")
        {
            this.gameObject.SetActive(false);
            GameManager.instanceGameManager.Die();
            GameManager.instanceGameManager.CallBackDie(WaitRevival(timeWait));
        }
        else if (other.gameObject.CompareTag("Lives"))
        {
            GameManager.instanceGameManager.AddLives();
            Destroy(other.gameObject);
        }
    }
    private IEnumerator WaitRevival(float timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        this.gameObject.SetActive(true);
        this.transform.position = Vector3.zero;
    }
    public void ReSpawn()
    {
        gameObject.SetActive(true);
        this.transform.position = Vector3.zero;
    }
}
