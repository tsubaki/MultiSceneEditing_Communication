using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplayLog : MonoBehaviour
{
	LinkedList<string> messageList = new LinkedList<string> ();

	[SerializeField]
	int max = 15;


	void Start ()
	{
		Application.logMessageReceived += (condition, stackTrace, type) => {
			if (messageList.Count > max) {
				messageList.RemoveFirst ();
			}

			messageList.AddLast (condition);
		};
	}

	void OnGUI ()
	{
		foreach (var message in messageList) {
			GUILayout.Label (message);
		}
	}
}
