using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JumpEvent : NetworkManager {

	public override void OnServerConnect(NetworkConnection conn)
	{
		Debug.Log("OnPlayerConnected");
	}
}
