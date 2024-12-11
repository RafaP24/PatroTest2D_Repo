using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Librer�a necesar�a para leer el New Input System
public class NewPlayerController2D : MonoBehaviour
{
    //Referencias privadas generales
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] PlayerInput playerInput;
    Vector2 moveInput; //Variable para referenciar el input de los controladores

    [Header("Movement Parameters")]
    public float speed;

    [Header("Jump Parameters")]
    public float jumpForce;
    [SerializeField] bool isGrounded;










    // Start is called before the first frame update
    void Start()
    {
        //Para autoreferenciar: nombre de variable = GetComponent<tipo de variable>()
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        playerRb.velocity = new Vector3(moveInput.x * speed, playerRb.velocity.y, 0);
    }


    #region Input Methods
    //M�todos que permiten leer el input del New Input System
    //Crearemos un m�todo por cada acci�n

    public void HandleMovement(InputAction.CallbackContext context)
    {
        //Las acciones de tipo VALUE deben almacenarse = ReadValue
        moveInput = context.ReadValue<Vector2>();
    }


    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
       
    }

    #endregion







}
