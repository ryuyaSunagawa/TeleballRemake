using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObjectScript : MonoBehaviour
{
	[SerializeField] Transform ball = null;
	[SerializeField] Transform ball2 = null;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate( new Vector3( -4 * Time.deltaTime, 0f, 0f ) );
		ball.Translate( new Vector3( -4 * Time.deltaTime, 0f, 0f ) );
		print( "wp: " + transform.position + ", lp: " + transform.localPosition +
			   ", ballwp: " + ball.position + ", balltomelp: " + transform.InverseTransformPoint( ball.position ) +
			   ", ball2wp: " + ball2.position + ", ball2lp: " + ball2.localPosition );
    }

	public int HitSide( Vector3 hitPosition )
	{
		Vector3 ahan = hitPosition - transform.position;
		
		return 0;
	}
}
