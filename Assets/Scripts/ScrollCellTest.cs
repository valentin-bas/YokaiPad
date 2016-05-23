using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;

public class ScrollCellTest : MonoBehaviour
{
    public Image image;

    public Text cellLabel;
	public Text foodLabel;

    private JSONNode m_YokaiInfos;
	private PanelManager m_PanelManager;

	public JSONNode YokaiInfos { get { return m_YokaiInfos; } }

	public void Init(JSONNode yokaiInfos, PanelManager panelManager)
	{
		m_YokaiInfos = yokaiInfos;
		m_PanelManager = panelManager;
       // StartCoroutine(LoadYokaiImg(m_YokaiInfos["img"]));
        cellLabel.text = m_YokaiInfos["name-fr"];
        foodLabel.text = m_YokaiInfos["food"];
    }

	public void OnButtonClick()
	{
		m_PanelManager.DisplayYokaiInfos(this);
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
            image.sprite = Sprite.Create(data.texture, new Rect(0, 0, data.texture.width, data.texture.height), Vector2.zero);
        }
    }
}

