using UnityEngine;
using UnityEngine.UI;

public class echelle : MonoBehaviour
{
    public bool estAPorter;
    private deplacementJoueur deplacementJoueur;
    public BoxCollider2D colliderDuHaut;
    private Text interactionUI;

    void Awake()
    {
        deplacementJoueur = GameObject.FindGameObjectWithTag("Player").GetComponent<deplacementJoueur>();
        interactionUI = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(estAPorter && deplacementJoueur.grimper && Input.GetKeyDown(KeyCode.E))
        {
            deplacementJoueur.grimper = false;
            colliderDuHaut.isTrigger = true;
            return;
        }

        if(estAPorter && Input.GetKeyDown(KeyCode.E))
        {
            deplacementJoueur.grimper = true;
            colliderDuHaut.isTrigger = true;
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionUI.enabled = false;
            estAPorter = false;
            deplacementJoueur.grimper = false;
            colliderDuHaut.isTrigger = false;
        }
    }
}
