using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public static PlatformController Instance;

    public string platformTag = "Platform";
    public List<GameObject> platform;

    private void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;

        platform = new List<GameObject>(GameObject.FindGameObjectsWithTag(platformTag));
    }
}
