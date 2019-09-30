using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    public static Enemies Instance;

    public List<Enemy> enemies;

    public List<GameObject> enemyList;

	void Awake () {
        if (Instance != null)
            return;

        Instance = this;

        enemyList = new List<GameObject>();
	}
	
}
