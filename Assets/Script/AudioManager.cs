using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public AudioMixerGroup effetSonoreMixer;

    private int musicIndex = 0;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instace de AudioManager dans la scene");
        }
        instance = this;
    }

    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();

        
    }


    void Update()
    {
        if (!audioSource.isPlaying)
        {
            JouerLaMusiqueSuivante();
        }
    }
    void JouerLaMusiqueSuivante()
    {
        musicIndex = (musicIndex + 1)%playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource JouerPiste(AudioClip clip,Vector3 pos)
    {
        //creation d'un game object vide
        GameObject tempGO = new GameObject("AudioTemporaire");
        //affectation de la position au son
        tempGO.transform.position = pos;
        //ajoute ajoute l'audio source dans un component
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = effetSonoreMixer;
        audioSource.Play();
        Destroy(tempGO,clip.length);
        return audioSource;

    }
}
