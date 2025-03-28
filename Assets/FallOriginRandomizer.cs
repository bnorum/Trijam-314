using UnityEngine;

public class FallOriginRandomizer : MonoBehaviour
{

    public float relocateTimer;
    public float relocateTimerMax = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        relocateTimer = relocateTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isPaused) {
            relocateTimer -= Time.deltaTime;
        }

        if (relocateTimer <= 0) {
            transform.position = new Vector2(Random.Range(-8,8), transform.position.y);
            relocateTimer = relocateTimerMax;
        }
    }
}
