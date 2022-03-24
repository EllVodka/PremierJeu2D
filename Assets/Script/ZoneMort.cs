using UnityEngine;
using System.Collections;

public class ZoneMort : MonoBehaviour
{
    private Transform apparationJoueur;
    private Animator fonduSyst;


    private void Awake()
    {
        apparationJoueur = GameObject.FindGameObjectWithTag("ApparitionJoueur").transform;
        fonduSyst = GameObject.FindGameObjectWithTag("FonduSyst").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplaceJoueur(collision));
        }
    }

    private IEnumerator ReplaceJoueur(Collider2D collision)
    {
        fonduSyst.SetTrigger("FonduDemarrage");
        yield return new WaitForSeconds(1f);
        collision.transform.position = apparationJoueur.position;
    }
}
