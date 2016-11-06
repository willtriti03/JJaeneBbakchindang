using UnityEngine;
using System.Collections;

public class WaterMove : MonoBehaviour
{
	public float scrollSpeed;
	public float playerSlow;

	private Material mt;

	void Start ()
	{
		mt = GetComponent<Renderer>().material;
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Player")
		{
			PlayerControl player = col.gameObject.GetComponent<PlayerControl>();
			player.walkSpeed -= playerSlow;
			player.runSpeed -= playerSlow;
		}
	}
	void OnTriggerExit (Collider col)
	{
		if (col.tag == "Player")
		{
			PlayerControl player = col.gameObject.GetComponent<PlayerControl>();
			player.walkSpeed += playerSlow;
			player.runSpeed += playerSlow;
		}
	}

	void Update ()
	{
		mt.mainTextureOffset = new Vector2(mt.mainTextureOffset.x + scrollSpeed * Time.deltaTime, 0.0f);
	}
}
