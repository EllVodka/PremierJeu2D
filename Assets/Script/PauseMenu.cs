using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool jeuEstEnPause = false;

    public GameObject fenetrePrametre;
    public GameObject pauseMenuUi;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jeuEstEnPause)
            {
                Continuer();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        //desactivation des mouvements du joueur dans le menu pause
        deplacementJoueur.instance.enabled = false;
        pauseMenuUi.SetActive(true);
        //Mettre en pause le jeu
        Time.timeScale = 0;
        jeuEstEnPause = true;
    }

    public void Continuer()
    {
        deplacementJoueur.instance.enabled = true;
        fenetrePrametre.SetActive(false);
        pauseMenuUi.SetActive(false);        
        //Mettre en pause le jeu
        Time.timeScale = 1;
        jeuEstEnPause = false;
    }

    public void ChargementMenuPrincipal()
    {
        NePasDetruireChargementScene.instance.RemoveFromDontDestroyOnLoad();
        Continuer();
        SceneManager.LoadScene("MenuPrincipal");
    }
public void Parametre()
{
        fenetrePrametre.SetActive(true);
    }

    public void FermerFenetreParametre()
    {
        fenetrePrametre.SetActive(false);
    }

}