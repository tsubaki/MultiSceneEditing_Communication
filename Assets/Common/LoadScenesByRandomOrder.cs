using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections.Generic;

public class LoadScenesByRandomOrder : MonoBehaviour
{
	[SerializeField]
	List<string> sceneNames = new List<string>();

	IEnumerator Start ()
	{
		var newOrderScenes = sceneNames.OrderBy( (i) => Random.Range(0, 10));

		foreach (var sceneName in newOrderScenes) {

			var scene = SceneManager.GetSceneByName(sceneName);
			if( scene.isLoaded  == false ){
				SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
			}

			Debug.LogFormat("[loaded scene]{0}", sceneName);

			yield return new WaitForSeconds(0.5f);
		}
	}
}
