using UnityEngine;

public class deplacementJoueur : MonoBehaviour
{
    public float vitesseMouvement;
    public float vistesseGrimper;
    public float forceSaut;

    private bool sauter;
    private bool auSol;
    [HideInInspector]
    public bool grimper;

    public Transform verifSol;
    public float verifSolRayon;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D CapsuleCollider;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMouvement;
    private float verticalMouvement;

    public static deplacementJoueur instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de joueurVie dans la scène");
            return;
        }

        instance = this;
    }

    void Update()
    {

        horizontalMouvement = Input.GetAxis("Horizontal") * vitesseMouvement * Time.fixedDeltaTime;
        verticalMouvement = Input.GetAxis("Vertical") * vitesseMouvement * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump") && auSol && !grimper)
        {
            sauter = true;
        }
        Flip(rb.velocity.x);

        float velocitePersonnage = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Vitesse", velocitePersonnage);
        animator.SetBool("EntrainDeGrimper", grimper);
    }
    void FixedUpdate()
    {
        auSol = Physics2D.OverlapCircle(verifSol.position, verifSolRayon, collisionLayers);
        mouvementJoueur(horizontalMouvement, verticalMouvement);
    }

    void mouvementJoueur(float _horizontalMouvement, float _vericalMouvement)
    {
        if(!grimper)
        {
            //si le joueur grimpe pas
            Vector3 targetVelocity = new Vector2(_horizontalMouvement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

            if (sauter == true)
            {
                rb.AddForce(new Vector2(0f, forceSaut));
                sauter = false;
            }
        }
        else
        {
            //si le joueur grimpe
            Vector3 targetVelocity = new Vector2(0, _vericalMouvement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        }


    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void onDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(verifSol.position, verifSolRayon);
    }

}
