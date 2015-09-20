﻿
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using AssemblyCSharp;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.EventSystems;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (CapsuleCollider))]

public class ControlEvent : MonoBehaviour ,IEventSystemHandler {
	public Canvas searchMenu;
	public Canvas charKeyboard;
	public Canvas blockSelector;
	public Canvas containBlock;
	public Canvas containRangeNumber;
	public Canvas ctnRange;
	public Button searchBtn;
	public Button reservedBtn;
	public Button numSearchBtn;
	public Button bathroomSearchBtn;
	public Button segmentSearchBtn;
	public Button resizeVideo;
	public Button exitViedo;
	public Button calcelSearch;
	public Button NextBtn;
	public RawImage Videocarosel;


	public Material yellowTarget;

	public GameObject cube;

	public Button btnRight;
	public Button btnLeft;
	public Button btnUp;
	public Button btnDown;

	public Image floorSelector;
	public Image blockSelectorimg;

	
	
	public Button fl1, fl2, fl3, fl4;
	
	public RawImage videoOffice;
	
	
	public Canvas ContainResult;
	
	public Color c2 = new Color (137 / 255f, 6 / 255f, 6 / 255f);


	float ratetio = 1f;

	private Dictionary<string,Vector3> PositnBlock = new Dictionary<string, Vector3> ();







	Vector3 block9_1 = new Vector3 (310.4033F, 0.5F, 172.7136F);
	Vector3 block8_1 = new Vector3 (299.8048f, 0.41f, 186.1202f);
	Vector3 block8_2 = new Vector3 (300.5f, 0.1926727f, 189.3f);
	Vector3 block8_3 = new Vector3 (300f, 0.1845566f, 191.9f);
	
	Vector3 block1_1 = new Vector3 (300.1561f, 0.2f, 188f);
	Vector3 block1_2 = new Vector3 (300.1f, 0.4f, 187.8f);
	Vector3 block1_3 = new Vector3 (299.9835f, 0.2f, 188f);
	Vector3 block1_4 = new Vector3 (300.09f, 0.4f, 187.9f);
	
	Vector3 block2_1 = new Vector3 (300.1561f, 0.2f, 188f);
	Vector3 block2_2 = new Vector3 (300.1f, 0.4f, 187.8f);
	Vector3 block2_3 = new Vector3 (300f, 0.2f, 187.9f);
	Vector3 block2_4 = new Vector3 (301.58f, 0.4f, 188.02f);
	
	Vector3 block3_1 = new Vector3 (300.1561f, 0.2f, 188f);
	Vector3 block3_2 = new Vector3 (300.1f, 0.4f, 187.8f);
	Vector3 block3_3 = new Vector3 (299.9835f, 0.2f, 188f);
	Vector3 block3_4 = new Vector3 (300.09f, 0.4f, 187.9f);
	
	Vector3 block4_1 = new Vector3 (300.39f, 0.3f, 188.03f);
	Vector3 block4_2 = new Vector3 (300.2f, 0.3f, 188.11f);
	Vector3 block4_3 = new Vector3 (300.2f, 0.3f, 187.95f);
	Vector3 block4_4 = new Vector3 (300.27f, 0.3f, 189.1f);
	
	Vector3 block5_1 = new Vector3 (300.64f, 0.3f, 188.6f);
	Vector3 block5_2 = new Vector3 (300.37f, 0.3f, 188f);
	Vector3 block5_3 = new Vector3 (299.96f, 0.3f, 187.86f);
	Vector3 block5_4 = new Vector3 (300.03f, 0.3f, 188.6f);
	
	Vector3 block6_1 = new Vector3 (299.9f, 0.3f, 190.5f);
	Vector3 block6_2 = new Vector3 (299.6f, 0.3f, 190.1f);

	Vector3 block6_3 = new Vector3 (299.6f, 0.3f, 189.9f);
	Vector3 block6_4 = new Vector3 (299.34f, 0.3f, 190f);
	
	Vector3 block7_1 = new Vector3 (299.3f, 0.3f, 190f);
	Vector3 block7_2 = new Vector3 (299.7f, 0.3f, 190f);
	
	
	
	Vector3 block7_1h = new Vector3 (299.0187f, 1000f, 188.6f);
	Vector3 block7_2h = new Vector3 (299f, 1000f, 189.9f);
	
	Vector3 block6_1h = new Vector3 (299.2f, 1000f, 184.9f);
	Vector3 block6_2h = new Vector3 (300.1f, 1000f, 188f);
	Vector3 block6_3h = new Vector3 (299.3f, 1000f, 186.8f);
	Vector3 block6_4h = new Vector3 (299.7f, 1000f, 189.1f);
	
	Vector3 block5_1h = new Vector3 (299.2f, 1000f, 184.9f);
	Vector3 block5_2h = new Vector3 (300.1f, 1000f, 188f);
	Vector3 block5_3h = new Vector3 (299.3f, 1000f, 186.8f);
	Vector3 block5_4h = new Vector3 (299.7f, 1000f, 189.1f);
	
	Vector3 block4_1h = new Vector3 (299.2f, 1000f, 184.9f);
	Vector3 block4_2h = new Vector3 (300.1f, 1000f, 188f);
	Vector3 block4_3h = new Vector3 (299.3f, 1000f, 186.8f);
	Vector3 block4_4h = new Vector3 (299.7f, 1000f, 189.1f);
	
	Vector3 block3_1h = new Vector3 (300.1561f, 1000f, 190.8f);
	Vector3 block3_2h = new Vector3 (298.9566f, 1000f, 186.9f);
	Vector3 block3_3h = new Vector3 (299.9835f, 1000f, 188f);
	Vector3 block3_4h = new Vector3 (299.7f, 1000f, 184.6f);
	
	Vector3 block2_1h = new Vector3 (300.1561f, 1000f, 190.8f);
	Vector3 block2_2h = new Vector3 (298.9566f, 1000f, 186.9f);
	Vector3 block2_3h = new Vector3 (300.6069f, 1000f, 188.3f);
	Vector3 block2_4h = new Vector3 (302.3733f, 1000f, 185.8f);
	
	Vector3 block1_1h = new Vector3 (300.1561f, 1000f, 190.8f);
	Vector3 block1_2h = new Vector3 (298.9566f, 1000f, 186.9f);
	Vector3 block1_3h = new Vector3 (299.9835f, 1000f, 188f);
	Vector3 block1_4h = new Vector3 (299.7f, 1000f, 184.6f);
	
	Vector3 block8_1h = new Vector3 (299.8f, 1000f, 186.1f);
	Vector3 block8_2h = new Vector3 (300.5f, 1000f, 189.3f);
	Vector3 block8_3h = new Vector3 (300.5f, 1000f, 191.9f);

	Vector3 block9_1h = new Vector3 (310.4033F, 1000F, 172.7136F);

	
	Vector3 block8_2transparent = new Vector3 (300.5f, 1000f, 189.3f);
	Vector3 block6_2transparent = new Vector3 (300.1f, 1000f, 188f);
	Vector3 block6_3transparent = new Vector3 (299.3f, 1000f, 186.8f);
	Vector3 block5_2transparent = new Vector3 (300.1f, 1000f, 188f);
	Vector3 block5_3transparent = new Vector3 (299.3f, 1000f, 186.8f);
	Vector3 block4_2transparent = new Vector3 (300.1f, 1000f, 188f);
	Vector3 block4_3transparent = new Vector3 (299.3f, 1000f, 186.8f);
	Vector3 block3_2transparent = new Vector3 (299.9835f, 1000f, 188f);
	Vector3 block3_3transparent = new Vector3 (298.9566f, 1000f, 186.9f);
	Vector3 block2_2transparent = new Vector3 (299.9835f, 1000f, 188f);
	Vector3 block2_3transparent = new Vector3 (300f, 1000f, 187.9f);
	Vector3 block1_2transparent = new Vector3 (299.9835f, 1000f, 188f);
	Vector3 block1_3transparent = new Vector3 (298.9566f, 1000f, 186.9f);


	
	Vector3 routeblock8_2 = new Vector3 (300.5f, 35f, 189.3f);

	Vector3 hideStartPoint = new Vector3 (200f, 1000f, 200f);
	Vector3 hideEndPoint = new Vector3 (200f, 1000f, 200f);
	
	RouteBettwenBlock block9_1Info = new RouteBettwenBlock ();
	
	Point8_1 block8_1Info = new Point8_1 ();	
	Point8_2 block8_2Info = new Point8_2 ();
	Point8_3 block8_3Info = new Point8_3 ();
	
	Point8_2handicap block8_2Infohandicap = new Point8_2handicap ();
	Point8_3handicap block8_3Infohandicap = new Point8_3handicap ();

	Point6_4handicap block6_4Infohandicap = new Point6_4handicap ();
	Point6_3handicap block6_3Infohandicap = new Point6_3handicap ();
	Point6_2handicap block6_2Infohandicap = new Point6_2handicap ();

	Point5_4handicap block5_4Infohandicap = new Point5_4handicap ();
	Point5_3handicap block5_3Infohandicap = new Point5_3handicap ();
	Point5_2handicap block5_2Infohandicap = new Point5_2handicap ();
	
	Point4_4handicap block4_4Infohandicap = new Point4_4handicap ();
	Point4_3handicap block4_3Infohandicap = new Point4_3handicap ();
	Point4_2handicap block4_2Infohandicap = new Point4_2handicap ();
	
