using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public Transform orientation;

    public float horizontalInput;
    public float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public GameObject happyStick;

    public bool canAttack = true;

    public float attackCooldown;

    [SerializeField] AudioSource swipeSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKey("p"))
        {
            SceneManager.LoadScene(1);
        }

        if (canAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StickAttack();
            }
        }
    }


    private void FixedUpdate()
    {
        MyInput();

        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    public void StickAttack()
    {
        canAttack = false;
        Animator anim = happyStick.GetComponent<Animator>();

        anim.SetTrigger("Attack");

        swipeSound.Play();

        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }
}
