using UnityEngine;

public class Collector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FallingObject") {
            Destroy(collision.gameObject);
            GameManager.Instance.score += GameManager.Instance.fallingObjectValue;
            GameManager.Instance.PlayCrunchSound();
        }
        if (collision.gameObject.tag == "HotFallingObject") {
            Destroy(collision.gameObject);
            GameManager.Instance.score += GameManager.Instance.fallingObjectValue * 4;
            GameManager.Instance.PlayCrunchSound();
        }

    }
}
