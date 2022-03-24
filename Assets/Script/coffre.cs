using UnityEngine;
using UnityEngine.UI;

public class coffre : MonoBehaviour
{
    private Text interactionUI;
    private bool estProche;

    public Animator animator;
    public int pieceAjoute;
    public AudioClip sonAJouer;

    void Awake()
    {
        interactionUI = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && estProche)
        {
            OuvertureCoffre();
        }
    }

    void OuvertureCoffre()
    {
        animator.SetTrigger("coffreOuvert");
        inventaire.instance.AjoutPiece(pieceAjoute);
        AudioManager.instance.JouerPiste(sonAJouer,transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        interactionUI.enabled = false;
        estProche = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionUI.enabled = true;
            estProche = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionUI.enabled = false;
            estProche = false;
        }

    }
}
