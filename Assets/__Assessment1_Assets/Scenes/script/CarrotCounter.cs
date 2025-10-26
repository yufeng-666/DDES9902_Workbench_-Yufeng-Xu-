using UnityEngine;
public class CarrotCounter : MonoBehaviour
{
    public int currentCount = 0; 
   
    public void AddCount() { currentCount++; }
    
    public void MinusCount() { currentCount--; }
}