using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class chargerSceneSpecifique : MonoBehaviour
{
    public string sceneName;
    public Animator fonduSyst;
    public Text interactionUI;
    public bool estAPorter = false;

    private void Awake()
    {
        fonduSyst = GameObject.FindGameObjectWithTag("FonduSyst").GetComponent<Animator>();
        interactionUI = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<Text>();
    }

    void Update()
    {
        if (estAPorter && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(FonduProchaineScene());
            interactionUI.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            interactionUI.enabled = true;
            estAPorter = true;
        }

        
            
    }

    public IEnumerator FonduProchaineScene()
    {
        fonduSyst.SetTrigger("FonduDemarrage");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}


