using UnityEngine;
using UnityEngine.InputSystem; // 新Input Systemを使う

public class Crosshair3DController : MonoBehaviour
{
    [Header("Movement (Local Space)")]
    public float moveSpeed = 2f;                 // 矢印キーの移動速度
    public Vector2 limits = new Vector2(0.5f, 0.3f); // 中心からの可動範囲(左右x, 上下y)

    [Header("Depth")]
    public float distanceFromCamera = 3f;        // カメラからの距離（ローカルZ）

    public float initialYOffset = 0f;

    private Camera cam;
    private Vector2 offset; // 中心からのローカルオフセット

    void Awake()
    {
        cam = Camera.main;

        // カメラの子になっている前提で、初期位置を奥(z)に固定
        if (transform.parent == cam.transform)
        {
            offset = new Vector2(0f, initialYOffset);

            transform.localPosition = new Vector3(0f, initialYOffset, distanceFromCamera);
            transform.localRotation = Quaternion.identity;
        }
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        var k = Keyboard.current;
        float x = (k.rightArrowKey.isPressed ? 1f : 0f) - (k.leftArrowKey.isPressed ? 1f : 0f);
        float y = (k.upArrowKey.isPressed ? 1f : 0f) - (k.downArrowKey.isPressed ? 1f : 0f);

        // 入力を反映
        offset += new Vector2(x, y) * moveSpeed * Time.deltaTime;
        offset.x = Mathf.Clamp(offset.x, -limits.x, limits.x);
        offset.y = Mathf.Clamp(offset.y, -limits.y, limits.y);

        // カメラ子オブジェクトのローカル位置を更新
        transform.localPosition = new Vector3(offset.x, offset.y, distanceFromCamera);
        transform.localRotation = Quaternion.identity; // 常に正面向き
    }
}

