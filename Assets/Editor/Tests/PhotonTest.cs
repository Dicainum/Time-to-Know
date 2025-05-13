using UnityEditor;
using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;

public static class PhotonTestMenu
{
    [MenuItem("AutoTests/Photon Test")]
    public static void RunPhotonTest()
    {
        PhotonView[] photonViews = Object.FindObjectsOfType<PhotonView>();
        Dictionary<int, GameObject> seenIDs = new Dictionary<int, GameObject>();
        bool hasDuplicates = false;

        foreach (PhotonView pv in photonViews)
        {
            int id = pv.ViewID;

            if (seenIDs.ContainsKey(id))
            {
                Debug.LogError($"Duplicate PhotonView ID found: {id} on '{pv.gameObject.name}' and '{seenIDs[id].name}'");
                hasDuplicates = true;
            }
            else
            {
                seenIDs[id] = pv.gameObject;
            }
        }

        if (!hasDuplicates)
        {
            Debug.Log("All PhotonView IDs are unique.");
        }
    }
}