using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

    public static CheckPoints Instance;

    public List<Transform> checkpoints;
    public Transform startPoint, endPoint;

    void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
    }
}
