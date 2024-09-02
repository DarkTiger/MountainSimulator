using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {


	public Transform target;
	public Texture2D arrow;
	public Texture2D cardinalPoint;
	public int minimapHeight = 100;

	Vector2 cardinalPivot;
	Rect cardinalRect;
	float angle = 0;
	public GUIStyle style;


	void Start ()
	{
		Vector3 rot = new Vector3(90,0,0);
		transform.Rotate(rot);
	}


	void Update () 
	{
		gameObject.camera.pixelRect = new Rect(20, 36, 200, 200);


		Vector3 pos = target.position;
		pos.y = (target.position.y + minimapHeight);

		transform.position = pos;

				
		Vector3 rot = transform.eulerAngles;
		rot.y = target.eulerAngles.y;
		transform.eulerAngles = rot;

		cardinalRect = new Rect(120-(cardinalPoint.width/2),Screen.height-136-(cardinalPoint.height/2),cardinalPoint.width,cardinalPoint.height);
		cardinalPivot = new Vector2(cardinalRect.xMin + cardinalRect.width * 0.5f, cardinalRect.yMin + cardinalRect.height * 0.5f);


		angle = transform.eulerAngles.y;


		ChangeMinimapHeight();
	}


	void ChangeMinimapHeight()
	{
		if (Input.GetKey(KeyCode.Z))
		{
			if (minimapHeight < 125)
			{
				minimapHeight += 1;
			}
		}

		else if (Input.GetKey(KeyCode.X))
		{
			if (minimapHeight > 25)
			{
				minimapHeight -= 1;
			}
		}
	}


	void OnGUI ()
	{

		GUI.DrawTexture(new Rect(120-(arrow.width/2),Screen.height-136-(arrow.height/2),arrow.width,arrow.height),arrow);

		style.normal.textColor = Color.black;
		GUI.Label(new Rect(120-(100), Screen.height - 29, 200, 20), "Height: " + minimapHeight.ToString() + "m", style);
		style.normal.textColor = Color.white;
		GUI.Label(new Rect(118-(100), Screen.height - 31, 200, 20), "Height: " + minimapHeight.ToString() + "m", style);

		GUIUtility.RotateAroundPivot(angle, cardinalPivot);
		GUI.DrawTexture(new Rect(120-(cardinalPoint.width/2),Screen.height-136-(cardinalPoint.height/2),cardinalPoint.width,cardinalPoint.height),cardinalPoint);
		//GUIUtility.RotateAroundPivot
	}


}
