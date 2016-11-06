using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
	public float walkSpeed;
	public float runSpeed;
	public float rotateSpeed;
	public float jumpHeight;
    public bool kill=false;

    public Transform tr;
	public Transform head;

	private bool m_jumping = false;
	private Rigidbody rb;
	private Animator anim;

    public static bool running;

	void Start ()
	{
		tr = GetComponent<Transform>();
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		//Cursor.visible = false;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Terrain")
		{
			m_jumping = false;
		}
 
    }

	void FixedUpdate ()
	{
        //Debug.Log(tr.position);
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		if (h == 0.0f && v == 0.0f)
		{
			anim.CrossFade("Take 001", 0.3f, -1, 0.0f);
		}

		if (m_jumping == false && Input.GetKey(KeyCode.Space))
		{
			rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
			m_jumping = true;
		}

		Vector3 velocity = new Vector3(h, 0.0f, v);
		velocity = tr.TransformDirection(velocity);
		if (Input.GetKey(KeyCode.LeftShift))
		{
			anim.speed = 1.5f;
			tr.localPosition += velocity * runSpeed * Time.fixedDeltaTime;
            running = true;
        }
		else
		{
			anim.speed = 1.0f;
			tr.localPosition += velocity * walkSpeed * Time.fixedDeltaTime;
            running = false;
        }
		
		tr.Rotate(0.0f, Input.GetAxis("Mouse X") * rotateSpeed, 0.0f);
		head.Rotate(-Input.GetAxis("Mouse Y") * rotateSpeed, 0.0f, 0.0f);
	}
}
