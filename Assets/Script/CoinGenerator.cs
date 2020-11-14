using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPooler;

    public void spawnCoins(Vector3 position, float groundWidth) {
    	int probability = Random.Range(1,100);
    	if (probability > 50) {
    		return;
    	}
    	float y = Random.Range(2,4);
    	int numOfCoins = (int) Random.Range(3f, groundWidth);
    	for (int i = 0; i<numOfCoins; i++) {
    		GameObject coin = coinPooler.getPooledGameObject();
    		float x = position.x + i - (groundWidth/2) + 1 ;
	    	coin.transform.position = new Vector3(
	    		x,
	    		position.y + 2,
	    		0);
	    	coin.SetActive(true);
    	}
    	

    }
}
