using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	/// <summary>
	/// 変数
	/// </summary>
	
	//マウス感度
	[SerializeField, Range( 1f, 500f )] float sensitivity = 1f;


	//水平方向回転
	[SerializeField] Transform verticalTransform = null;

	//垂直方向回転
	Transform horizonTransform = null;


	//ボールオブジェクト
	[SerializeField] GameObject teleBall = null;

	//ボールの速度
	[SerializeField, Range( 0f, 50f )] float ballSpeed = 1f;

	//プレイヤースピード
	[SerializeField, Range( 0f, 2f )] float playerSpeed = 0.1f;

	//プレイヤーのジャンプ回数
	int playerJumpNum = 1;

	int masks;

	/// <summary>
	/// スクリプトメイン処理
	/// </summary>

    //スタート
    void Start()
    {
		horizonTransform = transform;
		masks = LayerMask.GetMask( new string[] { "StageLayer" } );
    }

	//アップデート
	void Update()
	{
		if( !GameManager.Instance.isOption )
		{
			//カメラの回転
			CameraRotate();

			//ボール生成
			InstantiateBall();

			if( playerJumpNum < 3 && Input.GetButtonDown( "Jump" ) )
			{
				Vector3 power = Vector3.up + ( transform.forward * 3 );
				power.y = 10f * ( playerJumpNum * 2 );
				GetComponent<Rigidbody>().AddForce( power, ForceMode.Impulse );
				playerJumpNum++;
			}
		}
	}

	//Fixアップデート
	private void FixedUpdate()
	{
		//プレイヤー移動
		PlayerMove();
	}

	/// <summary>
	/// カメラの回転
	/// </summary>
	void CameraRotate()
	{
		//横移動取得
		float xRotation = Input.GetAxis( "Mouse X" ) * sensitivity * Time.deltaTime;
		//縦移動取得
		float yRotation = -( Input.GetAxis( "Mouse Y" ) * sensitivity * Time.deltaTime );

		//垂直回転処理
		float horPlusRot = verticalTransform.transform.eulerAngles.x + yRotation;
		if( verticalTransform.transform.eulerAngles.x <= 90.0f && horPlusRot > 85.0f )
		{
			horPlusRot = 85.0f - horPlusRot;
			verticalTransform.transform.Rotate( horPlusRot, 0, 0 );
		}
		else if( verticalTransform.transform.eulerAngles.x >= 270 && horPlusRot < 275.0f )
		{
			horPlusRot = 275.0f - horPlusRot;
			verticalTransform.transform.Rotate( horPlusRot, 0, 0 );
		}

		verticalTransform.transform.Rotate( yRotation, 0, 0 );

		//print( Vector3.Angle( Vector3.forward, verticalTransform.forward ) );

		//水平回転処理
		horizonTransform.Rotate( 0, xRotation, 0 );
	}

	/// <summary>
	/// プレイヤーの移動
	/// </summary>
	void PlayerMove()
	{
		float sprint = 1f;
		if( Input.GetButton( "Fire3" ) )
		{
			sprint += 2f;
		}
		transform.position += ( transform.forward * Input.GetAxis( "Vertical" ) ) * playerSpeed * sprint;
		transform.position += ( transform.right * Input.GetAxis( "Horizontal" ) ) * playerSpeed;
	}

	//クリック時のボールの生成
	void InstantiateBall()
	{
		if( Input.GetMouseButtonDown( 0 ) )
		{
			////クリック時にボールを生成
			//GameObject newBall = Instantiate( teleBall, verticalTransform.forward + verticalTransform.position, Quaternion.identity );

			////ボールにAddForce
			//newBall.GetComponent<Rigidbody>().AddForce( verticalTransform.forward * ballSpeed, ForceMode.Impulse );

		}
	}
}
