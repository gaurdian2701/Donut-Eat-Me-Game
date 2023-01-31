using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private PlayerActionAsset donutActionAsset;
    private InputAction move;
    [SerializeField] private float rotspeed;
    private RigidbodyConstraints originalConstraints;

    [Header("MOVEMENT SETTINGS")]
    [SerializeField] private float movementForce = 6f;
    [SerializeField] private float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;
    private Rigidbody rb;

    [SerializeField] private Camera playerCamera;
    private Animator animator;

    [Header("DASH SETTINGS")]
    [SerializeField] ParticleSystem dash_ps;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.3f;
    [SerializeField] private float dashingCooldown = 0.5f;
    private float dash;
    private bool canDash = true;
    public bool isDashing;

    [Header("COMBAT AND HEALTH SETTINGS")]
    public bool isAttacking = false;
    [SerializeField] private float attackCooldown = 0.5f;
    private bool canAttack = true;
    [SerializeField] private CapsuleCollider Hurtbox;
    [SerializeField] private float knockbackForce = 1f;
    [SerializeField] private HealthSystem healthSystem;

    [Header("SOUND SETTINGS")]
    [SerializeField] private PlayerSoundManager playerSounds;
    public EnvSoundManager envSounds;

    private void Start()
    {
        donutActionAsset.Player.Dodge.performed += ctx =>
        {
            dash = ctx.ReadValue<float>();
        };
        playerSounds.PlaySpawnSound();
        envSounds = GameObject.Find("Env").GetComponent<EnvSoundManager>();
        envSounds.PlayGameMusic();
    }

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        originalConstraints = rb.constraints;
        donutActionAsset = new PlayerActionAsset();
        animator = this.GetComponent<Animator>();
        move = donutActionAsset.Player.Move;
        Hurtbox.enabled = true;
    }

    private void Update()
    {
        //Debug.Log("Is Attacking - " + isAttacking);
        donutActionAsset.Player.LightAttack.started += DoLightAttack;
        donutActionAsset.Player.HeavyAttack.started += DoHeavyAttack;
        move = donutActionAsset.Player.Move;
        donutActionAsset.Player.Enable();
    }

    private void OnDisable()
    {
        donutActionAsset.Player.LightAttack.started -= DoLightAttack;
        donutActionAsset.Player.HeavyAttack.started -= DoHeavyAttack;
        donutActionAsset.Player.Disable();
    }

    private void FixedUpdate()
    {
        if (isDashing)
            return;

        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        if (dash != 0 && canDash && forceDirection != Vector3.zero)
            StartCoroutine(Dodge());

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;
        

        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime * 5;
    
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        LookAt();
    }

    private void LookAt()
    {
        if (isDashing)
            return;

        Vector3 direction = rb.velocity;
        direction.y = 0f;
        float smooth = 41f;
        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            this.rb.rotation = Quaternion.Slerp(this.rb.rotation, lookRotation, smooth * Time.deltaTime);
        }
        else
            rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

  
    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false; 
    }

    private void DoLightAttack(InputAction.CallbackContext obj)
    {
        if (canAttack == false)
            return;
        isAttacking = true;
        canAttack = false;
        animator.SetTrigger("light_attack");
        playerSounds.PlayLightAttackSound();
        StartCoroutine(StartAttackCooldown());    
    }

    private IEnumerator StartAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    private void DoHeavyAttack(InputAction.CallbackContext obj)
    {
        animator.SetTrigger("heavy_attack");
        playerSounds.PlayHeavyAttackSound();
    }

    private void StopMovement() {
        movementForce = 0f;
    }

    private void StartMovement() {
        movementForce = 6f;
    }

    private IEnumerator Dodge()
    {
        canDash = false;
        isDashing = true;
        Hurtbox.enabled = false;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.AddForce(forceDirection * dashingPower, ForceMode.VelocityChange);
        playerSounds.PlayDodgeSound();
        dash_ps.Play();
        yield return new WaitForSeconds(dashingTime);
        rb.constraints = originalConstraints;
        isDashing = false;
        Hurtbox.enabled = true;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        dash_ps.Stop();
    }

    public void StartKnockBack(Vector3 pushDirection, float magnitude)
    {
        pushDirection = pushDirection.normalized;
        pushDirection.y = -0.5f;
        rb.AddForce(-pushDirection * knockbackForce * 5 * magnitude, ForceMode.Impulse);
    }
}

