using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelSystem : StaticInstance<LevelSystem> {

	public List<SO_Level> Levels { get; private set; }
	private Dictionary<string, SO_Level> _LevelsDict;
	private GameObject currentLevel;

	protected override void Awake()
	{
		base.Awake();
		AssembleResources();
	}

	private void AssembleResources() {
		Levels = Resources.LoadAll<SO_Level>("Levels").ToList();
		_LevelsDict = Levels.ToDictionary(r => r.LevelName, r => r);
	}

	public LevelController LoadLevel(string levelName) {

		if (currentLevel != null)
		{
			var levelEliminated = currentLevel;
			Destroy(levelEliminated);
		}

		if (!_LevelsDict.ContainsKey(levelName))
			Debug.LogWarning("Level name not founded on Resources");
		
		var rootObject = Instantiate(_LevelsDict[levelName].Prefab);
		var levelController = rootObject.GetComponent<LevelController>();

		currentLevel = rootObject;
		
		return levelController;
	}
}   