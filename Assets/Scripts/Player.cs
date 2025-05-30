using UnityEngine;

public class Player : MonoBehaviour
{
    private const string ANIM_WALKING = "isWalking";
   
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnRate = 7f;

    [SerializeField] private Animator animator;


    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();

        HandleMovement(inputVector);
        HandleAnimation(inputVector);
    }

    private void HandleAnimation(Vector2 inputVector) {
        if(inputVector != Vector2.zero) {
            animator.SetBool(ANIM_WALKING, true);
        } else {
            animator.SetBool(ANIM_WALKING, false);
        }
    }

    private void HandleMovement(Vector2 inputVector) {
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
            transform.LookAt(transform.position + Vector3.Slerp(transform.forward.normalized, moveDir, Time.deltaTime * turnRate));
        }

        // Move the player
        transform.position += moveDir * Time.deltaTime * moveSpeed;
    }
}
