using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public GameObject tankPrefab; // پیش‌ساخته‌ی تانک
    public Transform pointA; // نقطه شروع اسپاون
    public Transform pointB; // نقطه پایان اسپاون
    public float spawnInterval = 4f; // فاصله زمانی بین اسپاون‌ها

    private float timer;


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {

            SpawnTank();
            timer = 0f; // ریست کردن تایمر
        }
    }

    void SpawnTank()
    {
        // محاسبه موقعیت تصادفی بین نقطه A و B
        Vector3 spawnPosition = Vector3.Lerp(pointA.position, pointB.position, Random.value);

        // اسپاون تانک در موقعیت محاسبه شده
        Instantiate(tankPrefab, spawnPosition, Quaternion.identity);
    }
}