	Point3_4handicap block3_4Infohandicap = new Point3_4handicap ();
	Point3_3handicap block3_3Infohandicap = new Point3_3handicap ();
	Point3_2handicap block3_2Infohandicap = new Point3_2handicap ();

	
	Point2_4handicap block2_4Infohandicap = new Point2_4handicap ();
	Point2_3handicap block2_3Infohandicap = new Point2_3handicap ();

	Point7_1 block7_1Info = new Point7_1();
	Point7_2 block7_2Info = new Point7_2();
	
	//Point7_1 block6_1Info = new Point6_1 ();
	//Point7_2 block6_2Info = new Point6_2 ();

	Point6_1 block6_1Info = new Point6_1 ();
	Point6_2 block6_2Info = new Point6_2 ();	
	Point6_3 block6_3Info = new Point6_3 ();	
	Point6_4 block6_4Info = new Point6_4 ();

	Point5_1 block5_1Info = new Point5_1 ();
	Point5_2 block5_2Info = new Point5_2 ();	
	Point5_3 block5_3Info = new Point5_3 ();	
	Point5_4 block5_4Info = new Point5_4 ();

	Point4_1 block4_1Info = new Point4_1 ();
	Point4_2 block4_2Info = new Point4_2 ();	
	Point4_3 block4_3Info = new Point4_3 ();	
	Point4_4 block4_4Info = new Point4_4 ();

	Point3_1 block3_1Info = new Point3_1 ();
	Point3_2 block3_2Info = new Point3_2 ();	
	Point3_3 block3_3Info = new Point3_3 ();	
	Point3_4 block3_4Info = new Point3_4 ();

	//Point2_1 block2_1Info = new Point6_1 ();
	//Point2_2 block2_2Info = new Point6_2 ();	
	Point2_3 block2_3Info = new Point2_3 ();	
	Point2_4 block2_4Info = new Point2_4 ();

	
	
	
	Vector3[] listpoint;
	
	int currentBlock = 8;

	
	public const string imageType = ".png",videoType = ".ogv";
	public GameObject arrow = null;
	
	
	public GameObject Cylinder = null;
	
	
	public int maxOffice = 25;
	private int currentIndex = 0;
	
	
	public bool update = false;
		
	public float widthLinear = 0.1f;
	
	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
	
	
	private System.Timers.Timer aTimer;
	private System.Timers.Timer carouselTimer;
	private System.Timers.Timer moveNextCamera;
	
	public string IP = "http://localhost:8080/";
	
	
	List<Sprite> TextureBtn =
		new List<Sprite>();
	static Vector3 center = new Vector3 (300.0045f, 0.41f, 183.9f);
	
	// Use this for initialization
	void Start () {


			
		target = center;
		
		PositnBlock.Add ("block1_1", block1_1);
		PositnBlock.Add ("block1_2", block1_2);
		PositnBlock.Add ("block1_3", block1_3);
		PositnBlock.Add ("block1_4", block1_4);
		PositnBlock.Add ("block2_1", block2_1);
		PositnBlock.Add ("block2_2", block2_2);
		PositnBlock.Add ("block2_3", block2_3);
		PositnBlock.Add ("block2_4", block2_4);
		PositnBlock.Add ("block3_1", block3_1);
		PositnBlock.Add ("block3_2", block3_2);
		PositnBlock.Add ("block3_3", block3_3);
		PositnBlock.Add ("block3_4", block3_4);
		PositnBlock.Add ("block4_1", block4_1);
		PositnBlock.Add ("block4_2", block4_2);
		PositnBlock.Add ("block4_3", block4_3);
		PositnBlock.Add ("block4_4", block4_4);
		PositnBlock.Add ("block5_1", block5_1);
		PositnBlock.Add ("block5_2", block5_2);
		PositnBlock.Add ("block5_3", block5_3);
		PositnBlock.Add ("block5_4", block5_4);
		PositnBlock.Add ("block6_1", block6_1);
		PositnBlock.Add ("block6_2", block6_2);
		PositnBlock.Add ("block6_3", block6_3);
		PositnBlock.Add ("block6_4", block6_4);		
		PositnBlock.Add ("block7_1", block7_1);
		PositnBlock.Add ("block7_2", block7_2);
		PositnBlock.Add ("block8_1", block8_1);
		PositnBlock.Add ("block8_2", block8_2);
		PositnBlock.Add ("block8_3", block8_3);
		PositnBlock.Add ("block9_1", block9_1);
		
		
		PositnBlock.Add ("block1_1h", block1_1h);
		PositnBlock.Add ("block1_2h", block1_2h);
		PositnBlock.Add ("block1_3h", block1_3h);
		PositnBlock.Add ("block1_4h", block1_4h);
		PositnBlock.Add ("block2_1h", block2_1h);
		PositnBlock.Add ("block2_2h", block2_2h);
		PositnBlock.Add ("block2_3h", block2_3h);
		PositnBlock.Add ("block2_4h", block2_4h);
		PositnBlock.Add ("block3_1h", block3_1h);
		PositnBlock.Add ("block3_2h", block3_2h);
		PositnBlock.Add ("block3_3h", block3_3h);
		PositnBlock.Add ("block3_4h", block3_4h);
		PositnBlock.Add ("block4_1h", block4_1h);
		PositnBlock.Add ("block4_2h", block4_2h);
		PositnBlock.Add ("block4_3h", block4_3h);
		PositnBlock.Add ("block4_4h", block4_4h);
		PositnBlock.Add ("block5_1h", block5_1h);
		PositnBlock.Add ("block5_2h", block5_2h);
		PositnBlock.Add ("block5_3h", block5_3h);
		PositnBlock.Add ("block5_4h", block5_4h);
		PositnBlock.Add ("block6_1h", block6_1h);
		PositnBlock.Add ("block6_2h", block6_2h);
		PositnBlock.Add ("block6_3h", block6_3h);
		PositnBlock.Add ("block6_4h", block6_4h);		
		PositnBlock.Add ("block7_1h", block7_1h);
		PositnBlock.Add ("block7_2h", block7_2h);
		PositnBlock.Add ("block8_1h", block8_1h);
		PositnBlock.Add ("block8_2h", block8_2h);
		PositnBlock.Add ("block8_3h", block8_3h);
		PositnBlock.Add ("block9_1h", block9_1h);

		PositnBlock.Add("block8_2transparenth",block8_2transparent);
		PositnBlock.Add("block6_3transparenth",block6_3transparent);
		PositnBlock.Add("block6_2transparenth",block6_2transparent);
		PositnBlock.Add("block5_3transparenth",block5_3transparent);
		PositnBlock.Add("block5_2transparenth",block5_2transparent);
		PositnBlock.Add("block4_3transparenth",block4_3transparent);
		PositnBlock.Add("block4_2transparenth",block4_2transparent);
		PositnBlock.Add("block3_3transparenth",block3_3transparent);
		PositnBlock.Add("block3_2transparenth",block3_2transparent);
		PositnBlock.Add("block2_3transparenth",block2_3transparent);
		PositnBlock.Add("block2_2transparenth",block2_2transparent);
		PositnBlock.Add("block1_3transparenth",block1_3transparent);
		PositnBlock.Add("block1_2transparenth",block1_2transparent);

		
		PositnBlock.Add ("routeblock8_2", routeblock8_2);
		
		
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		//lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(c2, c2);
		lineRenderer.SetWidth(widthLinear, widthLinear);
		
		//blockSelector = blockSelector.GetComponent<Canvas> ();
		fl1 = fl1.GetComponent<Button> ();
		fl2 = fl2.GetComponent<Button> ();
		fl3 = fl3.GetComponent<Button> ();
		containBlock = containBlock.GetComponent<Canvas> ();
		searchMenu = searchMenu.GetComponent<Canvas> ();
		charKeyboard = charKeyboard.GetComponent<Canvas> ();
		searchBtn = searchBtn.GetComponent<Button> ();
		reservedBtn = reservedBtn.GetComponent<Button> ();
		ContainResult = ContainResult.GetComponent<Canvas> ();
		searchMenu.enabled = false;
		charKeyboard.enabled = false;
		NextBtn = NextBtn.GetComponent<Button> ();
		madeButtonTransparent (NextBtn);
		//m_RigidBody = m_RigidBody.GetComponent<Rigidbody>();
		//StartCoroutine(loadcrosel());
		videoOffice = videoOffice.GetComponent<RawImage> ();
		isShowVideo (false);
		
		//StartCoroutine (LoadVideo (IP+"video/sample.ogg"));
		
		ContainResult.enabled = false;
		
		ctnRange.enabled = false;
		
		hideBlockSelector ();
		hideRangeNuber ();
		
		aTimer = new System.Timers.Timer(30000);
		
		// Hook up the Elapsed event for the timer. 
		aTimer.Elapsed += OnTimedEvent;
		
		aTimer.Start ();

		moveNextCamera = new System.Timers.Timer(2000);
		
		// Hook up the Elapsed event for the timer. 
		moveNextCamera.Elapsed += move2NextCamera;
		
		moveNextCamera.Stop ();


		videoOffice.enabled = false;
		
		
		StartCoroutine(sysServer());
		
		
	}

	bool beginmovetonextcamera = false;
	Vector3 lattt,posss;
	private void move2NextCamera(object o, System.Timers.ElapsedEventArgs e)
	{
		//Debug.Log("update sence");
		beginmovetonextcamera = true;
		moveNextCamera.Stop ();
	}
	
	public void cancleRangeNumber(){
		hideRangeNuber ();
	}
	
