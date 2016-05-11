using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour
{
	public GameObject m_ScrollGrid;
	public InfoPanel m_InfoPanel;

	public void DisplayYokaiInfos(ScrollCellTest cell)
	{
		m_InfoPanel.Name.text = cell.YokaiInfos["name-fr"];
		//m_InfoPanel.Img.mainTexture
		m_InfoPanel.Food.text = cell.YokaiInfos["food"];
		m_InfoPanel.gameObject.SetActive(true);
		m_ScrollGrid.SetActive(false);
	}

	public void OnInfoPanelBack()
	{
		m_InfoPanel.gameObject.SetActive(false);
		m_ScrollGrid.SetActive(true);
	}
}
