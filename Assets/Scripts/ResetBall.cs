using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetBall : MonoBehaviour
{
    public float thresHold = -50f;

    
    void Update()
    {
        if(transform.position.y < thresHold) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }    
    }
}
