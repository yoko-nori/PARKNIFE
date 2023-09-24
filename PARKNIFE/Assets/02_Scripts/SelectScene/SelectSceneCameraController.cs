using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSceneCameraController : MonoBehaviour
{
    //��{�ϐ�
    public GameObject player;
    public GameObject mainCamera;
    public float rotate_speed;
    private Vector3 ca_offset;

    //���_�̐����̂��߂̕ϐ�
    private const float ANGLE_LIMIT_UP = 60f;
    private const float ANGLE_LIMIT_DOWN = -60f;

    void Start()
    {
        mainCamera = Camera.main.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");

        //�J������]���S�̃I�t�Z�b�g�l��ݒ�
        ca_offset = new Vector3(0.0f, 1.2f, 0.0f);
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotateCmaeraAngle();
        }

        //�J�����̉�]���S�̐ݒ�
        transform.position = player.transform.position + ca_offset;

        //���_����
        float angle_x = 180f <= transform.eulerAngles.x ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angle_x, ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
    private void rotateCmaeraAngle()
    {
        Vector3 angle = new Vector3(
            Input.GetAxis("Mouse X") * rotate_speed,
            Input.GetAxis("Mouse Y") * rotate_speed,
            0
        );
        transform.eulerAngles += new Vector3(angle.y, angle.x);
    }
}