	public void cancleNumberSearch(){
		hideBlockSelector ();
	}
	
	
	public void numberSearchPress(){
		showFullTransparent ();
		showBlockSelector ();
	}
	
	private void hideBlockSelector(){
		
		blockSelector.enabled = false;
		containBlock.enabled = false;
	}
	private void showBlockSelector(){
		
		blockSelector.enabled = true;
		containBlock.enabled = true;
	}

	private bool handicap = false;
	public void handicapMode(){
		if (!handicap) {
			searchBtn.image.sprite = Resources.Load<Sprite> ("atozhandi");
			bathroomSearchBtn.image.sprite = Resources.Load<Sprite> ("bathroomhandi");
			reservedBtn.image.sprite = Resources.Load<Sprite> ("reservedhandi");
			numSearchBtn.image.sprite = Resources.Load<Sprite> ("numberhandi");
			segmentSearchBtn.image.sprite = Resources.Load<Sprite> ("segmenthandi");
			blockSelectorimg.sprite = Resources.Load<Sprite> ("blockselectorhandi");
		} else {
			searchBtn.image.sprite = Resources.Load<Sprite> ("atoz");
			bathroomSearchBtn.image.sprite = Resources.Load<Sprite> ("bathroom");
			reservedBtn.image.sprite = Resources.Load<Sprite> ("reserved");
			numSearchBtn.image.sprite = Resources.Load<Sprite> ("number");
			segmentSearchBtn.image.sprite = Resources.Load<Sprite> ("segment");
			blockSelectorimg.sprite = Resources.Load<Sprite> ("blockselector");
		}
		isHandicapMode = !isHandicapMode;
		handicap = !handicap;
	}

	int currentFloor = 1;

	public void gotoFloor1(){

		
		/*switch (currentFloor) {
		case 1:
			fl1.image.sprite = Resources.Load<Sprite> ("1");
			break;
		case 2:
			fl2.image.sprite = Resources.Load<Sprite> ("2");
			break;
		case 3:
			fl3.image.sprite = Resources.Load<Sprite> ("3");
			break;
		case 4:
			fl4.image.sprite = Resources.Load<Sprite> ("4");
			break;
		}
		
		fl1.image.sprite = Resources.Load<Sprite> ("1_click");*/

		stopRoute ();
		string floorName = "block" + currentBlock + "_" + currentFloor;

		hideBlck (currentBlock, currentFloor);
		currentFloor = 1;

		showBlck (currentBlock,currentFloor);

		if (currentBlock > 0 && currentBlock < 6)
			floorSelector.sprite = Resources.Load<Sprite> ("block1to5_1");
		else 
			floorSelector.sprite = Resources.Load<Sprite> (floorName);

		target = center;

		
	}
	public void gotoFloor2(){
		
		/*switch (currentFloor) {
		case 1:
			fl1.image.sprite = Resources.Load<Sprite> ("1");
			break;
		case 2:
			fl2.image.sprite = Resources.Load<Sprite> ("2");
			break;
		case 3:
			fl3.image.sprite = Resources.Load<Sprite> ("3");
			break;
		case 4:
			fl4.image.sprite = Resources.Load<Sprite> ("4");
			break;
		}
		
		fl2.image.sprite = Resources.Load<Sprite> ("2_click");*/

		stopRoute ();
		string floorName;


		hideBlck (currentBlock, currentFloor);
		currentFloor = 2;
		floorName = "block" + currentBlock + "_" + currentFloor;


		showBlck (currentBlock,currentFloor);
		if (currentBlock > 0 && currentBlock < 6)
			floorSelector.sprite = Resources.Load<Sprite> ("block1to5_2");
		else 
			floorSelector.sprite = Resources.Load<Sprite> (floorName);

		target = center;


	}
	public void gotoFloor3(){

		if ( currentBlock != 7) {
		
			/*switch (currentFloor) {
		case 1:
			fl1.image.sprite = Resources.Load<Sprite> ("1");
			break;
		case 2:
			fl2.image.sprite = Resources.Load<Sprite> ("2");
			break;
		case 3:
			fl3.image.sprite = Resources.Load<Sprite> ("3");
			break;
		case 4:
			fl4.image.sprite = Resources.Load<Sprite> ("4");
			break;
		}
		
		fl3.image.sprite = Resources.Load<Sprite> ("3_click");*/

			stopRoute ();
			string floorName;


			hideBlck (currentBlock, currentFloor);
			currentFloor = 3;
			floorName = "block" + currentBlock + "_" + currentFloor;

			showBlck (currentBlock,currentFloor);

			if (currentBlock > 0 && currentBlock < 6)
				floorSelector.sprite = Resources.Load<Sprite> ("block1to5_3");
			else 
				floorSelector.sprite = Resources.Load<Sprite> (floorName);

			target = center;
		}
	}
	public void gotoFloor4(){

		if (currentBlock > 0 && currentBlock < 7) {
			/*switch (currentFloor) {
		case 1:
			fl1.image.sprite = Resources.Load<Sprite> ("1");
			break;
		case 2:
			fl2.image.sprite = Resources.Load<Sprite> ("2");
			break;
		case 3:
			fl3.image.sprite = Resources.Load<Sprite> ("3");
			break;
		case 4:
			fl4.image.sprite = Resources.Load<Sprite> ("4");
			break;
		}
		
		fl4.image.sprite = Resources.Load<Sprite> ("4_click");*/

			stopRoute ();

			string floorName ;
		
			hideBlck (currentBlock, currentFloor);
			currentFloor = 4;
			floorName = "block" + currentBlock + "_" + currentFloor;
		
			showBlck (currentBlock,currentFloor);

			if (currentBlock > 0 && currentBlock < 6)
				floorSelector.sprite = Resources.Load<Sprite> ("block1to5_4");
			else 
				floorSelector.sprite = Resources.Load<Sprite> (floorName);

			target = center;
		}
	}

	private void madeButtonTransparent(Button btn){
		Color c = btn.targetGraphic.color;
		c.a = 0f;
		btn.targetGraphic.color = c;			
		btn.enabled=false;
	}

	private void disableFloor(int number){
		if (number < 4) {
			madeButtonTransparent(fl4);
		}
		if (number < 3) {
			madeButtonTransparent(fl3);
		}
	}

	private void showButton(Button btn){
		Color c = btn.targetGraphic.color;
		c.a = 1f;
		btn.targetGraphic.color = c;			
		btn.enabled = true;
	}

	private void enableAllfloor(){
		fl4.image.sprite = Resources.Load<Sprite>("4");
		showButton (fl4);

		fl3.image.sprite = Resources.Load<Sprite> ("3");
		showButton (fl3);

		fl2.image.sprite = Resources.Load<Sprite> ("2");
		showButton (fl2);
		
		fl1.image.sprite = Resources.Load<Sprite> ("1_click");
		showButton (fl1);
	}
	
	private void showBlck(int numberBlock, int numberFloor){
		string floorName;
		floorName = "block" + numberBlock + "_" + numberFloor;


		currentBlock = numberBlock;
		Vector3 postion = PositnBlock [floorName];

		GameObject.Find (floorName).transform.position = postion;
	}

	private void hideBlck(string floorName){	
		Vector3 postion = PositnBlock [floorName + "h"];
		GameObject.Find (floorName).transform.position = postion;
	}
	
	private void hideBlck(int numberBlock,int numberFloor){
		string floorName;
		floorName = "block" + numberBlock + "_" + numberFloor;

		Vector3 postion = PositnBlock [floorName + "h"];
		GameObject.Find (floorName).transform.position = postion;
	}
	
	public void selectBlock(Button btn){
		string name = btn.name;
		switch (name) {
		case "center":
			currentBlock = 0;
			break;
		case "bl1":
			currentBlock = 1;
			break;
		case "bl2":
			currentBlock = 2;
			break;
		case "bl3":
			currentBlock = 3;
			break;
		case "bl4":
			currentBlock = 4;
			break;
		case "bl5":
			currentBlock = 5;
			break;
		case "bl6":
			currentBlock = 6;
			break;
		case "bl7":
			currentBlock = 7;
			break;
		case "bl8":
			currentBlock = 8;
			break;
			
		}
		showRangeNumber ();
		//blockSelector.enabled = false;
		hideBlockSelector ();
		//Debug.Log (btn.name);
	}
	
	public void showRangeNumber()
	{
		containRangeNumber.enabled = true;
		ctnRange.enabled = true;
		
	}
	
	public void showresult(){
		cleanAllOffice ();
		searchMenu.enabled = true;		
		charKeyboard.enabled = false;
		ContainResult.enabled = true;
	}
	
	private void hideRangeNuber()
	{
		containRangeNumber.enabled = false;
		ctnRange.enabled = false;
	}

	Dictionary<string, MovieTexture> libariVideo = new Dictionary<string, MovieTexture> ();
	string currentvideo;
	
	private IEnumerator LoadVideo(string url)
	{
		currentvideo = url;
		isShowVideo (false);
		videoOffice.texture = null;
		MovieTexture movieTexture;

		if (libariVideo.ContainsKey (url)) {
			//Debug.Log("use old movie!!");
			movieTexture = libariVideo[url];
		} else {
			WWW www = new WWW(url);
			movieTexture = www.movie;			
			while (!movieTexture.isReadyToPlay) {
				yield return null;
			}
			libariVideo.Add(url,movieTexture);
			//Debug.Log("download new movie!!");
		}

		//Debug.Log ("Movie alredy!!");
		movieTexture.loop = true;
		videoOffice.texture = movieTexture;
		movieTexture.Play();
		isShowVideo (true);
		yield return null;
		
	}
	
