using UnityEngine.SceneManagement;
using UnityEngine;

public class NePasDetruireChargementScene : MonoBehaviour
{
    public GameObject[] objects;

    public static NePasDetruireChargementScene instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de NePasDetruireChargementScene dans la scène");
            return;
        }

        instance = this;


        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }

 
}
