using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKnifeController: MonoBehaviour
{
    public GameObject Knife10;
    public GameObject Knife30;
    public AudioClip sound;
    public float speed;
    int state = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (state == 1)
            {
                GameObject shell = Instantiate(Knife10, transform.position, Quaternion.Euler(90, transform.root.eulerAngles.y + 90, 0));
                Rigidbody shellRb = shell.GetComponent<Rigidbody>();
                shellRb.AddForce(transform.forward * speed);
                AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
                Debug.Log("10ダメージ");
            }
            else if (state == 2)
            {
                GameObject shell = Instantiate(Knife30, transform.position, Quaternion.Euler(90, transform.root.eulerAngles.y + 90, 0));
                Rigidbody shellRb = shell.GetComponent<Rigidbody>();
                shellRb.AddForce(transform.forward * speed);
                AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
                state = 1;
                Debug.Log("30ダメージ");
            }
        }
        if (Input.GetKey("space"))
        {
            state = 2;
        }
    }
}