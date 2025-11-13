using UnityEngine;
using TMPro;

public class Level1Manager : MonoBehaviour
{
   
    public CarrotCounter carrotCounter; 
    public TextMeshProUGUI countDisplayText;
    public GameObject nextButton;
    public GameObject player;
    public Transform level2SpawnPoint;
    public int targetCarrotCount = 3;
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
            Debug.LogWarning("Level1Manager: CarrotCounter is not assigned!");
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
        Debug.Log("Next button clicked! Initiating transition to Level 2...");

        if (player == null || level2SpawnPoint == null)
        {
            Debug.LogError("Level1Manager: Player or Level2SpawnPoint is not assigned! Teleport failed.");
            return;
        }
        TeleportToLevel2();
    }
    void TeleportToLevel2()
    {
        player.transform.position = level2SpawnPoint.position;
        player.transform.rotation = level2SpawnPoint.rotation;

        Debug.Log("Teleport successful! Welcome to Level 2.");
    }
}