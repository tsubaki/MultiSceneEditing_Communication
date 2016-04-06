using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Style2
{
	public class GameManager : MonoBehaviour
	{
		List<IReciever> recievers = new List<IReciever> ();

		public void Start ()
		{
			// register event at load UI scene.
			SceneManager.sceneLoaded += delegate(Scene scene, LoadSceneMode mode) {
				if (scene.name == "2-2 UI") {
					StartCoroutine (UISceneLoadingFlow (scene));
				}

				if (scene.name == "2-3 Demo" || scene.name == "2-4 Demo") {
					StartCoroutine (DemoSceneLoadingFlow (scene));
				}

			};

#if UNITY_EDITOR
			// if you in multi scene editing
			if (SceneManager.GetSceneByName ("2-2 UI").isLoaded) {
				StartCoroutine (UISceneLoadingFlow (SceneManager.GetSceneByName ("2-2 UI")));
			}

			if (SceneManager.GetSceneByName ("2-3 Demo").isLoaded) {
				StartCoroutine (UISceneLoadingFlow (SceneManager.GetSceneByName ("2-3 Demo")));
			}
			if (SceneManager.GetSceneByName ("2-4 UI").isLoaded) {
				StartCoroutine (UISceneLoadingFlow (SceneManager.GetSceneByName ("2-4 Demo")));
			}
#endif
		}

		IEnumerator UISceneLoadingFlow (Scene scene)
		{
			// wait for load
			yield return new WaitWhile (() => scene.isLoaded == false);

			Debug.Log ("[register]button action");

			// find button and register events.
			foreach (var obj in scene.GetRootGameObjects()) {
				var button = obj.transform.FindChild ("Button");
				if (button != null) {

					button.GetComponent<UnityEngine.UI.Button> ().onClick.AddListener (OnClick);
					break;
				}
			}
		}

		IEnumerator DemoSceneLoadingFlow (Scene scene)
		{
			yield return new WaitWhile (() => scene.isLoaded == false);

			Debug.Log ("[find]reciever");

			// find irecievers and registration
			foreach (var obj in scene.GetRootGameObjects()) {
				recievers.AddRange (obj.transform.GetComponentsInChildren<IReciever> ());
			}
		}

		public void OnClick ()
		{
			foreach (var reciever in recievers) {
				reciever.Log ();
			}
		}
	}
}
