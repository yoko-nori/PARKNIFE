using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScenePlayerController : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody rb;

    private Animator animator;

    public float moveSpeed;

    public bool player_state = true;

    void Start()
    {
        TryGetComponent(out rb);

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        if(player_state == true)
        {
            Move();
        }
        else if(player_state == false)
        {
            Debug.Log("SelectScene");
        }

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
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }
}
