using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public TextMeshProUGUI upgradeText;
    public Button upgradeButton;
    public TextMeshProUGUI upgradeButtonText;

    public string upgradeName;
    public float upgradeIncrement;
    public int upgradeCost;

    public enum UpgradeType {SPAWNINTERVAL, OBJECTVALUE, HOTCHIP, FALLSPEED}

    public UpgradeType upgradeType;

    public AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (upgradeType == UpgradeType.SPAWNINTERVAL)
        {
            upgradeText.text = upgradeName + ": " + GameManager.Instance.spawnInterval.ToString("#.##");
            upgradeButtonText.text = upgradeIncrement.ToString() + " for " + upgradeCost + " Chips";

            if (GameManager.Instance.spawnInterval < 0.03f) {
                upgradeText.text = upgradeName + ", Maxed at: " + GameManager.Instance.spawnInterval.ToString("#.##");
                upgradeButton.interactable = false;
            }
        }
        if (upgradeType == UpgradeType.OBJECTVALUE)
        {
            upgradeText.text = upgradeName + ": " + GameManager.Instance.fallingObjectValue;
            upgradeButtonText.text = upgradeIncrement.ToString() + " for " + upgradeCost + " Chips";
        }

        if (upgradeType == UpgradeType.FALLSPEED)
        {
            upgradeText.text = upgradeName + ": " + GameManager.Instance.fallSpeed.ToString("#.##");
            upgradeButtonText.text = upgradeIncrement.ToString() + " for " + upgradeCost + " Chips";
        }

        if (upgradeType == UpgradeType.HOTCHIP) {
            upgradeText.text = "Hot Chips " + (GameManager.Instance.isHotUnlocked ? "Unlocked" : "Locked");
            upgradeButtonText.text = "Unlock for " + upgradeCost + " Chips";
            if (GameManager.Instance.isHotUnlocked) {
                upgradeButton.interactable = false;
            }
        }


    }

    public void UpgradeField() {
        if (upgradeCost < GameManager.Instance.score) {
            if (upgradeType == UpgradeType.SPAWNINTERVAL) {
                GameManager.Instance.spawnInterval += upgradeIncrement;
            }
            else if (upgradeType == UpgradeType.OBJECTVALUE) {
                GameManager.Instance.fallingObjectValue += (int)(upgradeIncrement + 0.5f);
            } else if (upgradeType == UpgradeType.FALLSPEED) {
                GameManager.Instance.fallSpeed += 0.1f;
            }
            GameManager.Instance.score -= upgradeCost;
            upgradeCost = (int)(upgradeCost * 1.2f);

            audioSource.time = 0;
            audioSource.Play();
        }

    }

    public void HotUpgrade() {
        if (upgradeCost < GameManager.Instance.score) {
            GameManager.Instance.isHotUnlocked = true;
            GameManager.Instance.score -= upgradeCost;

            audioSource.time = 0;
            audioSource.Play();
        }
    }
}
