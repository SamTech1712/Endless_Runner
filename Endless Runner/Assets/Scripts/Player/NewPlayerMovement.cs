using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public ParticleSystem dust;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float minVelocity;
    [Header("Acceleration and drag")]
    [SerializeField]
    private float airAcceleration;
    [SerializeField]
    private float airDrag;
    [SerializeField]
    private float groundAcceleration, groundDrag;

    [Header("Dont edit only see")]
    public bool isGrounded;
    public bool isBlockedLeft;
    public bool isBlockedRight;
    public bool isInJump { get; private set; }
    public float velocity { get; private set; }

    Rigidbody2D rb2D;

    private float xInput;
    private bool jumpInput;

    private float acceleration;
    private float drag;
  
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        JumpIfInput();

        CalculateDragAndAcceleration();

        Move();

    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A))
            xInput = -1;
        else if (Input.GetKey(KeyCode.D))
            xInput = 1;
        else
            xInput = 0;
        jumpInput = Input.GetKeyDown(KeyCode.Space);
    }

    private void JumpIfInput()
    {
        if (isGrounded && jumpInput)
        {
            rb2D.AddForce(new Vector2(0, 1) * jumpForce * 20f, ForceMode2D.Force);
            jumpInput = false;
            isInJump = true;
            StartCoroutine(ResetIsInJump());
        }
    }

    private void Move()
    {
        if (xInput != 0)
        {
            velocity += -xInput * acceleration;
            float maxClamp = isBlockedLeft ? 0 : speed;
            float minClamp = isBlockedRight ? 0 : -speed;
            velocity = Mathf.Clamp(velocity, minClamp, maxClamp);
        }
        else if (!isInJump)
        {
            float polarity = (velocity != 0) ? PolarityOf(velocity) : 0;
            velocity += -polarity * drag;
            //velocity = (polarity == PolarityOf(velocity)) ? velocity : 0;
            float maxClamp = isBlockedLeft ? 0 : speed;
            float minClamp = isBlockedRight ? 0 : -speed;
            velocity = Mathf.Clamp(velocity, minClamp, maxClamp);
            velocity = Clamp0(velocity, -minVelocity, minVelocity);
        }
        
        MapCreator.instance.Move(velocity * Time.deltaTime);
    }

    private void CalculateDragAndAcceleration()
    {
        if (isGrounded)
        {
            drag = groundDrag;
            acceleration = groundAcceleration;
        } else {
            drag = airDrag;
            acceleration = airAcceleration;
        }
    }
    
    private float Clamp0(float value, float min, float max)
    {
        if(value > min  || value < max)
        {
            return 0;
        }
        return value;
    }

    public void CreateDust()
    {
        dust.Play();
    }

    IEnumerator ResetIsInJump()
    {
        yield return new WaitForSeconds(0.1f);
        while (!isGrounded)
        {
            yield return null;
        }
        isInJump = false;
    }

    private float PolarityOf(float value)
    {
        if(value < 0)
        {
            return -1;
        }
        return 1;
    }

}
