using UnityEngine;
using System.Collections; // Coroutine�p

public class EnemyForward : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float stopZ = -2f; // �G����~����Z���W�i�J�������j

    private Camera mainCamera;
    private bool isStopped = false; // ��~�t���O

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isStopped)
            return;

        // �J�����̒��S�i0,0,0�j��菭���������ɐi��
        Vector3 targetPos = new Vector3(0, transform.position.y, 0);
        Vector3 direction = (targetPos - transform.position).normalized;

        // �������̕␳�iX����������߂ɂ���j
        direction.x *= 0.3f;
        direction.y = 0;

        // �ړ�
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Z���̒�~�ʒu����
        if (transform.position.z >= stopZ)
        {
            // Z����stopZ�ɌŒ�
            transform.position = new Vector3(transform.position.x, transform.position.y, stopZ);

            // ��~�t���O�𗧂Ă�
            isStopped = true;

            // ��~��0.2�b�ŏ���
            StartCoroutine(DestroyAfterDelay(0.2f));
        }

        // X���̕␳�͒�~�O�̂�
        if (!isStopped)
        {
            float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
            float clampedX = Mathf.Clamp(transform.position.x, -cameraWidth * 0.9f, cameraWidth * 0.9f);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }

    // Coroutine�Œx��Destroy
    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
