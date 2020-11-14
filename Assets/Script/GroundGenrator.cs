using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenrator : MonoBehaviour
{
	public Transform groundPoint;
    public Transform maxHeight;
    public Transform minHeight;
	public ObjectPooler[] groundPoolers;
    public float minGap, maxGap;

	private float[] groundWidths;
    private float maxY, minY;
    private CoinGenerator coinGenerator;
    void Start()
    {
        minY = minHeight.transform.position.y;
        maxY = maxHeight.transform.position.y;
        groundWidths = new float[groundPoolers.Length];
        for(int i = 0; i<groundPoolers.Length; i++) {
        	groundWidths[i] = groundPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        coinGenerator = FindObjectOfType<CoinGenerator>();
    }

    void Update()
    {
        if(transform.position.x < groundPoint.position.x) {
        	int random = Random.Range(0, groundPoolers.Length);
        	float distance = groundWidths[random]/2;
            float gap = Random.Range(minGap, maxGap);
            float height = Random.Range(minY, maxY);

        	transform.position = new Vector3(
        		transform.position.x + distance + gap,
        		height,
        		0);

        	GameObject ground = groundPoolers[random].getPooledGameObject();

        	ground.transform.position = new Vector3(
                transform.position.x,
                height,
                0);
        	ground.SetActive(true);

            coinGenerator.spawnCoins(
                transform.position,
                groundWidths[random]);

        	transform.position = new Vector3(
        		transform.position.x + distance,
        		transform.position.y,
        		0);

        }
    }
}
