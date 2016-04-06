using UnityEngine;
using System.Collections;

namespace Style1
{
	[RequireComponent (typeof(ParticleSystem))]
	public class GameSystemRegister : MonoBehaviour, IReciever
	{
		[SerializeField]
		GameManager gameManager;

		void OnEnable ()
		{
			Debug.LogFormat ("[{0}] register game manager", name);
			gameManager.ping.AddListener (Log);
		}

		void OnDisable ()
		{
			gameManager.ping.RemoveListener (Log);
		}

		public void Log ()
		{
			Debug.Log (gameObject.name);
			GetComponent<ParticleSystem> ().Play ();
		}
	}
}