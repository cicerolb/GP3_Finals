using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Player Controls
    [SerializeField] GameObject playerCamera;
    [SerializeField]
    [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] public bool cursorLock = true;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] public float speed = 6.0f;
    [SerializeField] public float walkSpeed = 6.0f;
    [SerializeField] public float sprintSpeed = 12.0f;
    [SerializeField]
    [Range(0.0f, 0.5f)] float moveSmoothTime = 0.0f;
    [SerializeField] float gravity = -30f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    public float jumpHeight = 6f;
    float velocityY;
    bool isGrounded;

    float cameraCap;
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;

    CharacterController controller;
    Vector2 currentDir;
    Vector2 currentDirVelocity;
    Vector3 velocity;



    // booleans
    public bool isMoving;
    public bool canMove = true;
    public bool canLook = true;
    public bool canSprint = true;
    public bool isSprinting = false;
    public bool dialogueActive = false;


    [SerializeField] private GameObject footstep;
    [SerializeField] private GameObject dialogue;

    [SerializeField] AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        controller = GetComponent<CharacterController>();
        
        playerCamera = GameObject.FindGameObjectWithTag("Player Camera");
        audioManager = GameObject.Find("SceneAudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }


        if (canMove)
        {
            UpdateMouse();
            UpdateMove();
            cursorLock = true;
        }

        if (canMove == false)
        {
            footstep.SetActive(false);
            isMoving = false;
            cursorLock = false;
        }
        else
        {
            footstep.SetActive(true);
            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (canSprint)
            {
                isSprinting = true;
            }
            else
            {
                isSprinting = false;
            }

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (canSprint)
            {
                isSprinting = false;
            }
        }

        if (isSprinting)
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        if (dialogueActive)
        {
            speed = 0f;
        }

    }

    void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
        cameraCap -= currentMouseDelta.y * mouseSensitivity;
        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);
        playerCamera.transform.localEulerAngles = Vector3.right * cameraCap;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        velocityY += gravity * 2f * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (isGrounded! && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }

        //Footstep audio plays when player walks -- 
        if (currentDir.magnitude > 0.1f)
        {
            dialogue = GameObject.FindGameObjectWithTag("Dialogue");



            if (dialogue == null)
            {
                footstep.SetActive(true);
                isMoving = true;
                canSprint = true;
                if (audioManager != null)
                {
                    audioManager.enemyFootSteps = true;
                }



            }
            else
            {
                footstep.SetActive(false);
                isMoving = false;
                canSprint = false;
                StartCoroutine(StopEnemyFootStepsAudio());
            }



        }
        else
        {
            footstep.SetActive(false);
            isMoving = false;
            StartCoroutine(StopEnemyFootStepsAudio());
        }

    }

    IEnumerator StopEnemyFootStepsAudio()
    {
        if (audioManager != null)
        {
            yield return new WaitForSeconds(0.5f);
            audioManager.enemyFootSteps = false;
        }

    }

}