using UnityEngine;
using UnityEngine.InputSystem; // �VInput System

public class Shooter3D : MonoBehaviour
{
    public Camera cam;                   // ���ݒ�Ȃ玩����MainCamera
    public Transform crosshair;          // 3D�Ə�(��: Crosshair3D)
    public Bullet bulletPrefab;          // �e�v���n�u
    public float spawnForwardOffset = 0.1f; // �Ə����班���O�ɏo��

    [Header("Optional")]
    public Collider shooterCollider;     // ���@�ȂǁA�e�Ɠ��Ă����Ȃ����ˌ���Collider

    void Awake()
    {
        if (!cam) cam = Camera.main;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // ���ˁiSpace�j
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Fire();
        }
    }

    void Fire()
    {
        if (!cam || !crosshair || !bulletPrefab) return;

        // �J�������Ə��̐��m�ȕ���
        Vector3 dir = (crosshair.position - cam.transform.position).normalized;

        // �Ə��ʒu���班���O�ɂ��炵�ăX�|�[��
        Vector3 spawnPos = crosshair.position + dir * spawnForwardOffset;

        Bullet b = Instantiate(bulletPrefab, spawnPos, Quaternion.LookRotation(dir));
        b.Fire(dir);

        // ���ˌ��Ƃ̎��ȏՓ˂𖳌����i�K�v�Ȃ�j
        if (shooterCollider)
        {
            var bulletCol = b.GetComponent<Collider>();
            if (bulletCol) Physics.IgnoreCollision(bulletCol, shooterCollider, true);
        }
    }
}


