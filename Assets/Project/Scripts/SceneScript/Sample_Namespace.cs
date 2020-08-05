using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleNamespace
{
	public enum AhanE
	{
		Image,
		Text,
	}

	public class SampleClass
	{
		public const float sampleSpeed = 2f;
	}

	public class OptionMenu : MonoBehaviour
	{
		public static float optionAlphavar = 0f;
		public const float alphaUpLimit = 255f;
		public const float alphaLowLimit = 0f;
	}
}