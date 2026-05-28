using UnityEngine;
using UnityEngine.InputSystem;

public class MoveObject : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;   // 回転の滑らかさ（大きいほど速い）

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
        }

        // 目標位置へ移動
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        // ★追加: 目標方向に滑らかに回転
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0f;
        if (direction.sqrMagnitude > 0.001f)   // ほぼ到着していたら回転しない
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );
        }
    }
}