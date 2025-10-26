using UnityEngine;

public class RabbitRunner : MonoBehaviour
{
    public Transform targetPoint;
    public float moveSpeed = 2f;
    public float delayTime; 
    private Animator anim;
    private bool isRunning = false;
    private bool canStart = false; 

    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    
    public void StartRunningSequence()
    {
        canStart = true;
       
        Invoke("StartRunning", delayTime);
    }

    void StartRunning()
    {
        if (canStart)
        { 
            isRunning = true;
            anim.Play("Run");
        }
    }

    void Update()
    {
        if (isRunning && targetPoint != null)
        {
            
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPoint.position,
                moveSpeed * Time.deltaTime
            );
            transform.LookAt(targetPoint);

            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                isRunning = false;
                anim.Play("Idle");
            }
        }
    }
}