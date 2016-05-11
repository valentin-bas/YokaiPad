using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;

public class ScrollCellTest : MonoBehaviour
{
	public Text cellLabel;

	private JSONNode m_YokaiInfos;
	private PanelManager m_PanelManager;

	public JSONNode YokaiInfos { get { return m_YokaiInfos; } }

	public void Init(JSONNode yokaiInfos, PanelManager panelManager)
	{
		m_YokaiInfos = yokaiInfos;
		m_PanelManager = panelManager;
		cellLabel.text = m_YokaiInfos["name-fr"];
	}

	public void OnButtonClick()
	{
		m_PanelManager.DisplayYokaiInfos(this);
	}
}