	public void cacleSearch(){
		currentIndex = 0;
		charKeyboard.enabled = false;
		isShowVideo (false);
		searchMenu.enabled = false;
		cleanAllOffice ();
	}
	
	public void showKeyboard(){
		charKeyboard.enabled = true;
	}
	
	public void rangeBtnPress(Button btn){
		string name = btn.name;
		int min = 0, max = 0;
		switch (name) {
		case "r1":
			min=0;
			max=141;
			break;
		case "r2":
			min=142;
			max=178;
			break;
		case "r3":
			min=201;
			max=241;
			break;
		case "r4":
			min=242;
			max=265;
			break;
		case "r5":
			min=301;
			max=342;
			break;
		case "r6":
			min=343;
			max=371;
			break;
		case "r7":
			min=401;
			max=405;
			break;
		}
		cancleRangeNumber ();
		showresult ();
		searchOfficeInRange (currentBlock, max, min);
	}
	
	public void searchOfficeInRange(int blocknumber,int max, int min){
		
		foreach (string x in infomationForSearch) {
			if(x!=""){
				string[] info = x.Split(new string[]{" "},System.StringSplitOptions.None);
				if((blocknumber == int.Parse(info[0][1].ToString())))
				{
					int number = int.Parse(info[2]);
					if (number <= max && number >= min) {
						//Debug.Log (x);
						StartCoroutine(loadTexture4Office(info[0],info[1]));
						
					}
				}
			}
		}
	}
	
	private void OnTimedEvent(object o, System.Timers.ElapsedEventArgs e)
	{
		//Debug.Log("update sence");
		update = true;
	}

	private void LoadNextCarousel(object o, System.Timers.ElapsedEventArgs e)
	{
		//Debug.Log("update sence");
		shownextCarousel = true;
	}
	

	public void searchPress(){
		//lastRotate = Camera.main.transform.rotation;
		madeButtonTransparent (btnLeft);
		madeButtonTransparent (btnRight);
		madeButtonTransparent (btnDown);
		madeButtonTransparent (btnUp);
		madeButtonTransparent (NextBtn);
		
		showFullTransparent ();
		searchMenu.enabled = true;
		
		charKeyboard.enabled = true;
		ContainResult.enabled = false;
	}
	
	bool showSearch = false;
	
	bool changesize = true;
	public void resize(){
		//Debug.Log("resize click!!!!!!!!!!!1");
		if(changesize)
			videoOffice.rectTransform.sizeDelta = new Vector2( 400, 400);
		else videoOffice.rectTransform.sizeDelta = new Vector2( 300, 300);
		changesize=!changesize;
	}
	
	public void exitvideo(){
		//videoOffice.texture
		libariVideo [currentvideo].Stop ();
		if(!changesize)
			resize ();
		isShowVideo (false);
	}
	
	public void isShowVideo(bool isShow){
		if (isShow) {
			GameObject.Find("borderImg").GetComponent<Image>().enabled=true;
			videoOffice.enabled=true;
			exitViedo.gameObject.SetActive(true);
			resizeVideo.gameObject.SetActive(true);
		} else {
			GameObject.Find("borderImg").GetComponent<Image>().enabled=false;
			videoOffice.enabled=false;
			exitViedo.gameObject.SetActive(false);
			resizeVideo.gameObject.SetActive(false);
		}
	}
	
	string [] infomationForSearch;
	string[] infomationCarousel;
	bool firstLoad = true;
	
	public IEnumerator sysServer(){
		string result = string.Empty;
		using (var webClient = new System.Net.WebClient()) {
			result = webClient.DownloadString (IP+"/src/infomation");
			infomationForSearch = result.Split(new string[]{":"},System.StringSplitOptions.None);
		}
		using (var webClient = new System.Net.WebClient()) {
			result = webClient.DownloadString (IP+"/crs/infomation");
			infomationCarousel = result.Split(new string[]{":"},System.StringSplitOptions.None);
		}
		if (firstLoadCarousel) {

			carouselTimer = new System.Timers.Timer();
			
			// Hook up the Elapsed event for the timer. 
			carouselTimer.Elapsed += LoadNextCarousel;
			
			carouselTimer.Stop ();

			StartCoroutine (loadcrosel ());
		}
		if (!stillUpdatingLogo)
			StartCoroutine (updateLogo ());
		yield return null;
	}

	List<string> listNameCurrentBlock = new List<string> ();
	float heightCenter = 50f;
	bool isHandicapMode = false,havenextcamera = false;

