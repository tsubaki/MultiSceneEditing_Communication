using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Style3
{
	public class RegisterButtonEvent : MonoBehaviour
	{
		[SerializeField]
		Button button;

		// in Awake does not work
		void Start ()
		{
			button.onClick.AddListener( SingletonGameManager.Instance.OnClik );
		}
	}
}