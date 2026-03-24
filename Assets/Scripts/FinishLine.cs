using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public ResultUI resultUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Timer.instance.StopTimer();

            resultUI.gameObject.SetActive(true);
            resultUI.ShowResult();

            // 1. สั่งให้เมาส์แสดงขึ้นมาบนหน้าจอ
            Cursor.visible = true;

            // 2. ปลดล็อคเมาส์ที่อาจจะถูกล็อคไว้กลางจอ ให้ขยับไปมาคลิก UI ได้
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0f;
        }
    }
}