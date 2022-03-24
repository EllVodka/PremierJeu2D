using UnityEngine;
using System.Collections;

public class joueurVie : MonoBehaviour
{
    public int maxVie = 100;
    public int vieActuel;

    public float invincibiliteTempsApresHit = 3f;
    public float invincibiliteFlashDelai = 0.15f;
    public bool estInvincible = false;

    public SpriteRenderer graphics;
    public barreDeVie BarreDeVie;

    public AudioClip sonDegat;

    public static joueurVie instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de joueurVie dans la scène");
            return;
        }
        instance = this;
    }

    void Start()
    {
        vieActuel = maxVie;
        BarreDeVie.SetMaxVie(maxVie);
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)) 
        {
            PrendreDegat(80);
        }
    }

    public void PrendreDegat(int degat)
    {
        if (!estInvincible)
        {
            AudioManager.instance.JouerPiste(sonDegat, transform.position);

            vieActuel -= degat;
            BarreDeVie.SetVie(vieActuel);
            //verifier si le joueur est toujour vivant
            if (vieActuel <= 0)
            {
                Mort();
                return;
            }


            estInvincible = true;
            StartCoroutine(InvincibleFlash());
            StartCoroutine(DureeInvincibilite());

        }
    }

    public void Mort()
    {
        //bloque les mouvements du perso 
        deplacementJoueur.instance.enabled = false;
        //jouerl'animation de mort
        deplacementJoueur.instance.animator.SetTrigger("Mort");
        //empêche les interactions physique avec les autres éléments de la scène
        deplacementJoueur.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        deplacementJoueur.instance.rb.velocity = Vector3.zero;
        deplacementJoueur.instance.CapsuleCollider.enabled = false;
        GameOverManager.instance.MortJoueur();

    }
    public void respawn()
    {
        //autorise les mouvements du perso 
        deplacementJoueur.instance.enabled = true;
        //jouerl'animation de respawn
        deplacementJoueur.instance.animator.SetTrigger("Respawn");
        deplacementJoueur.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        deplacementJoueur.instance.CapsuleCollider.enabled = true;
        vieActuel = maxVie;
        BarreDeVie.SetVie(vieActuel);
    }
    public void SoinJoueur(int soin)
    {
        if ((vieActuel + soin)>maxVie)
        {
            vieActuel = maxVie;
        }
        else
        {
            vieActuel += soin;
            
        }
        BarreDeVie.SetVie(vieActuel);
    }

    public IEnumerator InvincibleFlash()
    {
        while(estInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibiliteFlashDelai);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibiliteFlashDelai);
        }
    }

    public IEnumerator DureeInvincibilite()
    {
        yield return new WaitForSeconds(invincibiliteTempsApresHit);
        estInvincible = false;
    }

}
