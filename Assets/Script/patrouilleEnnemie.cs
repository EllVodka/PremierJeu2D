using UnityEngine;

public class patrouilleEnnemie : MonoBehaviour
{
    public float vitesse;
    public Transform[] pointDePassage;
    public SpriteRenderer Graphics;

    public int degatColision=10;

    private Transform cible;
    private int desPoint =0;

    void Start()
    {
        cible = pointDePassage[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = cible.position - transform.position;
        transform.Translate(dir.normalized * vitesse * Time.deltaTime, Space.World);

        // Si l'ennemie est quasiment arrivé a sa destination
        if(Vector3.Distance(transform.position, cible.position) < 0.3f)
        {
            desPoint = (desPoint + 1) % pointDePassage.Length;
            cible = pointDePassage[desPoint];
            Graphics.flipX = !Graphics.flipX;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            joueurVie vieDuJoueur = collision.transform.GetComponent<joueurVie>();
            vieDuJoueur.PrendreDegat(degatColision);
        }
    }
}
