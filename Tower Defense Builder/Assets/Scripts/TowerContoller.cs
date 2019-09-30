using UnityEngine;

public class TowerContoller : MonoBehaviour
{
    [Header("Setup")]
    public GameObject turretHead;
    public Tower tower;
    public GameObject targetedEnemy;

    [HideInInspector]
    public Enemies enemies;

    public float cooldown = 0;

    // Use this for initialization
    void Start()
    {
        enemies = Enemies.Instance;
        PlayerStats.Instance.ManageMoneyPerSec(tower.earningPerSec);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetedEnemy == null)
            FindEnemy();

        LookAtEnemy();

        Fire();
    }

    // shoot at enemy
    void Fire()
    {
        // if cooldown is higher than 0, dont shoot
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            return;
        }

        // if target is not set, dont shoot
        if (targetedEnemy == null)
            return;

        // wait for enemy to initialize
        if (targetedEnemy.GetComponent<EnemyController>().currentHp == 0)
            return;

        Debug.Log(targetedEnemy.GetComponent<EnemyController>().currentHp);

        // apply damage to enemy
        targetedEnemy.GetComponent<EnemyController>().ApplyDamage(tower.damage);

        // set cooldown time till next shoot
        cooldown = 1 / tower.fireRate;

        Debug.Log("Fire");
        Debug.Log(targetedEnemy.GetComponent<EnemyController>().currentHp);
    }

    // look at enemy
    void LookAtEnemy()
    {
        if (targetedEnemy == null)
            return;

        turretHead.transform.LookAt(targetedEnemy.transform);
    }

    // find closest enemy
    void FindEnemy()
    {
        GameObject closestEnemy = null;

        foreach (GameObject e in enemies.enemyList)
        {
            if (closestEnemy == null)
            {
                closestEnemy = e;
                continue;
            }

            if (Vector3.Distance(closestEnemy.transform.position, transform.position) > Vector3.Distance(e.transform.position, transform.position))
            {
                closestEnemy = e;
            }
        }

        targetedEnemy = closestEnemy;
    }

    void OnDestroy()
    {
        PlayerStats.Instance.ManageMoneyPerSec(-tower.earningPerSec);
    }
}
