using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class AbstractObstacle : MonoBehaviour
{
	protected Rigidbody2D rb;
	
	protected virtual void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;
		
	}

	protected virtual void FixedUpdate()
	{

		rb.AddForce(GravitySystem.Instance.GetCurrentGravityValue());
	}

}