	public void getRoute(string name){

		havenextcamera = false;
		float h = 0.5f;

		usedefaultlookat = true;
		Vector3 lkk = Vector3.zero;

		nameCameraPostion = name.Replace ("office", null);
		result = "\nstatic Vector3 "+currentBlock+"_"+currentFloor + name + " = new Vector3 ";
		//Debug.Log (name);
		Vector3 orgP = new Vector3 (0, 0, 0);
		Vector3 cameraPostion = new Vector3(328.19f,49.61f,260.46f);
		string namefloor = "block" + currentBlock + "_" + currentFloor;
		//Debug.Log (namefloor);
		Vector3[] list = null, list2 = new Vector3[0];
		if (namefloor == "block8_2") {

			//Debug.Log (name);
			if (isHandicapMode)
				list = block8_2Infohandicap.dictionary [name];
			else
				list = block8_2Info.dictionary [name];

			
			if (list [0] == Point8_2.evalator1)
				list2 = block8_1Info.dictionary ["thangmay1"];
			else if (list [0] == Point8_2.evalator2)
				list2 = block8_1Info.dictionary ["thangmay2"];
			else if (list [0] == Point8_2.evalator3)
				list2 = block8_1Info.dictionary ["thangmay3"];
			else if (list [0] == Point8_2.evalator4)
				list2 = block8_1Info.dictionary ["thangmay4"];
			else 
				list2 = block8_1Info.dictionary ["cauthang"];


			listpoint = new Vector3[list.Length + list2.Length];

			orgP = GameObject.Find ("block8_1").transform.position;

			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}

			orgP = GameObject.Find (namefloor).transform.position;


			cameraPostion = block8_1Info.PositnCamera ["office1"];
			lkk = block8_1Info.LookatCamera ["office1"];
			usedefaultlookat = false;
			
			if (block8_2Info.LookatCamera.ContainsKey (name)) {
				
				posss = block8_2Info.PositnCamera [name];
				lattt = block8_2Info.LookatCamera [name];
				havenextcamera = true;
				//usedefaultlookat = false;
			}

		} else if (namefloor == "block8_1") {
			heightCenter = 0f;
			list = block8_1Info.dictionary [name];
			listpoint = new Vector3[list.Length];
			orgP = GameObject.Find (namefloor).transform.position;

			cameraPostion = block8_1Info.PositnCamera [name];

			lkk = block8_1Info.LookatCamera [name];
			usedefaultlookat = false;

		} else if (namefloor == "block8_3") {
			h=1f;

			if(isHandicapMode)
				list = block8_3Infohandicap.dictionary [name];
			else
				list = block8_3Info.dictionary [name];

			if(list[0] == Point8_3.evalator1)
				list2 = block8_1Info.dictionary ["thangmay1"];
			else if(list[0] == Point8_3.evalator2)
				list2 = block8_1Info.dictionary ["thangmay2"];
			else if(list[0] == Point8_3.evalator3)
				list2 = block8_1Info.dictionary ["thangmay3"];
			else if(list[0] == Point8_3.evalator4)
				list2 = block8_1Info.dictionary ["thangmay4"];
			else 
				list2 = block8_1Info.dictionary ["cauthang"];

			listpoint = new Vector3[list.Length + list2.Length];
			orgP = GameObject.Find ("block8_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			cameraPostion = block8_2Info.PositnCamera [name];
		}
		else if (namefloor == "block9_1")
        {

			list = block9_1Info.dictionary[name];
            listpoint = new Vector3[list.Length];
			cameraPostion = block9_1Info.PositnCamera[name];
			orgP = GameObject.Find(namefloor).transform.position;
			cameraPostion = block9_1Info.PositnCamera [name];
			lkk = block9_1Info.LookatCamera[name];
			usedefaultlookat = false;
		} else if (namefloor == "block7_1") {
			list = block7_1Info.dictionary [name];
			listpoint = new Vector3[list.Length];
			cameraPostion = block7_1Info.PositnCamera [name];

			orgP = GameObject.Find (namefloor).transform.position;
		}
		else if (namefloor == "block7_2") {
			list = block7_2Info.dictionary [name];

			if(list[0] == Point7_2.f1)
				list2 = block7_1Info.dictionary ["thangmay1"];
			else if(list[0] == Point7_2.f2)
				list2 = block7_1Info.dictionary ["thangmay2"];
			else if(list[0] == Point7_2.f3)
				list2 = block7_1Info.dictionary ["thangmay3"];
			else 
				list2 = block7_1Info.dictionary ["thangmay4"];

			listpoint = new Vector3[list.Length + list2.Length];
			orgP = GameObject.Find ("block7_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}

			cameraPostion = block7_2Info.PositnCamera [name];
			
			orgP = GameObject.Find (namefloor).transform.position;
		}
		else if(namefloor == "block6_4"){
			heightCenter = -30f;
			h = 0.5f;
			
			if(!isHandicapMode)
				list = block6_4Infohandicap.dictionary [name];
			else
				list = block6_4Info.dictionary[name];

			if(list[0] == Point6_4.evalator1)
				list2 = block6_1Info.dictionary ["thangmay1"];
			else if(list[0] == Point6_4.evalator2)
				list2 = block6_1Info.dictionary ["thangmay2"];
			else if(list[0] == Point6_4handicap.evalator1)
				list2 = block6_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point6_4handicap.evalator2)
				list2 = block6_1Info.dictionary ["thangkeo2"];
			else if(list[0] == Point6_4handicap.evalator3)
				list2 = block6_1Info.dictionary ["thangkeo3"];

			listpoint = new Vector3[list.Length + list2.Length];

			orgP = GameObject.Find ("block6_1").transform.position;

			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;

			cameraPostion = block6_4Info.PositnCamera [name];
		} 
		else if(namefloor == "block6_3"){
			h = 1.5f;
			if(!isHandicapMode)
				list = block6_3Infohandicap.dictionary [name];
			else
			list = block6_3Info.dictionary[name];//
			
			if(list[0] == Point6_3.evalator1)//
				list2 = block6_1Info.dictionary ["thangmay1"];
			else if(list[0] == Point6_3.evalator2)
				list2 = block6_1Info.dictionary ["thangmay2"];
			else if(list[0] == Point6_3handicap.evalator1)
				list2 = block6_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point6_3handicap.evalator2)
				list2 = block6_1Info.dictionary ["thangkeo2"];
			else if(list[0] == Point6_3handicap.evalator3)
				list2 = block6_1Info.dictionary ["thangkeo3"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block6_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			cameraPostion = block6_3Info.PositnCamera [name];
		}
		else if(namefloor == "block6_2"){
			h = 0.5f;
			if(!isHandicapMode)
				list = block6_2Infohandicap.dictionary [name];
			else
			list = block6_2Info.dictionary[name];//
			
			if(list[0] == Point6_2.evalator1)//
				list2 = block6_1Info.dictionary ["thangmay1"];
			else if(list[0] == Point6_2.evalator2)
				list2 = block6_1Info.dictionary ["thangmay2"];
			else if(list[0] == Point6_2handicap.evalator1)
				list2 = block6_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point6_2handicap.evalator2)
				list2 = block6_1Info.dictionary ["thangkeo2"];
			else if(list[0] == Point6_2handicap.evalator3)
				list2 = block6_1Info.dictionary ["thangkeo3"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block6_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			cameraPostion = block6_2Info.PositnCamera [name];
		}
		else if(namefloor == "block5_4"){
			h = 0.5f;
			if(!isHandicapMode)
				list = block5_4Infohandicap.dictionary [name];
			else
				list = block5_4Info.dictionary[name];

			if(list[0] == Point5_4handicap.evalator1)
				list2 = block5_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point5_4handicap.evalator2)
				list2 = block5_1Info.dictionary ["thangkeo2"];
			else
				list2 = block5_1Info.dictionary ["thangmay"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block5_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			cameraPostion = block5_4Info.PositnCamera [name];
		}
		else if(namefloor == "block5_3"){
			h = 0.5f;
			if(!isHandicapMode)
				list = block5_3Infohandicap.dictionary [name];
			else
				list = block5_3Info.dictionary[name];//
			
			if(list[0] == Point5_3handicap.evalator1)
				list2 = block5_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point5_3handicap.evalator2)
				list2 = block5_1Info.dictionary ["thangkeo2"];
			else
				list2 = block5_1Info.dictionary ["thangmay"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block5_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			cameraPostion = block5_3Info.PositnCamera [name];
		}
		else if(namefloor == "block5_2"){
			h = 0.5f;
			if(!isHandicapMode)
				list = block5_2Infohandicap.dictionary [name];
			else
				list = block5_2Info.dictionary[name];//
			
			if(list[0] == Point5_2handicap.evalator1)
				list2 = block5_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point5_2handicap.evalator2)
				list2 = block5_1Info.dictionary ["thangkeo2"];
			else
				list2 = block5_1Info.dictionary ["thangmay"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block5_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;			
			
			cameraPostion = block5_2Info.PositnCamera [name];
		}
		else if(namefloor == "block4_4"){
			h = 0.5f;
			if(!isHandicapMode)
				list = block4_4Infohandicap.dictionary [name];
			else
				list = block4_4Info.dictionary[name];//
			
			if(list[0] == Point4_4handicap.evalator1)
				list2 = block4_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point4_4handicap.evalator2)
				list2 = block4_1Info.dictionary ["thangkeo2"];
			else
				list2 = block4_1Info.dictionary ["thangmay"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block4_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;

			cameraPostion = block4_4Info.PositnCamera [name];
			
		}
		else if(namefloor == "block4_3"){
			h = 0.5f;
			if(!isHandicapMode)
				list = block4_3Infohandicap.dictionary [name];
			else
				list = block4_3Info.dictionary[name];//
			
			if(list[0] == Point4_3handicap.evalator1)
				list2 = block4_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point4_3handicap.evalator2)
				list2 = block4_1Info.dictionary ["thangkeo2"];
			else
				list2 = block4_1Info.dictionary ["thangmay"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block4_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			cameraPostion = block4_3Info.PositnCamera [name];
			
		}
		else if(namefloor == "block4_2"){
			h = 0.5f;

			if(!isHandicapMode)
				list = block4_2Infohandicap.dictionary [name];
			else
				list = block4_2Info.dictionary[name];//
			
			if(list[0] == Point4_2handicap.evalator1)
				list2 = block4_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point4_2handicap.evalator2)
				list2 = block4_1Info.dictionary ["thangkeo2"];
			else
				list2 = block4_1Info.dictionary ["thangmay"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block4_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			cameraPostion = block4_2Info.PositnCamera [name];
			
		}
		else if(namefloor == "block3_4" || namefloor == "block1_4"){
			h = 0.5f;

			if(!isHandicapMode)
				list = block3_4Infohandicap.dictionary [name];
			else
				list = block3_4Info.dictionary[name];//
			
			if(list[0] == Point3_4handicap.evalator1)
				list2 = block3_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point3_4handicap.evalator2)
				list2 = block3_1Info.dictionary ["thangkeo2"];
			else
				list2 = block3_1Info.dictionary ["thangmay"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block"+namefloor[5]+"_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			cameraPostion = block3_4Info.PositnCamera [name];
			lkk = block3_4Info.LookatCamera[name];
			usedefaultlookat = false;
			
		}
		else if(namefloor == "block3_3" || namefloor == "block1_3"){
			h = 0.5f;

			if(!isHandicapMode)
				list = block3_3Infohandicap.dictionary [name];
			else
				list = block3_3Info.dictionary[name];//
			
			if(list[0] == Point3_3handicap.evalator1)
				list2 = block3_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point3_3handicap.evalator2)
				list2 = block3_1Info.dictionary ["thangkeo2"];
			else
				list2 = block3_1Info.dictionary ["thangmay"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block"+namefloor[5]+"_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			cameraPostion = block3_3Info.PositnCamera [name];
			lkk = block3_3Info.LookatCamera[name];
			usedefaultlookat = false;
		}
		else if(namefloor == "block3_2" || namefloor == "block2_2" || namefloor == "block1_2"){

			h = 0.5f;
			
			if(!isHandicapMode)
				list = block3_2Infohandicap.dictionary [name];
			else
				list = block3_2Info.dictionary[name];//
			
			if(list[0] == Point3_2handicap.evalator1)
				list2 = block3_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point3_2handicap.evalator2)
				list2 = block3_1Info.dictionary ["thangkeo2"];
			else
				list2 = block3_1Info.dictionary ["thangmay"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block"+namefloor[5]+"_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;

			cameraPostion = block3_2Info.PositnCamera [name];
			
			lkk = block3_2Info.LookatCamera[name];
			usedefaultlookat = false;
		}
		else if(namefloor == "block2_4"){
			h = 0.5f;
			if(!isHandicapMode)
				list = block2_4Infohandicap.dictionary [name];
			else
				list = block2_4Info.dictionary[name];//


			if(list[0] == Point2_4handicap.evalator1)
				list2 = block3_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point2_4handicap.evalator2)
				list2 = block3_1Info.dictionary ["thangkeo2"];
			else
				list2 = block3_1Info.dictionary ["thangmay"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block2_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			cameraPostion = block2_4Info.PositnCamera [name];
			
			lkk = block2_4Info.LookatCamera[name];
			usedefaultlookat = false;
		}
		else if(namefloor == "block2_3"){
			h = 0.5f;
			if(!isHandicapMode)
				list = block2_3Infohandicap.dictionary [name];
			else
				list = block2_3Info.dictionary[name];//
			
			
			if(list[0] == Point2_3handicap.evalator1)
				list2 = block3_1Info.dictionary ["thangkeo1"];
			else if(list[0] == Point2_3handicap.evalator2)
				list2 = block3_1Info.dictionary ["thangkeo2"];
			else
				list2 = block3_1Info.dictionary ["thangmay"];
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block2_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * (new Vector3 (list2 [i].x, h, list2 [i].z)) + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			cameraPostion = block2_3Info.PositnCamera [name];
			lkk = block2_3Info.LookatCamera[name];
			usedefaultlookat = false;
		}


		for (int i = 0; i<(list.Length); i++) {			
			listpoint [i+list2.Length] = ratetio*(new Vector3 (list [i].x, h, list [i].z)) + orgP;
		}
		GameObject.Find ("startPoint").transform.position = listpoint [0];
		GameObject.Find ("printpoint").transform.position = listpoint [listpoint.Length - 1];
		GameObject endpoint = GameObject.Find ("containAnimation");

		endpoint.transform.position = new Vector3 (listpoint [listpoint.Length - 1].x, listpoint [listpoint.Length - 1].y, listpoint [listpoint.Length - 1].z);

		Vector3 start =listpoint [0]; 
		Vector3 trg = start;
		for (int i=1; i<listpoint.Length; i++) {
			create_vessel (start, listpoint [i], i);
			start = listpoint [i];
			trg += start;
		}
		trg.y = trg.y + heightCenter;
		//Debug.Log (trg / listpoint.Length);
		if (usedefaultlookat)
			setCamera (cameraPostion, trg / listpoint.Length);
		else setCamera (cameraPostion, lkk);
		countdown = 0;
	}
	
