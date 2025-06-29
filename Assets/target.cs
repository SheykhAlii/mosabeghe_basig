using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public Transform target; // شیء هدف که تانک به سمت آن حرکت می‌کند
    public float speed = 5f; // سرعت حرکت تانک

    void Update()
    {
        if (target != null)
        {
            // جهت حرکت به سمت هدف
            Vector3 direction = (target.position - transform.position).normalized;

            // حرکت تانک
            transform.position += direction * speed * Time.deltaTime;

            // چرخش تانک به سمت هدف
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }
    }
}
