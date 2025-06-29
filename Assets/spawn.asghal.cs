using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // پریفب‌هایی که می‌خواهید اسپاون کنید
    public GameObject[] prefabs;

    public GameObject[] spawnpont;


    // آبجکتی که اطراف آن اسپاون انجام می‌شود
    public Transform spawnCenter;

    // تعداد آبجکت‌هایی که می‌خواهید اسپاون کنید
    public int numberOfObjects = 5;

    // شعاع اطراف آبجکت مرکزی که آبجکت‌ها در آن اسپاون می‌شوند
    public float spawnRadius = 5f;

    void Start()
    {
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // انتخاب تصادفی یک پریفب از لیست
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

            GameObject spawn = spawnpont[Random.Range(0, spawnpont.Length)];


            // موقعیت تصادفی در شعاع اطراف آبجکت مرکزی
            //Vector3 randomPosition = spawnCenter.position + (Vector3)(Random.insideUnitCircle * spawnRadius);

            // اسپاون کردن پریفب
            Instantiate(prefab, spawn.transform.position, spawn.transform.rotation);
        }
    }
}
