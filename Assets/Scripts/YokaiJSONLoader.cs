using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.Text;

public class YokaiJSONLoader : MonoBehaviour
{
	public string filename = "YokaiList.json";

	public JSONNode YokaiList;

	void Start()
	{
		YokaiList = null;
	}

	public void Load()
	{
		YokaiList = null;
		StartCoroutine(LoadJSONFile());
	}

	private IEnumerator LoadJSONFile()
	{
		WWW data;
		if (Application.platform == RuntimePlatform.Android)
			data = new WWW("jar:file://" + Application.dataPath + "!/assets/" + filename);
		else
			data = new WWW("file:///" + Application.streamingAssetsPath + "/" + filename);
		yield return data;

		if (string.IsNullOrEmpty(data.error))
		{
			OnFileLoaded(Encoding.Default.GetString(data.bytes));
		}
	}

	private void OnFileLoaded(string data)
	{
		var N = JSON.Parse(data);
		YokaiList = N["data"]["yokaiList"];
	}
}
