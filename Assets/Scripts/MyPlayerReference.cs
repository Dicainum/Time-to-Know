using UnityEngine;

public class MyPlayerReference : MonoBehaviour
{
    public static NetworkPlayer myNetworkPlayer { get; private set; }


    private void Awake()
    {
        myNetworkPlayer = gameObject.GetComponent<NetworkPlayer>();
    }
}
