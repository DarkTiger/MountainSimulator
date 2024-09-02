using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	float frameCount = 0;
	float deltaTime = 0;
	float fps = 0;
	float updateRate = 1.0f;
	float staminaValue;
	bool showMode = true;
	GUIStyle styleOmbra;
	string fatigueString = "0";

	public GUIStyle style;
	public Image staminaBar;
	public GameObject HUDCanvas;
	public GameObject HUDCanvas2;


	void Start()
	{
		showMode = true;
		//HUDCanvas.enabled = false;
		HUDCanvas.SetActive(false);
		HUDCanvas2.SetActive(true);
	}


	void Update () 
	{
		frameCount++;
		deltaTime += Time.deltaTime;
		
		if (deltaTime > 0.47f / updateRate)
		{
			fps = Mathf.Round(frameCount / deltaTime);
			frameCount = 0;
			deltaTime -= 0.5f/updateRate;
			fatigueString = GetComponent<StepControl>().fatigueValue.ToString();
		}

		staminaValue = GetComponent<StepControl>().staminaValue;

	
		if (Input.GetKeyUp(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.LeftShift))
		{
			if (showMode)
			{
				showMode = false;
				HUDCanvas.SetActive(true);
				HUDCanvas2.SetActive(false);
			}
			else
			{
				showMode = true;
				HUDCanvas.SetActive(false);
				HUDCanvas2.SetActive(true);
			}
		}
	}


	void OnGUI()
	{
		if (!showMode)
		{
			int staminaBarX = Mathf.RoundToInt(staminaValue) + 1;
			staminaBar.rectTransform.sizeDelta = new Vector2(staminaBarX,25);


			style.fontSize = 32;
			style.alignment = TextAnchor.UpperLeft;
			string fpsString = fps.ToString();
			GUI.Label(new Rect(20, 0, 100, 100), "FPS: " + fpsString, style);
	
						/*styleOmbra = style;
			styleOmbra.normal.textColor = Color.black;*/

			//GUI.Label(new Rect(503, 23, 100, 100), "Fatica: " + fatigueString + "%", styleOmbra);
			GUI.Label(new Rect(300, 0, 100, 100), "Sforzo Attuale: " + fatigueString + "%", style);
		}
		else
		{
			style.fontSize = 40;
			style.alignment = TextAnchor.UpperLeft;

			style.normal.textColor = Color.black;
			GUI.Label(new Rect(24, 4, 100, 100), "(Pre-Alpha Preview)", style);

			style.normal.textColor = Color.white;
			GUI.Label(new Rect(20, 0, 100, 100), "(Pre-Alpha Preview)", style);

			style.fontSize = 20;
			style.alignment = TextAnchor.LowerCenter;
			style.normal.textColor = Color.black;
			GUI.Label(new Rect(2, Screen.height - 104, Screen.width, 100), "Copyright(c) 2015, Daniele Franceschini (daniele.franceschini@live.it), Michele Mazzurana (mazzurana.michele@gmail.com)", style);
			style.normal.textColor = Color.white;
			GUI.Label(new Rect(0, Screen.height - 106, Screen.width, 100), "Copyright(c) 2015, Daniele Franceschini (daniele.franceschini@live.it), Michele Mazzurana (mazzurana.michele@gmail.com)", style);		
		}

	}

}
