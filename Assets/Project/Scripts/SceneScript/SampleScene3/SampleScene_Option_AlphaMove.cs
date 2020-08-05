using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SampleNamespace;

public class SampleScene_Option_AlphaMove : OptionMenu
{
	//オプション画面の立ち上げイベント
	public void WakeOption()
	{
		//GameManager.Instance.isOption = true;
	}

	//オプション画面の終了イベント
	public void SleepOption()
	{
		GameManager.Instance.sleepOption = true;
	}

	public void BackTitleOption()
	{
		if( GameManager.Instance.isOption == true )
		{
			UnityEditor.EditorApplication.isPlaying = false;
			GameManager.Instance.isOption = false;
		}
	}
}
