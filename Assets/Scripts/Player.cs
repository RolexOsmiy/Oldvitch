using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    Animator anim;
    public bool grounded = true;
    public float walkSpeed = 4;
    public float sprintSpeed = 8;
    public float rotateSpeed = 200;
    public float jumpPower = 10;
	public float horizontalSpeed = 2.0F;
	RaycastHit hit;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
		float h = horizontalSpeed * Input.GetAxis("Mouse X");
		transform.Rotate(0, h, 0);
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            anim.SetFloat("speed", 0.4f);
        }
        else
        {
            anim.SetFloat("speed", 0);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            anim.SetFloat("speed", 0.8f);
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-Vector3.forward * walkSpeed * Time.deltaTime);
                anim.SetFloat("speed", 0.4f);
            }
        }      

        if (Input.GetKey(KeyCode.A))
        {
			transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
			transform.Translate(-Vector3.left * walkSpeed * Time.deltaTime);

        }
        if (!grounded && GetComponent<Rigidbody>().velocity.y == 0)
        {
            grounded = true;
            anim.SetBool("jump", false);
        }
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, jumpPower, 0f), ForceMode.Impulse);
            grounded = false;
            anim.SetBool("jump", true);
        }
    }
}
    