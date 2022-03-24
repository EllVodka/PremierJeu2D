using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string niveauACharger;

    public GameObject fenetrePrametre;
    public void CommencerJeu()
    {
        SceneManager.LoadScene(niveauACharger);
    }
    public void Parametre()
    {
        fenetrePrametre.SetActive(true);
    }

    public void FermerFenetreParametre()
    {
        fenetrePrametre.SetActive(false);
    }
    public void QuitterJeu()
    {
        Application.Quit();
    }

    public void ChargerCreditScene()
    {
        SceneManager.LoadScene("credit");
    }
}
