using UnityEngine;
using UnityEngine.InputSystem;
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

        if (Keyboard.current.rKey.isPressed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
