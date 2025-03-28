using UnityEngine;

public class FinishPanelManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToTitle() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }

    public void ContinueGame() {
        gameObject.SetActive(false);

    }
}
