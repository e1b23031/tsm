using UnityEngine;
using UnityEngine.InputSystem; // �VInput System

public class Shooter3D : MonoBehaviour
{
    public Camera cam;                   // �J����
    public Transform crosshair;          // 3D�Ə�
    public Bullet bulletPrefab;          // �e�v���n�u
    public float spawnForwardOffset = 0.1f; // ���ȏՓˉ���̂��߂̃I�t�Z�b�g

    [Header("Time Limit Settings")]
    public float fireDuration = 10f;     // ���Ă鎞�ԁi�b�j
    private float fireEndTime;           // ���Ă�I������

    void Start()
    {
        if (!cam) cam = Camera.main;

        // �Q�[���J�n���� fireDuration �b��܂Ō��Ă�
        fireEndTime = Time.time + fireDuration;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // �������ԓ��������ˉ\
        if (Time.time < fireEndTime)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Fire();
            }
        }
        else
        {
            // �f�o�b�O�p�F������ɃL�[����������ʒm
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Debug.Log("���Ԑ؂�I�������Ă܂���B");
            }
        }
    }

    void Fire()
    {
        if (!cam || !crosshair || !bulletPrefab) return;

        Vector3 dir = (crosshair.position - cam.transform.position).normalized;
        Vector3 spawnPos = crosshair.position + dir * spawnForwardOffset;

        Bullet b = Instantiate(bulletPrefab, spawnPos, Quaternion.LookRotation(dir));
        b.Fire(dir);
    }
}
