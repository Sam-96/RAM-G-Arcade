using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameplayCanvas : MonoBehaviour {

	public static gameplayCanvas instance;
	public GameObject directionalLight;
	public monster[] monsters;
	public Text WinText;
	public Text txtPages;
	public string pagesString;
	public int pagesTotal = 4;
	private int pagesFound = 0;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		updateCanvas();
		WinText.GetComponent<Text> ().enabled = false;
	}

	public void updateCanvas()
	{
		pagesString = "Pages Found: "+pagesFound.ToString()+"/"+pagesTotal.ToString();
		txtPages.text = pagesString;
		if (pagesFound >= pagesTotal)
			WinText.GetComponent<Text> ().enabled = true;
	}

	public void findPage()
	{
		pagesFound++;
		updateCanvas();

		//win//
		if(pagesFound >= pagesTotal)
		{
			directionalLight.SetActive(true);

			for(int n = 0; n < monsters.GetLength(0);n++)
			{
				monsters[n].death();
			}
		}
	}

}
