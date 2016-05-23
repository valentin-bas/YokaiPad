using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public static class StringExtensions
{
    public static bool Contains(this string source, string toCheck, StringComparison comp)
    {
        return source.IndexOf(toCheck, comp) >= 0;
    }
}

public class YokaiScrollList : UIList<ScrollCellTest>
{
	public YokaiJSONLoader Loader;

	private PanelManager m_PanelManager;

	private bool Initialized;

    public Text nameYokai;
    public ScrollRect scrollRect;
    public RectTransform contentPanel;

    public int offsetSearch;

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

    public void Search()
    {
        string name = nameYokai.text;
        Debug.Log(name);
        RectTransform target;
        for (int i = 0; i < Loader.YokaiList.Count; i++)
        {
            string nameFullYokai = Loader.YokaiList[i]["name-fr"];
            if (nameFullYokai.Contains(name, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log(nameFullYokai);
                target = cells[i].gameObject.GetComponent<RectTransform>();
                SnapTo(target);
                break;
            }
        }
    }

    public void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();
        contentPanel.anchoredPosition = new Vector2(contentPanel.anchoredPosition.x,
            scrollRect.transform.InverseTransformPoint(contentPanel.position).y
            - scrollRect.transform.InverseTransformPoint(target.position).y);

        contentPanel.anchoredPosition = new Vector2(contentPanel.anchoredPosition.x, contentPanel.anchoredPosition.y + offsetSearch);
    }

    #endregion
}
