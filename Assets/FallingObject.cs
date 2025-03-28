using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public Rigidbody2D rb;

    public float timer = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = GameManager.Instance.fallSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPaused) {
            rb.bodyType = RigidbodyType2D.Static;
        } else {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if (!GameManager.Instance.isPaused) timer -= Time.deltaTime;
        if (timer < 0) Destroy(gameObject);
    }


}
