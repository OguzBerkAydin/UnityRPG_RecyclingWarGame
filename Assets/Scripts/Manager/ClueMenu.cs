using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueMenu : MonoBehaviour
{
    public GameObject clueMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowClueMenu()
    {
        clueMenu.SetActive(true);
    }
    public void HideClueMenu()
    {
        clueMenu.SetActive(false);

    }
}
