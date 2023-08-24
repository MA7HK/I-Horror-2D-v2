using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsController : MonoBehaviour
{
    public GameObject footstepPrefab;
    public float spawnTime = 0.5f;
    public float fastSpawnTime = .25f;
    public float fadeTime = 1f;

    internal bool isWalking = false;
    internal bool isSprinting = false;
    private float timeSinceLastSpawn = 0f;
    private List<GameObject> footsteps = new List<GameObject>();

    void Update()
    {
        if (isWalking)
        {
            timeSinceLastSpawn += Time.deltaTime;
            if ((!isSprinting && timeSinceLastSpawn >= spawnTime) || (isSprinting && timeSinceLastSpawn>=fastSpawnTime))
            {
                SpawnFootstep();
                timeSinceLastSpawn = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        for (int i = footsteps.Count - 1; i >= 0; i--)
        {
            GameObject footstep = footsteps[i];
            SpriteRenderer sr = footstep.GetComponent<SpriteRenderer>();
            Color color = sr.color;
            color.a -= Time.deltaTime / fadeTime;
            sr.color = color;

            if (color.a <= 0)
            {
                footsteps.RemoveAt(i);
                Destroy(footstep);
            }
        }
    }

    void SpawnFootstep()
    {
        Vector3 position = transform.position;
        GameObject footstep = Instantiate(footstepPrefab, position, footstepPrefab.transform.rotation);
        footsteps.Add(footstep);
    }

    public void StartWalking()
    {
        isWalking = true;
    }

    public void StopWalking()
    {
        isWalking = false;
    }
}