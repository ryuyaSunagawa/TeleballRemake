using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SampleNamespace;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	[SerializeField] bool _isOption = false;
	//オプション画面かどうか
	public bool isOption
	{
		set {
			_isOption = value;
		}
		get {
			return _isOption;
		}
	}

	/// <summary>
	/// ゲームへ戻るボタン専用Boolean
	/// </summary>
	[SerializeField] bool _sleepOption = false;
	public bool sleepOption
	{
		set {
			_sleepOption = value;
		}
		get {
			return _sleepOption;
		}
	}

	private void Update()
	{
		Manage_OptionMenu();
		Manage_MouseCursor();
	}

	public void Test()
	{
		print( "ahan" );
	}

	//オプションメニューの管理関数
	void Manage_OptionMenu()
	{
		if( !isOption && Input.GetButtonDown( "Option" ) )
		{
			isOption = true;
			Time.timeScale = 0f;

			//カーソルロックの解除
			Manage_MouseCursor();
		}
		else if( isOption && ( Input.GetButtonDown( "Option" ) || sleepOption ) )
		{
			isOption = false;
			Time.timeScale = 1f;
			sleepOption = false;

			//カーソルのロック
			Manage_MouseCursor();
			print( "OK" );
		}
	}

	//マウスカーソルの管理
	void Manage_MouseCursor()
	{
		//オプション外
		if( !isOption )
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		//オプション内
		else if( isOption )
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
	
}