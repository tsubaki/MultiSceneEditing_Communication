using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(UnityEngine.UI.Button))]
public class FindTargetSceneObject : MonoBehaviour
{
	[SerializeField]
	string sceneName, objectPath;

	void Start ()
	{
		SceneManager.sceneLoaded += (scene, type) => {

			if (scene.name == sceneName) {
				StartCoroutine (RegisterObject (scene));
			}
		};
#if UNITY_EDITOR
		if (SceneManager.GetSceneByName (sceneName).isLoaded == true) {
			StartCoroutine (RegisterObject (SceneManager.GetSceneByName (sceneName)));
		}
#endif

	}

	IEnumerator RegisterObject (Scene scene)
	{
		yield return new WaitWhile (() => scene.isLoaded == false);

		var button = GetComponent<UnityEngine.UI.Button> ();
		Debug.LogFormat ("[find] {0} in {1}", objectPath, scene.name);

		foreach (var root in scene.GetRootGameObjects()) {
			if (root.name == objectPath) {

				Debug.LogFormat ("[register] {0} in {1}(root) to {2}", objectPath, scene.name, this.name);

				button.onClick.AddListener (root.GetComponent<ParticleSystem> ().Play);
				break;
			}

			var obj = root.transform.FindChild (objectPath);
			if (obj != null) {

				Debug.LogFormat ("[register] {0} in {1} to {2}", objectPath, scene.name, this.name);

				button.onClick.AddListener (obj.GetComponent<ParticleSystem> ().Play);
				break;
			}
		}
	}
}
