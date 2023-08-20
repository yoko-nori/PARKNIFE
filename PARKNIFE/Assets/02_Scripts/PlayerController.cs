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

        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);


        // キー入力により移動方向が決まっている場合には、キャラクターの向きを進行方向に合わせる
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