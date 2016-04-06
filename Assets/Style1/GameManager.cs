using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace Style1
{
	[CreateAssetMenu ()]
	public class GameManager : ScriptableObject
	{
		public  UnityEvent ping = new UnityEvent ();

		public void Ping ()
		{
			ping.Invoke ();
		}
	}
}