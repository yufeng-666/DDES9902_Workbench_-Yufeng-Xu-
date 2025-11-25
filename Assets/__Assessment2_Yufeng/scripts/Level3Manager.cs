using UnityEngine;
using TMPro;
using System.Collections;

public class Level3Manager : MonoBehaviour
{
   
    public CarrotCounter carrotCounter;
    public TextMeshProUGUI countDisplayText;
    public GameObject nextButton;
    public GameObject player;
    public Transform level4SpawnPoint;
    public int targetCarrotCount = 2; 
   
    public AudioClip correctSound;   
    public AudioClip wrongSound;     
    public GameObject correctImage;  
    public GameObject wrongImage;   

    void Start()
    {
        
        nextButton.SetActive(true);
        
        UpdateCountDisplay(0);
        
        if (correctImage != null) correctImage.SetActive(false);
        if (wrongImage != null) wrongImage.SetActive(false);
    }

    void Update()
    {
       
        if (carrotCounter != null)
        {
            UpdateCountDisplay(carrotCounter.currentCount);
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
        
        if (correctImage != null) correctImage.SetActive(false);
        if (wrongImage != null) wrongImage.SetActive(false);

       
        if (carrotCounter.currentCount == targetCarrotCount)
        {
            
            StartCoroutine(CorrectAnswerSequence());
        }
        else
        {
           
            StartCoroutine(WrongAnswerSequence());
        }
    }

    
    IEnumerator CorrectAnswerSequence()
    {
        
        if (correctSound != null)
        {
            AudioSource.PlayClipAtPoint(correctSound, transform.position);
        }
       
        if (correctImage != null)
        {
            correctImage.SetActive(true);
        }
       
        yield return new WaitForSeconds(5f);
       
        TeleportToLevel4();
    }

    
    IEnumerator WrongAnswerSequence()
    {
       
        if (wrongSound != null)
        {
            AudioSource.PlayClipAtPoint(wrongSound, transform.position);
        }
       
        if (wrongImage != null)
        {
            wrongImage.SetActive(true);
        }
       
        yield return new WaitForSeconds(2f);
        if (wrongImage != null)
        {
            wrongImage.SetActive(false);
        }
    }

   
    void TeleportToLevel4()
    {
        if (player != null && level4SpawnPoint != null)
        {
            player.transform.position = level4SpawnPoint.position;
            player.transform.rotation = level4SpawnPoint.rotation;
            Debug.Log("Teleport successful! Welcome to Level 4.");
        }
        else
        {
            Debug.LogError("Level3Manager: Player or Level4SpawnPoint is not assigned! Teleport failed.");
        }
    }
}