	void showTransparent(string name, float height){

		GameObject ga = GameObject.Find (name);
		ga.transform.position = new Vector3 (ga.transform.position.x, height, ga.transform.position.z);

	}

	void showFullTransparent(string name, float height){
		GameObject ga = GameObject.Find (name);
		ga.transform.position = new Vector3 (ga.transform.position.x, height, ga.transform.position.z);
	}

	string nameOfBlockTransparent = null;

	void hideSecondBlock (){
		if (nameOfBlockTransparent != null) {
			hideBlck (8,2);
			nameOfBlockTransparent=null;
		}
	}

	void setCamera(Vector3 postion, Vector3 lookAt){
		/*Camera.main.transform.position = postion;
		Camera.main.transform.LookAt (lookAt);*/
		StartCoroutine(LerpToPosition(transitionDuration, postion, lookAt)); 
		target = lookAt;
	}
	float speedRotate = 20f;
	Vector3 target;
	public void arroundLeft(){
		Camera.main.transform.LookAt (target);
		Camera.main.transform.RotateAround (target, Vector3.up, speedRotate * Time.deltaTime);
	}
	public void arroundRight(){
		Camera.main.transform.LookAt (target);
		Camera.main.transform.RotateAround (target, Vector3.down, speedRotate * Time.deltaTime);
	}
	public void arroundUp(){
		if (Vector3.Angle (Camera.main.transform.up, Vector3.up) < 85) {
			Camera.main.transform.LookAt (target);
			Camera.main.transform.RotateAround (target, Camera.main.transform.right, speedRotate * Time.deltaTime);
		}
	}
	public void arroundDown(){
		if (Vector3.Angle (Camera.main.transform.up, Vector3.up) > 5) {
			Camera.main.transform.LookAt (target);
			Camera.main.transform.RotateAround (target, -Camera.main.transform.right, speedRotate * Time.deltaTime);
		}
	}
	public void cameraForward(){
		Vector3 forward = new Vector3 (Camera.main.transform.forward.x, Camera.main.transform.forward.y, Camera.main.transform.forward.z);
		Camera.main.transform.Translate (forward * -5);
	}
	public void cameraBackward(){
		Camera.main.transform.RotateAround (target, -Camera.main.transform.right, speedRotate * Time.deltaTime);
	}

	void hideSearchBlock(){
		foreach (string x in listNameCurrentBlock) {
			//Debug.Log(x);
			hideBlck(x);
		}
		listNameCurrentBlock.Clear ();
	}

	public void OnNextButtonEvent(){
		officeClick (null);
	}

    bool showRouteBettwenBlock = false;
    string nameOfSearchBlock,routeBettwenBlock;
	
	public void officeClick(Button name){
		string blcName;

		if (name != null) {
			blcName = name.image.sprite.name;
			//Debug.Log(blcName);
			if(blcName.IndexOf("b8")<0)
			{
				showButton(NextBtn);
				nameOfSearchBlock = blcName;
				blcName = "b81231";
				showRouteBettwenBlock = true;
				routeBettwenBlock = "b91"+nameOfSearchBlock[1];
			}
		}else if(showRouteBettwenBlock){
			blcName = routeBettwenBlock;
			showRouteBettwenBlock = false;
		}else {
			blcName = nameOfSearchBlock;
			madeButtonTransparent(NextBtn);
		}

		hideSearchBlock ();

		stopRoute ();
		
		showButton (btnLeft);
		showButton (btnRight);
		showButton (btnDown);
		showButton (btnUp);

		hideBlck (currentBlock, currentFloor);

		int Block = int.Parse (blcName [1].ToString ());
		int Floor = int.Parse (blcName [2].ToString ());
		
		string nameBlock = "block" + Block + "_" + Floor;


		if (Floor > 1) {
			float height = 36 / (Floor - 1);
			for (int i=2; i<Floor; i++) {
				string n = "block" + Block + "_" + i + "transparent";
				showFullTransparent (n, height * (i - 1));
				listNameCurrentBlock.Add (n);
			}
			if (Floor > 1) {
				showTransparent (nameBlock, 36);
				listNameCurrentBlock.Add (nameBlock);
			}
		}

		showBlck (Block, 1);

		listNameCurrentBlock.Add ("block"+Block + "_1");

		currentBlock = Block;
		currentFloor = Floor;

		
		getRoute ("office" + blcName.Substring (3));

		showLine ();
		//showSearch = true;

		hideFullTransparent ();
		//int org = currentIndex - maxOffice;
		/*if(org<0)
			org = ((int)TextureBtn.Count / maxOffice) * maxOffice;*/
		searchMenu.enabled = false;
		charKeyboard.enabled = false;
		StartCoroutine (LoadVideo (IP + "/video/" + blcName + videoType));
		cleanAllOffice ();
	}
	
	void stopRoute(){
		GameObject.Find ("startPoint").transform.position = hideStartPoint;
		GameObject endpoint = GameObject.Find ("containAnimation");		
		endpoint.transform.position = hideEndPoint;
		GameObject.Find ("printpoint").transform.position = new Vector3 (0, 1000, 0);
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetVertexCount(0);
		showSearch = false;
		
		foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
		{
			if(gameObj.name == "lineDirection" || gameObj.name == "arrowsssss")
			{
				Destroy(gameObj);
			}
		}
	}

	
	public void showBlock(string name){
		stopRoute ();
		hideSecondBlock ();
		hideBlck (currentBlock, currentFloor);
		//showBlck (name);
		currentBlock = int.Parse (name [5].ToString ());
		currentFloor = int.Parse (name [7].ToString ());
		gotoFloor1 ();
		/*floorSelector.sprite = Resources.Load<Sprite> ("block" + currentBlock + "_" + currentFloor);
		/enableAllfloor ();
		if (currentBlock == 8)
			disableFloor (3);
		else if (currentBlock < 4 || currentBlock == 7) {
			disableFloor(2);
		}*/
	}
	
