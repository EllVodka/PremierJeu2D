using UnityEngine;

public class SoinPowerUp : MonoBehaviour
{

    public int PV;

    public AudioClip ramaseSon;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && joueurVie.instance.vieActuel < joueurVie.instance.maxVie)
        {
            AudioManager.instance.JouerPiste(ramaseSon, transform.position);
            //rendre de la vie au joueur
            joueurVie.instance.SoinJoueur(PV);
            Destroy(gameObject);
        }
    }
}
