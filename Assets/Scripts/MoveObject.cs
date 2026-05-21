using UnityEngine;
using UnityEngine.InputSystem;

public class MoveObject : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 5f;
    public float rotateSpeed = 90f;

    void Update()
    {
        // WASDキーで移動
        Vector3 move = Vector3.zero;
        if (Keyboard.current.wKey.isPressed) move += Vector3.forward;
        if (Keyboard.current.sKey.isPressed) move += Vector3.back;
        if (Keyboard.current.aKey.isPressed) move += Vector3.left;
        if (Keyboard.current.dKey.isPressed) move += Vector3.right;

        // 移動反映
        transform.Translate(move * moveSpeed * Time.deltaTime);

        // Q/Eキーで回転
        if (Keyboard.current.qKey.isPressed) transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        if (Keyboard.current.eKey.isPressed) transform.Rotate(0,  rotateSpeed * Time.deltaTime, 0);

        
    }
}