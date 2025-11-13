using UnityEngine;
using TMPro;

public class Level3Manager : MonoBehaviour
{
   
    public CarrotCounter carrotCounter;
    public TextMeshProUGUI countDisplayText;
    public GameObject nextButton;
    public GameObject player;
    public Transform level4SpawnPoint;
    public int targetCarrotCount = 2;
    void Start()
    {
        if (nextButton != null)
        {
            nextButton.SetActive(false);
        }
        UpdateCountDisplay(0);
    }

    void Update()
    {
        if (carrotCounter == null)
        {
            Debug.LogWarning("Level3Manager: CarrotCounter is not assigned!");
            return;
        }

        UpdateCountDisplay(carrotCounter.currentCount);

        if (carrotCounter.currentCount == targetCarrotCount && nextButton != null && !nextButton.activeSelf)
        {
            nextButton.SetActive(true);
        }
    }
    void UpdateCountDisplay(int count)
    {
        if (countDisplayText != null)
        {
            countDisplayText.text = "Carrot Number: " + count;
        }
    }    
    public void OnNextButtonClicked()
    {
        Debug.Log("Next button clicked! Initiating transition to Level 4...");

        if (player == null || level4SpawnPoint == null)
        {
            Debug.LogError("Level3Manager: Player or Level4SpawnPoint is not assigned! Teleport failed.");
            return;
        }

        TeleportToLevel4();
    }
    void TeleportToLevel4()
    {
        player.transform.position = level4SpawnPoint.position;
        player.transform.rotation = level4SpawnPoint.rotation;

        Debug.Log("Teleport successful! Welcome to Level 4.");
    }
}