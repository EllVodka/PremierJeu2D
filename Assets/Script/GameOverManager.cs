using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la sc�ne");
            return;
        }
        instance = this;
    }

    public void MortJoueur()
    {
        if(ManagerSceneActuel.instance.JoueurEstPresentParDefault)
        {
            NePasDetruireChargementScene.instance.RemoveFromDontDestroyOnLoad();
        }

        gameOverUI.SetActive(true);
    }

    public void ReessayerBTN()
    {
        inventaire.instance.EnlevePiece(ManagerSceneActuel.instance.nbPieceRamasse);
        //Recharger la sc�ne
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        joueurVie.instance.respawn();

        gameOverUI.SetActive(false);
    }
    public void MenuPrincipalBTN()
    {
        NePasDetruireChargementScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void QuitterBTN()
    {
        //Fermer le jeu
        Application.Quit();
    }
}
