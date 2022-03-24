using UnityEngine;

public class RamasseObject : MonoBehaviour
{
    public AudioClip son;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.JouerPiste(son, transform.position);
            inventaire.instance.AjoutPiece(1);
            ManagerSceneActuel.instance.nbPieceRamasse++;
            Destroy(gameObject);
        }
    }
}
