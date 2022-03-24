using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credit : MonoBehaviour
{
    public void ChargementMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChargementMenuPrincipal();
        }
    }
}
