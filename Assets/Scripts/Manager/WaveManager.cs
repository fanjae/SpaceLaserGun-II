using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Planet Prefabs")]
    [SerializeField] private GameObject[] planetPrefabs; // 스폰할 행성 프리팹 배열

    [Header("Spawn Range")]
    [SerializeField] private Vector2 xRange = new Vector2(-15f, 15f);
    [SerializeField] private Vector2 yRange = new Vector2(5f, 10f);
    [SerializeField] private Vector2 zRange = new Vector2(20f, 30f);

    [Header("Target")]
    [SerializeField] private Transform targetPoint; // 행성이 이동할 목표 지점

    [Header("Wave Settings")]
    [SerializeField] private int[] planetCountsPerWave; // 웨이브 별 행성 수
    [SerializeField] private float spawnInterval = 0.5f; 
    [SerializeField] private float waveDelay = 3f;

    private void Start()
    {
        // 웨이브 코루틴 실행
        StartCoroutine(WaveRoutine());
    }

    private IEnumerator WaveRoutine()
    {
        // 미리 정해둔 웨이브 만큼 실행
        for (int waveIndex = 0; waveIndex < planetCountsPerWave.Length; waveIndex++)
        {
            int monsterCount = planetCountsPerWave[waveIndex];

            for (int i = 0; i < monsterCount; i++)
            {
                SpawnPlanet();

                yield return new WaitForSeconds(spawnInterval);
            }

            yield return new WaitForSeconds(waveDelay);
        }
    }

    // 행성 프리팹 소환
    private void SpawnPlanet()
    {
        if (planetPrefabs == null || planetPrefabs.Length == 0)
            return;

        // 프리팹
        GameObject prefab = planetPrefabs[Random.Range(0, planetPrefabs.Length)];

        Vector3 spawnPosition = new Vector3(
            Random.Range(xRange.x, xRange.y),
            Random.Range(yRange.x, yRange.y),
            Random.Range(zRange.x, zRange.y)
        );

        // 프리팹을 랜덤 위치에 생성한다.
        GameObject planet = Instantiate(prefab, spawnPosition, Quaternion.identity);

        // 생성된 프리팹의 이동 경로 전달
        EnemyMover mover = planet.GetComponent<EnemyMover>();
        if (mover != null)
        {
            mover.Init(targetPoint);
        }
    }
}