	Button CreateButton(string name,Button buttonPrefab, Canvas canvas, Vector2 cornerTopRight, Vector2 cornerBottomLeft,Vector2 postion)
	{
		var button = Object.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity) as Button;
		button.name = name;
		var rectTransform = button.GetComponent<RectTransform>();
		rectTransform.SetParent(canvas.transform);
		rectTransform.anchorMax = cornerTopRight;
		rectTransform.anchorMin = cornerBottomLeft;
		rectTransform.offsetMax = Vector2.zero;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.localPosition = postion;//new Vector3 (100, 100, 100);
		return button;
	}
	
	float indexofbutton = 0f;
	
	int maxNumberOffice = 6;
	
	private Vector3 getNextPostion()
	{
		int y = (int)indexofbutton / maxNumberOffice;
		int x = (int)((indexofbutton % maxNumberOffice));
		indexofbutton += 1;
		return new Vector3 (-500 + x * 200, 200 - y * 150, 0);
	}
	
	void cleanAllOffice(){
		currentIndex = 0;
		cleanTexture ();
		for (int i = 0; i<maxOffice; i++) {
			var plane = GameObject.Find ("Btn" + i).GetComponent<Button> ();
			Color c = plane.targetGraphic.color;
			c.a = 0f;
			plane.targetGraphic.color = c;			
			plane.enabled=false;
			
			
			var img = GameObject.Find ("p"+i).GetComponent<Image> ();
			img.enabled = false;
			
			var t = GameObject.Find ("of"+i).GetComponent<Text> ();
			t.enabled = false;
		}
	}
	
	void showFullTransparent(){
		GameObject.Find ("backgroundtransparent").GetComponent<Image> ().enabled = true;
		GameObject.Find ("carImg").GetComponent<Image> ().enabled = false;
		GameObject.Find ("Imgsearch").GetComponent<Image> ().enabled = false;
		GameObject.Find ("leftImg").GetComponent<Image> ().enabled = false;
	}
	
	void hideFullTransparent(){
		GameObject.Find ("backgroundtransparent").GetComponent<Image> ().enabled = false;
		GameObject.Find ("carImg").GetComponent<Image> ().enabled = true;
		GameObject.Find ("Imgsearch").GetComponent<Image> ().enabled = true;
		GameObject.Find ("leftImg").GetComponent<Image> ().enabled = true;
	}
	
	public void searchOffice(char name){
		charKeyboard.enabled = false;
		ContainResult.enabled = true;
		
		foreach (string x in infomationForSearch) {
			if(x!=""){
				string[] info = x.Split(new string[]{" "},System.StringSplitOptions.None);
				if (info[1].ToLower()[0] == name) {
					StartCoroutine(loadTexture4Office(info[0],info[1]));
				}
			}
		}
	}
	
	private void cleanTexture(){
		TextureBtn.Clear ();
		ContainResult.enabled = false;
	}

	string[] listUpdate;
	bool stillUpdatingLogo = false;

	public IEnumerator updateLogo(){
		stillUpdatingLogo = true;
		if (firstLoad) {
			foreach (string x in infomationForSearch) {
				if (x != null) {
					if (x != "") {

						string filename = x.Substring (0, x.IndexOf (" "));
						if (GameObject.Find (filename) != null) {
							StartCoroutine (updateIcon (IP + "src/" + filename + imageType, filename));
						}
						yield return new WaitForSeconds(0.1F);
					}
				}
			}
			firstLoad=false;
		} else {
			string result;
			using (var webClient = new System.Net.WebClient()) {
				result = webClient.DownloadString (IP+"/src/update");
				string[] listNewUpdate = result.Split(new string[]{":"},System.StringSplitOptions.None);
				if(listUpdate!=null){
					int numListUpdate = listUpdate.Length;
					for(int i=0;i<numListUpdate;i++)
					{
						string name = listUpdate[i];
						for(int j=0;j<listNewUpdate.Length;j++)
						{
							if(name == listNewUpdate[j]){
								listNewUpdate[j] = null;
								break;
							}
						}
					}
				}
				for(int j=0;j<listNewUpdate.Length;j++)
				{
					string x = listNewUpdate[j];
					//Debug.Log(x);
					if(x!=null){
						if (x != "") {
							string filename = x.Substring (0, x.IndexOf (" "));
							//Debug.Log(filename);
							if (GameObject.Find (filename) != null) {
								StartCoroutine (updateIcon (IP + "src/" + filename + imageType, filename));
							}
						}
					}
					yield return new WaitForSeconds(0.1F);
				}
				listUpdate = result.Split(new string[]{":"},System.StringSplitOptions.None);
			}
		}
		
		stillUpdatingLogo = false;
		yield return null;
	}

	
	private IEnumerator updateIcon(string url,string nameobject)
	{
		GameObject plane = GameObject.Find (nameobject);
		
		var rend = plane.GetComponent<Renderer>();
		
		WWW www = new WWW(url);
		yield return www;
		rend.material.mainTexture = www.texture;
		
	}

	Dictionary<string,Sprite> spriteSave = new Dictionary<string, Sprite> ();

	private IEnumerator loadTexture4Office(string name,string nameOffice)
	{
		GameObject gameobjects = GameObject.Find (name);
		if (gameObject != null) {
			Texture2D texture = (Texture2D)gameobjects.GetComponent<Renderer> ().material.mainTexture;
			Sprite sprite;
			if(!spriteSave.ContainsKey(name)){
				sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), Vector2.zero);
				spriteSave.Add(name,sprite);
			}
			else {
				sprite = spriteSave[name];
			}
			sprite.name = name;
			//TextureBtn.Add (sprite);
			if (currentIndex < maxOffice) {
				//searchMenu.GetComponent<Button>();
				
				var img = GameObject.Find ("p" + currentIndex).GetComponent<Image> ();
				img.enabled = true;
				
				var t = GameObject.Find ("of" + currentIndex).GetComponent<Text> ();
				t.enabled = true;
				
				var plane = GameObject.Find ("Btn" + currentIndex).GetComponent<Button> ();
				plane.enabled = true;
				plane.image.sprite = sprite;
				Color c = plane.targetGraphic.color;
				c.a = 255f;
				plane.targetGraphic.color = c;
				var text = GameObject.Find ("of" + currentIndex).GetComponent<Text> ();
				text.text = nameOffice;
				currentIndex++;
			}
		}
		yield return null;
	}
	
	public void next(){
		if (TextureBtn.Count > maxOffice) {
			for (int i = 0; i<maxOffice; i++) {
				if (currentIndex < TextureBtn.Count) {
					
					var img = GameObject.Find ("p"+currentIndex).GetComponent<Image> ();
					img.enabled = true;
					
					var t = GameObject.Find ("of"+currentIndex).GetComponent<Text> ();
					t.enabled = true;
					
					Sprite sprite = TextureBtn [currentIndex];
					var plane = GameObject.Find ("Btn" + i).GetComponent<Button> ();
					plane.enabled=true;
					plane.image.sprite = sprite;
					Color c = plane.targetGraphic.color;
					c.a = 255f;
					plane.targetGraphic.color = c;
					currentIndex++;
				} else {
					var img = GameObject.Find ("p"+currentIndex).GetComponent<Image> ();
					img.enabled = false;
					
					var t = GameObject.Find ("of"+currentIndex).GetComponent<Text> ();
					t.enabled = false;
					
					var plane = GameObject.Find ("Btn" + i).GetComponent<Button> ();
					Color c = plane.targetGraphic.color;
					c.a = 0f;
					plane.targetGraphic.color = c;
					plane.enabled=true;
				}
			}
			if (currentIndex >= TextureBtn.Count)
				currentIndex = 0;
		}
	}
	
	public int preIndex = 0;
	
	public void previous(){
		currentIndex = currentIndex - maxOffice;
		if (currentIndex < 0)
			currentIndex = ((int)TextureBtn.Count / maxOffice) * maxOffice;
		
		currentIndex = currentIndex - maxOffice;
		if (currentIndex < 0)
			currentIndex = ((int)TextureBtn.Count / maxOffice) * maxOffice;
		
		next ();
	}
	
	public void typeButton(Button btn){
		//input.text += btn.name;
		
		cleanAllOffice ();
		searchOffice (btn.name.ToLower () [0]);
	}
	
	public void changeLevel(){
		//Application.LoadLevel("block7");
		//GameObject instance = Instantiate(Resources.Load("block1_2.blend", typeof(GameObject)),new Vector3 (0, 1,0), Quaternion.identity) as GameObject;
		
		
	}

	int currentCarousel = 0,timeDisplay = -100;
	bool shownextCarousel = false,haveVdieonow = false,firstLoadCarousel = true;

	Dictionary<string, MovieTexture> dicMovieCarousel = new Dictionary<string, MovieTexture> ();
	Dictionary<string, Texture> dicImageCarousel = new Dictionary<string, Texture> ();


	MovieTexture movieTextureCarousel;


	
	private IEnumerator loadcrosel () {
		firstLoadCarousel = false;
		
		if (infomationCarousel [currentCarousel] != "") {
			carouselTimer.Stop();
			string[] infos = infomationCarousel [currentCarousel].Split (new string[]{" "}, System.StringSplitOptions.None);
			string filename = infos [0];
			timeDisplay = int.Parse (infos [1]);
			//Debug.Log(filename+timeDisplay);
			if (timeDisplay > 0) {
				haveVdieonow = false;
				var url = IP + "crs/"+filename;
				Texture imageTexture = null;

				if(!dicImageCarousel.ContainsKey(url)){
					WWW imageURLWWW = new WWW (url);		
					yield return imageURLWWW;		
					if (imageURLWWW.texture != null) {
						imageTexture = (Texture)imageURLWWW.texture;
					}
					dicImageCarousel.Add(url,imageTexture);
				}else {
					imageTexture = dicImageCarousel[url];
				}

				Videocarosel.texture = imageTexture;
				carouselTimer.Interval = timeDisplay*1000;
				carouselTimer.Start();
			}else {

				var url = IP + "crs/"+filename;

				if(!dicMovieCarousel.ContainsKey(url)){
					WWW www = new WWW(url);
					movieTextureCarousel = www.movie;
					while (!movieTextureCarousel.isReadyToPlay) {
						yield return null;
					}
					dicMovieCarousel.Add(url,movieTextureCarousel);
				}else {

					movieTextureCarousel = dicMovieCarousel[url];
					movieTextureCarousel.Stop();
				}
				movieTextureCarousel.loop = false;
				Videocarosel.texture = movieTextureCarousel;
				movieTextureCarousel.Play();
				haveVdieonow = true;
			}
		}
		currentCarousel++;
		currentCarousel = currentCarousel%infomationCarousel.Length;
		yield return null;
	}
	
	void zoomcamera(float deltaMagnitudeDiff){
		// If the camera is orthographic...
		if (Camera.main.orthographic)
		{
			// ... change the orthographic size based on the change in distance between the touches.
			Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
			
			// Make sure the orthographic size never drops below zero.
			Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
		}
		else
		{
			// Otherwise change the field of view based on the change in distance between the touches.
			Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
			
			// Clamp the field of view to make sure it's between 0 and 180.
			Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
		}
	}
	
	public void zoomin(){
		//zoomcamera (4);
		if (Camera.main.fieldOfView > 5)
			Camera.main.fieldOfView = Camera.main.fieldOfView - 5;
	}
	
	public void zoomout(){
		if (Camera.main.fieldOfView < 100)
			Camera.main.fieldOfView = Camera.main.fieldOfView + 5;
	}
	
	public float TargetFOV = 10f;

	Quaternion lastRotate;

	// Update is called once per frame
	
	int countdown = 0;
	
	public void showLine(){
		showSearch = true;
		LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
		//lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(c2, c2);
		lineRenderer.SetWidth(widthLinear, widthLinear);
		lineRenderer.SetVertexCount(listpoint.Length);
		for(int i = 0;i<listpoint.Length;i++)
		{
			Vector3 pos = listpoint[i];
			lineRenderer.SetPosition(i, pos);
		}
	}
	
	public void enterText(){
		charKeyboard.enabled = true;
	}
	
	float distance = 4f,deltad = 0f;

	void create_vessel(Vector3 p1, Vector3 p2, int index) {

		float d = Vector3.Distance (p1, p2);
		Vector3 v = p2 - p1;
		int num = (int)((d + deltad) / distance);
		for (int i = 1; i<=num; i++) {

			Vector3 start = p1 + (i * distance / (d + deltad)) * v;

			GameObject ar = GameObject.Instantiate (arrow)as GameObject;
			ar.name = "arrowsssss";
			arrow scri = ar.GetComponent<arrow> ();
			//scri.beginMove(new Vector3(380.287f,0.15f, 80.62f),new Vector3(373.287f, 0.2788003f, 64.50918f));
			scri.beginMove (listpoint, start, index);

			//Destroy (ar, 30);
		}
		deltad = (deltad + d) % distance;
		


		Vector3 pos = Vector3.Lerp (p1, p2, (float)0.5);
		GameObject segObj = GameObject.Instantiate (Cylinder)as GameObject;
		segObj.name = "lineDirection";
		Vector3 newScale = segObj.transform.localScale;
		newScale.y = (Vector3.Distance (p1, p2) * 1.842288f) / 3.693893f;
		newScale.x = 0.1051401f;
		newScale.z = 0.1051401f;
		segObj.transform.localScale = newScale;
		segObj.transform.position = pos;       
		segObj.transform.up = p2 - p1;
	}

	bool uppress=false,downpress=false,leftpress=false,rightpress=false;
	public void uppressed (BaseEventData eventData)
	{
		uppress = true;
	}
	public void upnotpressed(BaseEventData eventData)
	{
		uppress = false;
	}

	public void downpressed (BaseEventData eventData)
	{
		downpress = true;
	}
	public void downotpressed(BaseEventData eventData)
	{
		downpress = false;
	}

	public void leftpressed (BaseEventData eventData)
	{
		leftpress = true;
	}
	public void leftnotpressed(BaseEventData eventData)
	{
		leftpress = false;
	}

	public void rightpressed (BaseEventData eventData)
	{
		rightpress = true;
	}
	public void rightnotpressed(BaseEventData eventData)
	{
		rightpress = false;
	}
	public float transitionDuration = 3.0f;

	IEnumerator LerpToPosition(float lerpSpeed, Vector3 newPosition, Vector3 lookat)
	{   
		float t = 0.0f;
		Vector3 startingPos = Camera.main.transform.position;
		while (t < 1.0f)
		{
			t += Time.deltaTime * (Time.timeScale / lerpSpeed);



			//Camera.main.transform.position = Vector3.Lerp(startingPos, newPosition, t);
			//Camera.main.transform.LookAt(lookat);

			var targetRotation = Quaternion.LookRotation(lookat - Camera.main.transform.position, Vector3.up);
			Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, targetRotation, t); 

			yield return 0;
		}
		t = 0.0f;
		while (t < 1.0f)
		{
			t += Time.deltaTime * (Time.timeScale / lerpSpeed);			
			
			Camera.main.transform.position = Vector3.Lerp(startingPos, newPosition, t);
			Camera.main.transform.LookAt(lookat);
			
			yield return 0;
		}
		if (havenextcamera) {
			moveNextCamera.Start();
			havenextcamera = false;
		}
	}


	string cameraangle = "building_Data\\data\\camereangle.txt";
	string pointPostions = "building_Data\\data\\points.txt";
	string officePostion = "building_Data\\data\\officePostion.txt";
	string linepostion = "building_Data\\data\\line.txt";
	string result = "",resultPostion = "",frontPoints = "";
	int index = 1,blckk=7,flor=1;
	string nameCameraPostion;
	bool usedefaultlookat = true;


	void Update () {
		if (leftpress || Input.GetKey(KeyCode.A)) {
			arroundLeft();
		}else if (rightpress || Input.GetKey(KeyCode.D)) {
			arroundRight();
		}else if (uppress) {
			arroundUp();
		}else if (downpress) {
			arroundDown();
		}
		
		if (update) {

			StartCoroutine(sysServer());
			update = false;
		}
		if (shownextCarousel) {
			StartCoroutine(loadcrosel());
			shownextCarousel = false;
		}

		if (haveVdieonow) {
			if(!movieTextureCarousel.isPlaying){

				StartCoroutine(loadcrosel());

			}
		}

		if (Input.GetKey (KeyCode.Z)) {
			Vector3 p = Camera.main.transform.position;
			result += p.ToString () + ";";

			result += "\nstatic Vector3 "+currentBlock+"_"+currentFloor+"lookat" + nameCameraPostion + " = new Vector3 "+target.ToString()+";";

			writetofile.append2File(cameraangle,result);
			result="";
		}
		
		if (Input.GetKey (KeyCode.X)) {
			/*
			for(int i = 1;i<5;i++){
				GameObject x = GameObject.Find("b71"+i);
				if(x!=null){
					
					resultPostion +="\nstatic Vector3 o"+i+" = new Vector3 "+ (x.transform.position - GameObject.Find("block7_1").transform.position).ToString () + ";";
				}
			}
			writetofile.append2File(pointPostions,resultPostion);
			resultPostion="";
*/
			Vector3 p = cube.transform.position - GameObject.Find("block8_3").transform.position;
			resultPostion ="\nstatic Vector3 p"+index+" = new Vector3 "+ p.ToString () + ";";
			writetofile.append2File(pointPostions,resultPostion);
			index++;
			resultPostion="";
/*
			string line;
			string re = "";
			
			// Read the file and display it line by line.
			Vector3 p = -GameObject.Find("block8_3").transform.position;// - GameObject.Find("block9_1").transform.position;
			System.IO.StreamReader file = 
				new System.IO.StreamReader("C:\\Users\\Nguyen Phong\\Downloads\\unity\\test2\\building_Data\\data\\points.txt");
			while((line = file.ReadLine()) != null)
			{
				int begin = line.IndexOf("(");
				if(begin>0){
					int end = line.IndexOf(")");
					string v = line.Substring(0,begin);
					string li = line.Substring(begin+1,end-begin-1);
					string[] vector = li.Split(new string[]{"F"},System.StringSplitOptions.None);
					Vector3 newP = new Vector3(float.Parse(vector[0]),float.Parse(vector[1]),float.Parse(vector[2]))+ p;
					re+=v+newP+";\n";
				}
			}
			
			file.Close();
			writetofile.write2File("C:\\Users\\Nguyen Phong\\Downloads\\unity\\test2\\building_Data\\data\\re.txt",re);*/
		}

		if (Input.GetKey (KeyCode.C)) {
			float delta = 4.31f;
			for(int i = 1;i<67;i++){
				GameObject x = GameObject.Find("b"+blckk+flor+i);
				if(x!=null){
					Vector3 p = x.transform.position - GameObject.Find("block"+blckk+"_"+flor).transform.position;
					resultPostion +="\nstatic Vector3 o"+i+" = new Vector3 "+ p.ToString () + ";";

					if((i>0 && i<6) || (i>22 && i<28) ||(i==44 || i==59))
					{
						frontPoints+="\nstatic Vector3 f"+i+" = new Vector3 "+ (p-new Vector3(0,0,delta)).ToString () + ";";
					}
					else if((i>6 && i<11) || (i>28 && i<33))
					{
						frontPoints +="\nstatic Vector3 f"+i+" = new Vector3 "+ (p-new Vector3(-delta,0,0)).ToString () + ";";
					}
					else if((i>10 && i<17) || (i>33 && i<39))
					{
						frontPoints +="\nstatic Vector3 f"+i+" = new Vector3 "+ (p-new Vector3(0,0,-delta)).ToString () + ";";
					}
					else if((i>17 && i<22) || (i>39 && i<44) || (i>54 && i<59))
					{
						frontPoints +="\nstatic Vector3 f"+i+" = new Vector3 "+ (p-new Vector3(delta,0,0)).ToString () + ";";
					}
				}
			}
			writetofile.append2File(officePostion,resultPostion);
			writetofile.append2File(pointPostions,frontPoints);
		}

		if(Input.GetKey(KeyCode.S))
		{
			Camera.main.transform.LookAt(target);
			Camera.main.transform.Translate(Camera.main.transform.forward*0.75f);
		}
		else if(Input.GetKey(KeyCode.W))
		{
			Camera.main.transform.LookAt(target);
			Camera.main.transform.Translate(Camera.main.transform.forward*-0.75f);
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			target += new Vector3(-4f * Time.deltaTime,0,0);
			Camera.main.transform.Translate(new Vector3(4f * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			target += new Vector3(4f * Time.deltaTime,0,0);
			Camera.main.transform.Translate(new Vector3(-4f * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			target += new Vector3(0,-4f * Time.deltaTime,0);
			Camera.main.transform.Translate(new Vector3(0,-4f * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			target += new Vector3(0,4* Time.deltaTime,0);
			Camera.main.transform.Translate(new Vector3(0,4* Time.deltaTime,0));
		}

		if (beginmovetonextcamera) {
			setCamera(posss,lattt);
			beginmovetonextcamera = false;
		}

		if (showSearch) {
			if (countdown < 0) {
				countdown = 20;
				GameObject ar = GameObject.Instantiate (arrow)as GameObject;
				ar.name = "arrowsssss";
				arrow scri = ar.GetComponent<arrow> ();
				//scri.beginMove(new Vector3(380.287f, 0.15f, 80.62f),new Vector3(373.287f, 0.2788003f, 64.50918f));
				scri.beginMove (listpoint);
				//Destroy (ar, 30);
				
			} else
				countdown--;
		}
	}
}

