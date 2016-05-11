using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YokaiScrollList : UIList<ScrollCellTest>
{
	public YokaiJSONLoader Loader;

	private PanelManager m_PanelManager;

	private bool Initialized;

	// Use this for initialization
	void Start ()
	{
		m_PanelManager = GetComponent<PanelManager>();
		Initialized = false;
		if (Loader != null)
			Loader.Load();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!Initialized && Loader != null && Loader.YokaiList != null)
		{
			CreateList();
			Initialized = true;
		}
	}

	public void CreateList()
	{
		int cells = Loader.YokaiList.Count;

		if (cells > 0)
		{
			ClearAllCells();
			Refresh();
		}
	}

	#region implemented abstract members of UIList

	public override int NumberOfCells()
	{
		if (Loader.YokaiList == null)
			return 0;
		return Loader.YokaiList.Count;
	}

	public override void UpdateCell(int index, ScrollCellTest cell)
	{
		cell.Init(Loader.YokaiList[index], m_PanelManager);
	}

	#endregion
}
