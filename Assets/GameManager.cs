using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(this);
        }
    }

    public bool isPaused;
    public Canvas PauseCanvas;

    public GameObject FallingObjectPrefab;
    public GameObject HotFallingObjectPrefab;

    public bool isHotUnlocked;

    public GameObject FallOrigin;

    public float fallTimer;
    public float fallSpeed = 1;

    public Slider slider;
    public GameObject cup;

    public int score;
    public TextMeshProUGUI scoreText;

    public float spawnInterval = 0.2f;
    public int fallingObjectValue;

    public AudioSource audioSource;
    public List<AudioClip> crunchSounds;

    public Canvas FinishCanvas;
    public bool milestoneReached;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fallTimer = spawnInterval;

        isPaused = false;
        PauseCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (!isPaused) {
            fallTimer -= Time.deltaTime;
        }
        if (fallTimer <= 0) {

            Quaternion randomRotation = Quaternion.Euler(0,0, Random.Range(0,120));
            if (isHotUnlocked) {
                if (Random.Range(0,100) < 90) {
                    GameObject FallingObject = Instantiate(FallingObjectPrefab, FallOrigin.transform.position, randomRotation);
                } else {
                    GameObject FallingObject = Instantiate(HotFallingObjectPrefab, FallOrigin.transform.position, randomRotation);

                }
            } else {
                GameObject FallingObject = Instantiate(FallingObjectPrefab, FallOrigin.transform.position, randomRotation);

            }
            fallTimer = spawnInterval;
        }


        //when slider == 0, cup at -8 x
        //when slider == 1, cup at 8 x
        cup.transform.position = new Vector2((slider.value - 0.5f) * 16 ,-3.5f);

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            TogglePause();
        }

        scoreText.text = score.ToString() + " chips";

        if (score > 100000 && !milestoneReached) {
            FinishCanvas.gameObject.SetActive(true);
            milestoneReached = true;
        }
    }


    public void TogglePause() {
        isPaused = !isPaused;
        PauseCanvas.gameObject.SetActive(isPaused);
    }

    public void PlayCrunchSound() {
        audioSource.clip = crunchSounds[Random.Range(0, crunchSounds.Count)];
        audioSource.Play();

    }
}
