using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody rb;

    private Animator animator;

    public float moveSpeed;

    public int upForce;
    private bool isGround;

    void Start()
    {
        TryGetComponent(out rb);

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        Move();
        Attack();

    }

    void FixedUpdate()
    {

    }

    private void Move()
    {

        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂�
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);


        // �L�[���͂ɂ��ړ����������܂��Ă���ꍇ�ɂ́A�L�����N�^�[�̌�����i�s�����ɍ��킹��
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        if (Input.GetKeyDown("space") && isGround)
        {
            rb.AddForce(new Vector3(0, upForce, 0));
            animator.SetBool("Jumping", true);
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F) && isGround == true)
        {
            animator.SetBool("NormalAttacking", true);
        }
        else
        {
            animator.SetBool("NormalAttacking",false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ground")
        {
            isGround = true;
            animator.SetBool("Jumping", false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ground")
        {
            isGround = false;
        }
    }
}