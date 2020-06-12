using UnityEngine.SceneManagement;
using UnityEngine;

public class HelmetPickUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
