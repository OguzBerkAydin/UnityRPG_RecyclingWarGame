using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public GameObject player;
    public GameObject deathMenu;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            Destroy(player);
            deathMenu.SetActive(true);

        }
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
