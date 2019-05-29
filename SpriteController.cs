using UnityEngine;
using UnityEngine.Events;

public class SpriteController : MonoBehaviour
{
                           
    [SerializeField] private LayerMask Ground;                          
    [SerializeField] private Transform GroundCheck;                           

    const float GroundedRadius = .2f; 
    private bool Grounded;            
    private Rigidbody2D rigidbody;
    private bool Facing = true;  
    private Vector3 velocity = Vector3.zero;
    private float jumpForce = 700f;
    private float smoothMovement = .05f;
    private bool airControl = true;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

    }

    private void FixedUpdate()
    {
        bool grounded = Grounded;
        Grounded = false;

        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, Ground);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                Grounded = true;
                if (!grounded)
                    OnLandEvent.Invoke();
            }
        }
    }


    public void Move(float move, bool jump)
    {

        if (Grounded || airControl)
        {

            
            Vector3 targetVelocity = new Vector2(move * 10f, rigidbody.velocity.y);
            rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref velocity, smoothMovement);

            if (move > 0 && !Facing)
            {
                Flip();
            }
            else if (move < 0 && Facing)
            {
                Flip();
            }
        }
        if (Grounded && jump)
        {
            Grounded = false;
            rigidbody.AddForce(new Vector2(0f, jumpForce));
        }
    }


    private void Flip()
    {
        Facing = !Facing;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
