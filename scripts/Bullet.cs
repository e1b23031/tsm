using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;     // �e�̑���
    public float lifeTime = 5f;   // ���b��ɏ����邩

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // �O����Ăяo���Ēe���΂�����
    public void Fire(Vector3 direction)
    {
        if (rb == null) return;

        // �i�s�����ɑ��x��^����
        rb.linearVelocity = direction.normalized * speed;

        // lifeTime �b��Ɏ����폜
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // ��������������i�K�v�Ȃ炱���œG�ւ̃_���[�W�����j
        Destroy(gameObject);
    }
}
