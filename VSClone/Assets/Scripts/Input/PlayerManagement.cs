using GenericSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagement : MonoBehaviour, IDamageable, GenericSave.IDataPersistence
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator animator;
    [SerializeField] GenericHealthBar.PlayerHealthBar healthBar;
    private HasDash dashComponent;

    [Header("HealthManagement")]
    [SerializeField] private int maxHealth = 400;
    [SerializeField] private int currentHealth = 400;

    [Header("IFrames")]
    [SerializeField] private List<LayerMask> layersToIgnore;
    [SerializeField] private float iFrameDuration = 2;
    [SerializeField] private int numberOfFlashes = 3;
    private SpriteRenderer spriteRenderer;

    // TODO: Direction Management WIP
    private Vector2 facingDirection = Vector2.down;     //Temporarily, player will be always facing down in terms of code
    private float facingDirectionLength = 0.75f;        //How far infront of player raycast will shoot to check for IInteractable
    private bool facingRight = true;
    private Vector2 aim;

    [Header("Interaction")]
    [SerializeField] private LayerMask layer;
    RaycastHit2D interactHit;

    [Header("Movement")]
    [SerializeField] private float walkSpeed = 5; //Walkspeed
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 RawMovementInput;
    private bool isSprinting;
    private bool Move;

    [Header("Footstep Noise Parameters")]
    [SerializeField] private Transform raycastTransform;
    [SerializeField] private float baseStepSpeed = 0.5f;        //This is how often a footstep sound occurs
    [SerializeField] private float crouchStepMultiplier = 1.5f;
    [SerializeField] private float sprintStepMultiplier = 6.0f;
    [SerializeField] private AudioSource footStepAudioSource;
    [SerializeField] private AudioClip[] grassSteps;
    [SerializeField] private AudioClip[] dirtSteps;
    [SerializeField] private AudioClip[] rockSteps;
    private float footStepTimer = 0;    

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dashComponent = GetComponent<HasDash>();
    }

    private void Start()
    {
        float healthPercent = ((float)currentHealth / (float)maxHealth) * 100;

        healthBar.SetHealth(healthPercent);
    }

    private void Update()
    {
        //Animation Management
        animator.SetFloat("Vertical", RawMovementInput.y);
        animator.SetFloat("Horizontal", Mathf.Abs(RawMovementInput.x));

        animator.SetBool("Move", Move);

        ManageFootstepSounds();

        //Interact raycast
        interactHit = Physics2D.Raycast(this.transform.position, facingDirection, facingDirectionLength, layer);
        Debug.DrawRay(this.transform.position, facingDirection, Color.red);
    }

    private void FixedUpdate()
    {
        if (!dashComponent.IsDashing)
        {
            ManageHorizontalMovement();
        }   
    }

    private void ManageHorizontalMovement()
    {
        rb2d.MovePosition(rb2d.position + moveDirection * walkSpeed * Time.deltaTime);
    }

    private void ManageFootstepSounds()
    {
        if (Mathf.Abs(RawMovementInput.x) < 0.0001 && Mathf.Abs(RawMovementInput.y) < 0.0001) return;  //If not moving then return
            
        //if (Physics.Raycast(raycastTransform.position, Vector3.down, out RaycastHit hit, 20))
        //{
        //    switch (hit.collider.tag)
        //    {
        //        case "Footsteps/Grass":
        //            Debug.Log("Grassy");
        //            //footStepAudioSource.PlayOneShot(grassSteps[Random.Range(0, grassSteps.Length - 1)]);
        //            break;
        //        case "Footsteps/Dirt":
        //            Debug.Log("Dirty");
        //            //footStepAudioSource.PlayOneShot(dirtSteps[Random.Range(0, dirtSteps.Length - 1)]);
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        float healthPercent = ((float)currentHealth / (float)maxHealth) * 100;

        healthBar.SetHealth(healthPercent);

        if (maxHealth <= 0)
        {
            Debug.Log("Player Dead");
        }
        else
        {
            StartCoroutine(Invunerability());
        }
    }

    private void AdjustHealthBar()
    {

    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private IEnumerator Invunerability()
    {
        //Layer Player ignores Layer Enemy
        Physics2D.IgnoreLayerCollision(3, 9, true);
        //Layer Player ignores Layer EnemyBullet
        Physics2D.IgnoreLayerCollision(3, 11, true);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration/(numberOfFlashes*2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
        }

        //Enable collision from enemies
        Physics2D.IgnoreLayerCollision(3, 9, false);
        Physics2D.IgnoreLayerCollision(3, 11, false);
    }

    #region InputManager 
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Move = true;
        }   
        else if (context.canceled)
        {
            Move = false;
        }

        RawMovementInput = context.ReadValue<Vector2>();

        moveDirection.x = RawMovementInput.x;
        moveDirection.y = RawMovementInput.y;

        //Debug.Log(moveDirection.x);

        //Temporary Flip Manager  https://www.youtube.com/watch?v=Cr-j7EoM8bg go here for better flip 
        //Make face right
        if (RawMovementInput.x > 0.6 && !facingRight)
        {
            Flip();
        }
        //Make face left
        if (RawMovementInput.x < -0.6 && facingRight)
        {
            Flip();
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started && dashComponent.CanDash)
        {
            if (moveDirection != Vector2.zero)
            {
                dashComponent.StartDash(moveDirection);
            }
            else
            {   
                dashComponent.StartDash(new Vector2(0, -1));    // TODO: Dash a distance based on player direction if not moving
            }
        }
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (interactHit.collider != null)
            {
                interactHit.collider.GetComponent<IInteractable>().OnInteract();
            }
        }
    }

    public void AimInput(InputAction.CallbackContext context)
    {
        aim = context.ReadValue<Vector2>();
    }
    #endregion

    // Save and load player health
    public void LoadData(GameData data)
    {
        currentHealth = data.playerHealth;
        transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerHealth = currentHealth;
        data.playerPosition = CheckpointManager.Instance.lastCheckPoint;
    }
}
