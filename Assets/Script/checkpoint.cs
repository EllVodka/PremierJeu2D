using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private Transform spawnJoueur;
    public Animator mouvementDrapeau;
    private void Awake()
    {
        spawnJoueur = GameObject.FindGameObjectWithTag("ApparitionJoueur").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            mouvementDrapeau.SetTrigger("MouvementDuDrapeau");
            spawnJoueur.position = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
