using UnityEngine;

public class suiviCamera : MonoBehaviour
{

    public GameObject joueur;
    public float tempsOffset;
    public Vector3 posOffset;

    private Vector3 velocite;
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, joueur.transform.position + posOffset, ref velocite, tempsOffset);
        
    }
}
