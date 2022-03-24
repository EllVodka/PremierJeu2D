using UnityEngine;

public class pointFaible : MonoBehaviour
{
    public GameObject objectToDestroy;
    public AudioClip sonMort;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.JouerPiste(sonMort, transform.position);
            Destroy(objectToDestroy);
        }
    }
}
