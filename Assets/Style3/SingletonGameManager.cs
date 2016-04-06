using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Style3
{
	public class SingletonGameManager : MonoBehaviour
	{
		// singleton
		private static SingletonGameManager instance = null;

		public static SingletonGameManager Instance { 
			get { 
				if (instance == null) {
					instance = FindObjectOfType<SingletonGameManager> ();
				}
				return instance;
			}
		}

		void Awake ()
		{
			if (Instance != this) {
				Destroy (gameObject);
			}
		}


		public List<IReciever> recievers = new List<IReciever> ();

		public void OnClik ()
		{
			foreach (var reciever in recievers) {
				reciever.Log ();
			}
		}
	}
}
