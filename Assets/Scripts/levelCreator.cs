
using UnityEngine;

public class levelCreator : MonoBehaviour
{
    public Texture2D map;

	void Start () {
		GenerateLevel();
	}

	void GenerateLevel()
	{
		for (int x = 0; x < map.width; x++){
			for (int y = 0; y < map.height; y++){
				GenerateTile(x, y);
			}
		}
	}

	void GenerateTile(int x, int y){
		Color pixelColor = map.GetPixel(x, y);

		if (pixelColor.a == 0){
			// The pixel is trnsparrent, so ignore
			return;
		}
		Debug.Log(pixelColor);
		
	}
}
