using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour
{
	public GameObject m_ScrollGrid;
	public InfoPanel m_InfoPanel;

	public void DisplayYokaiInfos(ScrollCellTest cell)
	{
		StartCoroutine(LoadYokaiImg(cell.YokaiInfos["img"]));
		m_InfoPanel.Name.text = cell.YokaiInfos["name-fr"];
		m_InfoPanel.Food.text = cell.YokaiInfos["food"];
		m_InfoPanel.gameObject.SetActive(true);
		m_ScrollGrid.SetActive(false);
	}

	private IEnumerator LoadYokaiImg(string filename)
	{
		WWW data;
		if (Application.platform == RuntimePlatform.Android)
			data = new WWW("jar:file://" + Application.dataPath + "!/assets/Img/" + filename);
		else
			data = new WWW("file:///" + Application.streamingAssetsPath + "/Img/" + filename);
		yield return data;

		if (string.IsNullOrEmpty(data.error))
		{
			m_InfoPanel.Img.sprite = Sprite.Create(data.texture, new Rect(0, 0, data.texture.width, data.texture.height), Vector2.zero);
		}
	}

	public void OnInfoPanelBack()
	{
		m_InfoPanel.gameObject.SetActive(false);
		m_ScrollGrid.SetActive(true);
	}
}
