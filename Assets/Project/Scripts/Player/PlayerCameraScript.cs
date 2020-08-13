using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
	int masks;

	[SerializeField] Transform ball;

    // Start is called before the first frame update
    void Start()
    {
		masks = LayerMask.GetMask( new string[] { "StageLayer" } );
	}

    // Update is called once per frame
    void Update()
    {
        //IsThrowing();
        Thrower();
	}

    void Thrower()
    {
        RaycastHit hit = new RaycastHit();
        Vector3 hitPosition = Vector3.zero;

        if (Input.GetMouseButton(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, masks))
            {
                Vector3 hokanSize = GetComponent<Collider>().bounds.size;
                //ball.position = hit.point * ( hit.normal * GetComponent<Collider>().bounds.size.y );
                hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
        }
    }

	void IsThrowing()
	{
		RaycastHit hit = new RaycastHit();
		Vector3 hitPosition = Vector3.zero;

		//レイを撃つ
		ShootRaycast( hit );
		//ヒットした面を取得
		GetHitSide( hit, out hitPosition );
		//テレポートする座標を指定
		TeleportPosition( hit );
	}

	//レイを撃ち、RaycastHitへ保存
	void ShootRaycast( RaycastHit hit )
	{
		if( Input.GetMouseButton( 0 ) )
		{
			Ray ray = new Ray( transform.position, transform.forward );

			if( Physics.Raycast( ray, out hit, Mathf.Infinity, masks ) )
			{
				ball.position = hit.point;
				hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
			}
			Debug.DrawRay( ray.origin, ray.direction * 50, Color.red );
		}
	}

	//該当オブジェクトに問い合わせ、当たった面(向き)をもらう
	int GetHitSide( RaycastHit hit, out Vector3 hitPosition )
	{
		int hitSide = hit.transform.GetComponent<TeleportObjectScript>().HitSide( hit.point );

		hitPosition = hit.point;
		return hitSide;
	}
	
	//テレポートする座標の決定
	void TeleportPosition( RaycastHit hit )
	{

	}
}
