using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SampleNamespace;

public class Sample_UIAlpha : OptionMenu
{
	//自分のイメージ内カラークラス
	[SerializeField] Image myImage = null;
	[SerializeField] Text myText = null;

	[SerializeField, Range( 0, 255 ), Header( "透明値の上限" ) ] float alphaRange = 170f;
	[SerializeField, Range( 0, 10 ), Header( "透明化の速度" ) ] int alphaSpeed = 1;

	int mode;

	AhanE ahanenum;

	private void Start()
	{
		if( gameObject.tag == "UI_Image" )
		{
			ahanenum = AhanE.Image;

			Color color = myImage.color;
			color.a = alphaLowLimit;

			myImage.color = color;
		} else if( gameObject.tag == "UI_Text" )
		{
			ahanenum = AhanE.Text;

			Color color = myText.color;
			color.a = alphaLowLimit;

			myText.color = color;
		}
		
	}

	private void Update()
	{
		Mainpanel_AlphaMoving();
	}

	/// <summary>
	/// メインパネルのアルファ値を変える(実験的)
	/// </summary>
	void Mainpanel_AlphaMoving()
	{
		//オプション画面に入った場合
		if( optionAlphavar < alphaRange && GameManager.Instance.isOption )
		{
			optionAlphavar += ( float )alphaSpeed;

			if( ahanenum == AhanE.Image )
			{
				Color color = myImage.color;
				color.a = optionAlphavar / alphaUpLimit;

				myImage.color = color;
			}
			else if( ahanenum == AhanE.Text )
			{
				Color color = myText.color;
				color.a = optionAlphavar / alphaUpLimit;

				myText.color = color;
			}
		}
		//オプションを抜けるとき
		else if( optionAlphavar > alphaLowLimit && !GameManager.Instance.isOption )
		{
			optionAlphavar -= ( float )alphaSpeed;

			if( ahanenum == AhanE.Image )
			{
				Color color = myImage.color;
				color.a = optionAlphavar / alphaUpLimit;

				myImage.color = color;
			}
			else if( ahanenum == AhanE.Text )
			{
				Color color = myText.color;
				color.a = optionAlphavar / alphaUpLimit;

				myText.color = color;
			}
		}
	}

	/// <summary>
	/// アルファの値を変更する関数
	/// </summary>
	void ChangeAlpha()
	{
	}
}
