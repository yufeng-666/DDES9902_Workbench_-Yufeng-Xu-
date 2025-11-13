using UnityEngine;
using TMPro;

public class Level2Manager : MonoBehaviour
{ 
    public CarrotCounter carrotCounter;
    public TextMeshProUGUI countDisplayText;
    public GameObject nextButton;
    public GameObject player;   
    public Transform level3SpawnPoint;
    public int targetCarrotCount = 5;
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
            Debug.LogWarning("Level2Manager: CarrotCounter is not assigned!");
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
        Debug.Log("Next button clicked! Initiating transition to Level 3...");

        if (player == null || level3SpawnPoint == null)
        {
            Debug.LogError("Level2Manager: Player or Level3SpawnPoint is not assigned! Teleport failed.");
            return;
        }

        TeleportToLevel3();
    }
    void TeleportToLevel3()
    {
        player.transform.position = level3SpawnPoint.position;
        player.transform.rotation = level3SpawnPoint.rotation;

        Debug.Log("Teleport successful! Welcome to Level 3.");
    }
}