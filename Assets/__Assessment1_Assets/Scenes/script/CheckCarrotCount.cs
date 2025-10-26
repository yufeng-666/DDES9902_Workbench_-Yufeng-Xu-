using UnityEngine;
using UnityEngine.Events;

public class CheckCarrotCount : MonoBehaviour
{
    public CarrotCounter carrotCounter; 
    public int targetCount = 3;
    public UnityEvent onCorrect;
    public UnityEvent onWrong; 
    public void CheckCount()
    {
        Debug.Log("current number £º" + carrotCounter.currentCount); 
        if (carrotCounter.currentCount == targetCount)
            onCorrect.Invoke();
        else
            onWrong.Invoke();
    }
}