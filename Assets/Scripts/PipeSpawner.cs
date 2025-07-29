using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float pipeSpawnTime = 1.6f;
    [SerializeField] private float pipeHeightRange = 0.45f;
    [SerializeField] private GameObject pipePrefab; 

    private float _timer;

    void Start()
    {

    }

    private void Update()
    {
        if (_timer > pipeSpawnTime)
        {
            SpawnPipe();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-pipeHeightRange, pipeHeightRange));
        GameObject pipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}