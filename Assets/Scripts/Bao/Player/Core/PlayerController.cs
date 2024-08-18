using System.Collections.Generic;
using UnityEngine;

public class PlayerController : StateOwner
{
	private Rigidbody rb;

	protected override void Start()
	{
		base.Start();
		rb = GetComponent<Rigidbody>();
	}

	public void Jump()
	{
		rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
	}
}
