using UnityEngine;
using TMPro;
using System.Collections;

public class Level4Manager : MonoBehaviour
{
    
    public CarrotCounter leftBasketCounter;
    public CarrotCounter rightBasketCounter;  
    public TextMeshProUGUI leftCountText;
    public TextMeshProUGUI rightCountText;
    public GameObject nextButton;   
    public int targetPerBasket = 3;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    public GameObject correctImage;      
    public GameObject wrongImage;        
    public GameObject gameCompleteImage;
    public GameObject player;
    public ParticleSystem winParticles;

    void Start()
    {
        nextButton.SetActive(true);
        correctImage.SetActive(false);
        wrongImage.SetActive(false);
        gameCompleteImage.SetActive(false); 
        UpdateCountDisplays(0, 0);
    }

    void Update()
    {
        if (leftBasketCounter != null && rightBasketCounter != null)
        {
            UpdateCountDisplays(
                leftBasketCounter.currentCount,
                rightBasketCounter.currentCount
            );
        }
    }

    void UpdateCountDisplays(int leftCount, int rightCount)
    {
        if (leftCountText != null)
            leftCountText.text = "left: " + leftCount;
        if (rightCountText != null)
            rightCountText.text = "right: " + rightCount;
    }

    public void OnNextButtonClicked()
    {
        correctImage.SetActive(false);
        wrongImage.SetActive(false);
        gameCompleteImage.SetActive(false); 

        bool isLeftCorrect = leftBasketCounter.currentCount == targetPerBasket;
        bool isRightCorrect = rightBasketCounter.currentCount == targetPerBasket;

        if (isLeftCorrect && isRightCorrect)
        {
            
            StartCoroutine(GameCompleteSequence());
        }
        else
        {
            
            StartCoroutine(WrongAnswerSequence());
        }
    }
    IEnumerator GameCompleteSequence()
    {
       
        if (correctSound != null)
            AudioSource.PlayClipAtPoint(correctSound, transform.position);

       
        correctImage.SetActive(true);
        if (winParticles != null)
        {
            winParticles.transform.position = correctImage.transform.position; 
            winParticles.Play(); 
        }
        yield return new WaitForSeconds(2f); 
        correctImage.SetActive(false);

       
        gameCompleteImage.SetActive(true);

        
    }

   
    IEnumerator WrongAnswerSequence()
    {
        if (wrongSound != null)
            AudioSource.PlayClipAtPoint(wrongSound, transform.position);
        wrongImage.SetActive(true);
        yield return new WaitForSeconds(2f);
        wrongImage.SetActive(false);
    }
}