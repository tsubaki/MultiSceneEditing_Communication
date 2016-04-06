using UnityEngine;
using System.Collections;

namespace Style2
{
	[RequireComponent(typeof(ParticleSystem))]
	public class Reciever : MonoBehaviour, IReciever
	{
		public void Log()
		{
			Debug.Log(gameObject.name, gameObject);
			GetComponent<ParticleSystem>().Play();
		}
	}
}