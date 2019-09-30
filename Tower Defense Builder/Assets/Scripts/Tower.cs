using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tower {

    [Header("Setup")]
    public GameObject turretPrefab;
    public GameObject turretImage;
    public Sprite img;
    public int level;
    public int cost;
    public float fireRate;
    public float damage;
    public int rotationSpeed;
    public int earningPerSec;
}
