using UnityEngine;
using UnityEngine.InputSystem; // �VInput System���g��

public class Crosshair3DController : MonoBehaviour
{
    [Header("Movement (Local Space)")]
    public float moveSpeed = 2f;                 // ���L�[�̈ړ����x
    public Vector2 limits = new Vector2(0.5f, 0.3f); // ���S����̉��͈�(���Ex, �㉺y)

    [Header("Depth")]
    public float distanceFromCamera = 3f;        // �J��������̋����i���[�J��Z�j

    public float initialYOffset = 0f;

    private Camera cam;
    private Vector2 offset; // ���S����̃��[�J���I�t�Z�b�g

    void Awake()
    {
        cam = Camera.main;

        // �J�����̎q�ɂȂ��Ă���O��ŁA�����ʒu����(z)�ɌŒ�
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

        // ���͂𔽉f
        offset += new Vector2(x, y) * moveSpeed * Time.deltaTime;
        offset.x = Mathf.Clamp(offset.x, -limits.x, limits.x);
        offset.y = Mathf.Clamp(offset.y, -limits.y, limits.y);

        // �J�����q�I�u�W�F�N�g�̃��[�J���ʒu���X�V
        transform.localPosition = new Vector3(offset.x, offset.y, distanceFromCamera);
        transform.localRotation = Quaternion.identity; // ��ɐ��ʌ���
    }
}

