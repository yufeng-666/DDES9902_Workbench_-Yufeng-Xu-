using UnityEngine;
using TMPro;
using System.Collections;

public class Level1Manager : MonoBehaviour
{
    public CarrotCounter carrotCounter;
    public TextMeshProUGUI countDisplayText;
    public GameObject nextButton;
    public GameObject player;
    public Transform level2SpawnPoint;
    public int targetCarrotCount = 3;
    public AudioClip correctSound;  
    public AudioClip wrongSound;     
    public GameObject correctImage;  
    public GameObject wrongImage;   

    void Start()
    {
        nextButton.SetActive(true);  
        UpdateCountDisplay(0);
       
        correctImage.SetActive(false);
        wrongImage.SetActive(false);
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
        countDisplayText.text = "Carrot Number: " + count;
    }

    
    public void OnNextButtonClicked()
    {
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
        
        correctImage.SetActive(true);
        
        yield return new WaitForSeconds(5f);
       
        TeleportToLevel2();
    }

    
    IEnumerator WrongAnswerSequence()
    {
        
        if (wrongSound != null)
        {
            AudioSource.PlayClipAtPoint(wrongSound, transform.position);
        }
       
        wrongImage.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        wrongImage.SetActive(false);
    }

    void TeleportToLevel2()
    {
        player.transform.position = level2SpawnPoint.position;
        player.transform.rotation = level2SpawnPoint.rotation;
    }
}