using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [Header("Health bar")]
    public Image healthBar;

    [HideInInspector]
    public Enemy info;

    [HideInInspector]
    public int currentHp;

    // only for removing enemy from list
    Enemies enemies;

    // for checkpoints
    CheckPoints checkPoints;
    Transform targetedCheckpoint;
    int checkPointNum = 0;
    Vector3 direction;

    void Start()
    {
        currentHp = info.health;

        enemies = Enemies.Instance;
        checkPoints = CheckPoints.Instance;

        targetedCheckpoint = checkPoints.checkpoints[checkPointNum];

        // find direction
        direction = targetedCheckpoint.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        // destroy if health is less than 0
        if (currentHp <= 0)
        {
            PlayerStats.Instance.GetMoneyForKill();
            Destroy(gameObject);
        }

        // if it is near end point destroy
        if (Vector3.Distance(transform.position, checkPoints.endPoint.position) < 0.1)
            Destroy(gameObject);

        GoToCheckPoint();
    }

    // apply damage on enemy, if enemy have resistance then amount will bi lowered for that percent
    public void ApplyDamage(float amount)
    {
        float dmgToDeal = amount * (1.0f - info.dmgResistance / 100);

        currentHp = (int)(currentHp - dmgToDeal);

        healthBar.fillAmount = currentHp / info.health;
    }

    // determinate next point abd move towards it
    void GoToCheckPoint()
    {
        if (Vector3.Distance(transform.position, targetedCheckpoint.position) < 0.1)
        {
            checkPointNum++;

            if (checkPointNum < checkPoints.checkpoints.Count)
                targetedCheckpoint = checkPoints.checkpoints[checkPointNum];
            else
                targetedCheckpoint = checkPoints.endPoint;

            direction = targetedCheckpoint.position - transform.position;
            direction.Normalize();
        }

        transform.Translate(direction * info.speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        // todo da se izbrise iz liste
        enemies.enemyList.Remove(gameObject);
    }
}
