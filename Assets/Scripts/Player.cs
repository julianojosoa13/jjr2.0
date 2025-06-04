using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event EventHandler OnInteractableDetected;
    public event EventHandler OnInteractableOutOfRange;

    public static Player Instance {get; private set;}

    private const string ANIM_WALKING = "isWalking";

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnRate = 7f;

    [SerializeField] private Animator animator;
    [SerializeField] private Transform playerMeshTransform;
    [SerializeField] private Transform raycastOriginTransform;

    [SerializeField] private LayerMask interactableLayerMask;


    private Interactable interactedObject;
    private Interactable previousInteractable;
    
    private Vector3 lastInteractDir;


    private void Awake() {
       Instance = this;
    }

    private void Start() {
       HUD.Instance.OnActionButtonPressed += HUD_OnActionButtonPressed;
    }

    private void HUD_OnActionButtonPressed(object sender, EventArgs e) {
        if(interactedObject != null) {
            interactedObject.Interact();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();

        HandleMovement(inputVector);
        HandleAnimation(inputVector);
        HandleInteract(inputVector);
    }

    private void HandleAnimation(Vector2 inputVector)
    {
        if (inputVector != Vector2.zero)
        {
            animator.SetBool(ANIM_WALKING, true);
        }
        else
        {
            animator.SetBool(ANIM_WALKING, false);
        }
    }

    private void HandleMovement(Vector2 inputVector)
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Flatten the camera directions on the XZ plane
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate movement direction based on camera orientation
        Vector3 moveDir = (cameraForward * inputVector.y + cameraRight * inputVector.x).normalized;

        // Rotate the player to face the movement direction
        if (moveDir != Vector3.zero)
        {
            transform.position += moveDir * Time.deltaTime * moveSpeed;
            // playerMeshTransform.LookAt(playerMeshTransform.position + Vector3.Slerp(playerMeshTransform.forward.normalized, moveDir, Time.deltaTime * turnRate));
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            playerMeshTransform.localRotation = Quaternion.Slerp(playerMeshTransform.rotation, targetRotation, Time.deltaTime * turnRate);

        }

        // Move the player
    }

     private void HandleInteract(Vector2 inputVector)
    {

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        float interactDistance = 2f;


        if (Physics.Raycast(raycastOriginTransform.position, raycastOriginTransform.forward, out RaycastHit raycastHit, interactDistance, interactableLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out Interactable interactable))
            {
                if (interactable != interactedObject)
                {
                    SetInteractedObject(interactable);
                    previousInteractable = interactable;
                    OnInteractableDetected?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                SetInteractedObject(null);
            }
        }
        else
        {
            SetInteractedObject(null);
        }

        if(interactedObject == null && previousInteractable != null) {
            previousInteractable = null;
            OnInteractableOutOfRange?.Invoke(this, EventArgs.Empty);
        }
    }

    private void SetInteractedObject(Interactable interactable) {
        this.interactedObject = interactable;
    }
}
