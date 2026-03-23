using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Transform spawnPoint;
    public float thresHold = -50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < thresHold)
        {
            transform.position = spawnPoint.position;
        }
    }
}
