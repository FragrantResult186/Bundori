using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("AI設定")]
    public Transform player;        // InspectorでPlayerオブジェクトをセット
    public float moveSpeed = 3f;
    public float rotateSpeed = 5f;
    public float attackRange = 1.5f;    // この距離以内で攻撃
    public float attackInterval = 1f;   // 攻撃間隔（秒）

    private float attackTimer = 0f;

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;
        float distance = direction.magnitude;

        // プレイヤーの方向に回転
        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );
        }

        if (distance > attackRange)
        {
            // 攻撃範囲外 → 近づく
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }
        else
        {
            // 攻撃範囲内 → 攻撃
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackInterval)
            {
                attackTimer = 0f;
                Attack();
            }
        }
    }

    void Attack()
    {
        Debug.Log("攻撃！");
        // ここにダメージ処理などを追加
        // 例: player.GetComponent<PlayerHealth>().TakeDamage(10);
    }
}