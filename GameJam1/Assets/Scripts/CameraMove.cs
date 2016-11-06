using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	/*public Transform ThirdCameraPos;
	public Transform FirstCameraPos;
	public Transform PlayerPos;


	private Transform tr;
	private Rigidbody rb;
	private Transform CameraPos;

	public enum CameraState
	{
		ThirdPerson,
		FirstPerson,

	}
	private CameraState m_state;
	public CameraState state { get { return m_state; } }*/

	[SerializeField]
	private Transform target = null;
	[SerializeField]
	private float distance = 3.0f;
	[SerializeField]
	private float height = 1.0f;
	[SerializeField]
	private float damping = 5.0f;
	[SerializeField]
	private bool smoothRotation = true;
	[SerializeField]
	private float rotationDamping = 10.0f;

	[SerializeField]
	private Vector3 targetLookAtOffset; // allows offsetting of camera lookAt, very useful for low bumper heights

	[SerializeField]
	private float bumperDistanceCheck = 2.5f; // length of bumper ray
	[SerializeField]
	private float bumperCameraHeight = 1.0f; // adjust camera height while bumping
	[SerializeField]
	private Vector3 bumperRayOffset; // allows offset of the bumper ray from target origin

	/*void Awake()
	{
		//camera.transform.parent = target;
	}

	void Start ()
	{
		tr = GetComponent<Transform>();
		m_state = CameraState.ThirdPerson;
		CameraPos = ThirdCameraPos;
	}

	void ToFirst ()
	{
		m_state = CameraState.FirstPerson;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			switch (m_state)
			{
				case CameraState.ThirdPerson:
					CameraPos = FirstCameraPos;
					Invoke("ToFirst", 3.0f * Time.deltaTime);
					break;

				case CameraState.FirstPerson:
					CameraPos = ThirdCameraPos;
					m_state = CameraState.ThirdPerson;
					break;

			}
		}
		
		switch (m_state)
		{
			case CameraState.ThirdPerson:
				tr.position = Vector3.Lerp(tr.position, CameraPos.position, 3.0f * Time.deltaTime);
				tr.rotation = Quaternion.Lerp(tr.rotation, CameraPos.rotation, 3.0f * Time.deltaTime);
				tr.LookAt(PlayerPos);
				break;

			case CameraState.FirstPerson:
				tr.position = CameraPos.position;
				tr.rotation = CameraPos.rotation;
				break;
		}
		
	}*/

	void FixedUpdate()
	{
		Vector3 wantedPosition = target.TransformPoint(0.0f, height, -distance);

		// check to see if there is anything behind the target
		RaycastHit hit;
		Vector3 back = target.transform.TransformDirection(-Vector3.forward);

		// cast the bumper ray out from rear and check to see if there is anything behind
		if (Physics.Raycast(target.TransformPoint(bumperRayOffset), back, out hit, bumperDistanceCheck)
			&& hit.collider.tag != "Player") // ignore ray-casts that hit the user. DR
		{
			// clamp wanted position to hit position
			wantedPosition.x = hit.point.x;
			wantedPosition.z = hit.point.z;
			wantedPosition.y = Mathf.Lerp(hit.point.y + bumperCameraHeight, wantedPosition.y, Time.deltaTime * damping);
		}

		transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

		Vector3 lookPosition = target.TransformPoint(targetLookAtOffset);

		if (smoothRotation)
		{
			Quaternion wantedRotation = Quaternion.LookRotation(lookPosition - transform.position, target.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		else
		{
			transform.rotation = Quaternion.LookRotation(lookPosition - transform.position, target.up);
		}
	}
}
