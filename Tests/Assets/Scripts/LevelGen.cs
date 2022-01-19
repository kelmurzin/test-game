using UnityEngine;
using UnityEngine.AI;

public class LevelGen : MonoBehaviour
{
	public NavMeshSurface surface;

	public int width = 10;
	public int height = 10;

	public GameObject wall;
	public GameObject player;

	
	
	private void Start()
	{
		GenerateLevel();
		surface.BuildNavMesh();
	}

	
	private void GenerateLevel()
	{
		
		for (int x = 0; x <= width; x += 2)
		{
			for (int y = 0; y <= height; y += 2)
			{
				
				if (Random.value > .7f)
				{
					
					Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
					Instantiate(wall, pos, Quaternion.identity, transform);
				}
				
			}
		}
	}

}