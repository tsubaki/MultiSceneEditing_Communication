using UnityEngine;
using System.Collections;

namespace Style3
{
	[RequireComponent(typeof(ParticleSystem))]
	public class RegisterStaticGameManager : MonoBehaviour, IReciever
	{
		void OnEnable ()
		{
			SingletonGameManager.Instance.recievers.Add (this);
		}

		void OnDisable ()
		{
			SingletonGameManager.Instance.recievers.Remove (this);
		}

		#region IReciever implementation

		public void Log ()
		{
			Debug.Log (gameObject.name, this);
			GetComponent<ParticleSystem>().Play();
		}

		#endregion
	}
}
