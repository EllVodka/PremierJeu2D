using UnityEngine;

public class ManagerSceneActuel : MonoBehaviour
{
    public bool JoueurEstPresentParDefault = false;
    public int nbPieceRamasse;

    public static ManagerSceneActuel instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ManagerSceneActuel dans la scène");
            return;
        }

        instance = this;

    }
}
