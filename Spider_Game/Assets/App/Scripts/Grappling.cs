using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
	[SerializeField] private bool isFixedDirection;
	[SerializeField] private Vector2 direction;
	[SerializeField] private TargetJoint2D tj2d;
	[SerializeField] private LineRenderer line;
	[SerializeField] private Animator animator;

	private GameManager gameManager;

	// Start is called before the first frame update
	void Start()
	{
		tj2d = GetComponent<TargetJoint2D>();
		gameManager = FindObjectOfType<GameManager>();

		Application.targetFrameRate = 60;

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GrappleOn();
		}
		if (Input.GetMouseButtonUp(0))
		{
			GrappleOff();
		}

		line.SetPosition(0, transform.position);
		line.SetPosition(1, tj2d.target);

	}

	private void GrappleOn()
	{
		animator.SetBool("IsGrappled", true);

		tj2d.enabled = true;
		line.enabled = true;

		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector2 origin = new Vector2(transform.position.x, transform.position.y + 1f);

		Vector2 pos = mousePos - origin;

		RaycastHit2D hit = isFixedDirection ? Physics2D.Raycast(origin, direction) : Physics2D.Raycast(origin, pos);

		if (hit.collider != null)
		{
			tj2d.target = hit.point;
		}

	}

	private void GrappleOff()
	{
		animator.SetBool("IsGrappled", false);
		tj2d.enabled = false;
		line.enabled = false;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Obstacle"))
		{
			gameManager.GameOver();
		}

	}


}
