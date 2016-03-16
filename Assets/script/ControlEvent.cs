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
	public Button searchBtn;
	public Button reservedBtn;
	public Button numSearchBtn;
	public Button bathroomSearchBtn;
	public Button segmentSearchBtn;
	public Button resizeVideo;
	public Button exitViedo;
	public Button NextBtn;
	public RawImage Videocarosel;
	public RawImage VideoDirection;
	public Text showTime;
	public Text floorOfficeOn;
	public Text officePhoneNumber;
	public Text officeShowName;
	public Image officeLogo;
	public Canvas contain1;
	public Canvas contain2;
	public Canvas contain3;
	public Canvas evnt1;
	public Canvas evnt2;
	public Canvas evnt3;

	//public GameObject startAnimation;
	public GameObject endAnimation;
	public GameObject printPoint;

	//public GameObject flatStart;

	public Material yellowTarget;

	public GameObject cube;

	public Image floorSelector;
	public Image blockSelectorimg;
	public Image headerImg;
	public static string currentLanguage = null;

	static public string eventSpriteName = "eventbtn";

	string[] nameOfAllResource = new string[]{"3_1","3_1handi","3_2","3_2handi","3_3","3_3handi","3_4",
		"3_4handi","6_1","6_1handi","6_2","6_2handi","6_3","6_3handi","6_4","6_4handi","7_1",
		"7_1handi","7_2","7_2handi","8_1","8_1handi","8_2","8_2handi","8_3","8_3handi","101",
		"101handi","102","102handi","103","103handi","104","104handi","105","105handi","106",
		"106handi","107","107handi","108","108handi","109","109handi","110","110handi","111",
		"111handi","112","112handi","113","113handi","114","114handi","115","115handi","116",
		"116handi","117","117handi","118","118handi","121","121handi","admin","aesthencs","archite",
		"201","201handi","202","202handi","203","203handi","204","204handi","205","205handi",
		"206","206handi","207","207handi","208","208handi","209","209handi","210","210handi",
		"211","211handi","212","212handi","213","213handi","214","214handi","215","215handi",
		"216","216handi","217","217handi","218","218handi","219","219handi","220","220handi",
		"301","301handi","302","302handi","303","303handi","304","304handi","305","305handi",
		"306","306handi","307","307handi","308","308handi","309","309handi","310","310handi",
		"311","311handi","312","312handi","313","313handi","314","314handi","315","315handi",
		"316","316handi","317","317handi","318","318handi","319","319handi","320","320handi","321","321handi",
		"101-166","101-166handi","201-266","201-266handi","301-348","301-348handi","101-144","101-144handi","201-244","201-244handi",
		"301-332","301-332handi","handicap","backgroundevnthandi","backgroundevnt","eventDateBackgroundhandi","eventDateBackground",
		"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
		"Ahandi","Bhandi","Chandi","Dhandi","Ehandi","Fhandi","Ghandi","Hhandi","Ihandi","Jhandi","Khandi","Lhandi","Mhandi","Nhandi",
		"Ohandi","Phandi","Qhandi","Rhandi","Shandi","Thandi","Uhandi","Vhandi","Whandi","Xhandi","Yhandi","Zhandi",
		"art","atoz","atozhandi","bank","bathroom","bathroomhandi","block1","block1handi",
		"block2","block2handi","block3","block3handi","block4","block4handi","block5","block5handi","block6","block6handi",
		"block7","block7handi","block8","block8handi","blockselector","blockselectorhandi","brokers","close","closehandi","commer",
		"electric","energy","eventbtn","eventbtnhandi","events","financial","gastronomy",
		"hair","home","import","inst","jewelry","kidfashtion","kisoksstore","law","lingerie","logist",
		"mainImgex","manage","manfashtion","market","masterbigbutton","masterbigbuttonhandi","mobile","natural","next","nextbackground","nextbackgroundhandi",
		"nexthandicap","normalbigbutton","normalbigbuttonhandi","number","numberhandi","officeInfomationBackground","officeInfomationBackgroundhandi","optical","others","party","petshop",
		"previous","previoushandicap","segment","segmenthandi","selectorletterarrow","selectorletterarrowhandi","selectorblockarrow","selectorblockarrowhandi","selectornumberarrow","selectornumberarrowhandi",
		"selectorsegmentarrow","selectorsegmentarrowhandi","selectorofficearrow","selectorofficearrowhandi",
		"selectorstorearrow","selectorstorearrowhandi","services","shoe",
		"sport","studios","supliers","tech","transp","travel","unisexfashtion","videoFrameBar","videoFrameBarhandi","womenfashtion",
		"eventbtnsmall","eventbtnsmallhandi","construct","flonculture","medic",
		"aesthencshandi","arthandi","architehandi","bankhandi","brokershandi",
		"commerhandi","constructhandi","electrichandi","energyhandi","eventshandi",
		"womenfashtionhandi","manfashtionhandi","kidfashtionhandi","unisexfashtionhandi","financialhandi",
		"flonculturehandi","gastronomyhandi","hairhandi","homehandi","importhandi",
		"insthandi","jewelryhandi","kisoksstorehandi","lawhandi","lingeriehandi",
		"logisthandi","managehandi","markethandi","medichandi","mobilehandi",
		"naturalhandi","opticalhandi","othershandi","partyhandi","petshophandi",
		"serviceshandi","shoehandi","sporthandi","studioshandi","supliershandi",
		"techhandi","transphandi","travelhandi","adminhandi",
		"media", "barber", "baza", "beachw", "cowork",
		"consul","course", "digit", "podia", "xerox",
		"telecom", "appli", "adult",
		"mediahandi", "barberhandi", "bazahandi", "beachwhandi", "coworkhandi", "consulhandi",
		"coursehandi", "digithandi", "podiahandi", "xeroxhandi", "telecomhandi",
		"applihandi", "adulthandi",
		"submedicacup", "submedicangi", "submediccard", "submedicplas", "submedicdoct",
		"submedicdema", "submedicspee", "submedichome", "submedicneur", "submedicnutr",
		"submedicobst", "submedicdent", "submedicopht", "submedicorto", "submedicorth",
		"submedicotor", "submedicpulm", "submedicpsyc", "submedicpendia", "submedicsurge",
		"submedicexams",
		"submedicacuphandi", "submedicangihandi", "submediccardhandi", "submedicplashandi", "submedicdocthandi",
		"submedicdemahandi", "submedicspeehandi", "submedichomehandi", "submedicneurhandi", "submedicnutrhandi",
		"submedicobsthandi", "submedicdenthandi", "submedicophthandi", "submedicortohandi", "submedicorthhandi",
		"submedicotorhandi", "submedicpulmhandi", "submedicpsychandi", "submedicpendiahandi", "submedicsurgehandi",
		"submedicexamshandi",
		"brazil3_1","brazil3_1handi","brazil3_2","brazil3_2handi","brazil3_3","brazil3_3handi","brazil3_4",
		"brazil3_4handi","brazil6_1","brazil6_1handi","brazil6_2","brazil6_2handi","brazil6_3","brazil6_3handi","brazil6_4","brazil6_4handi","brazil7_1",
		"brazil7_1handi","brazil7_2","brazil7_2handi","brazil8_1","brazil8_1handi","brazil8_2","brazil8_2handi","brazil8_3","brazil8_3handi",
		"braziladmin","brazilaesthencs","brazilarchite",
		"brazilart","brazilatoz","brazilatozhandi","brazilbank","brazilbathroom","brazilbathroomhandi","brazilblock1","brazilblock1handi",
		"brazilblock2","brazilblock2handi","brazilblock3","brazilblock3handi","brazilblock4","brazilblock4handi","brazilblock5","brazilblock5handi","brazilblock6","brazilblock6handi",
		"brazilblock7","brazilblock7handi","brazilblock8","brazilblock8handi","brazilblockselector","brazilblockselectorhandi","brazilbrokers","brazilcommer",
		"brazilelectric","brazilenergy","brazileventbtn","brazileventbtnhandi","brazilevents","brazilfinancial","brazilgastronomy",
		"brazilhair","brazilhome","brazilimport","brazilinst","braziljewelry","brazilkidfashtion","brazilkisoksstore","brazillaw","brazillingerie","brazillogist",
		"brazilmanage","brazilmanfashtion","brazilmarket","brazilmobile","brazilnatural",
		"brazilnumber","brazilnumberhandi","braziloptical","brazilothers","brazilparty","brazilpetshop",
		"brazilsegment","brazilsegmenthandi","brazilselectorletterarrow","brazilselectorletterarrowhandi","brazilselectorblockarrow","brazilselectorblockarrowhandi","brazilselectornumberarrow","brazilselectornumberarrowhandi",
		"brazilselectorsegmentarrow","brazilselectorsegmentarrowhandi","brazilselectorofficearrow","brazilselectorofficearrowhandi",
		"brazilselectorstorearrow","brazilselectorstorearrowhandi","brazilservices","brazilshoe",
		"brazilsport","brazilstudios","brazilsupliers","braziltech","braziltransp","braziltravel","brazilunisexfashtion","brazilwomenfashtion",
		"brazileventbtnsmall","brazileventbtnsmallhandi","brazilconstruct","brazilflonculture","brazilmedic",
		"brazilaesthencshandi","brazilarthandi","brazilarchitehandi","brazilbankhandi","brazilbrokershandi",
		"brazilcommerhandi","brazilconstructhandi","brazilelectrichandi","brazilenergyhandi","brazileventshandi",
		"brazilwomenfashtionhandi","brazilmanfashtionhandi","brazilkidfashtionhandi","brazilunisexfashtionhandi","brazilfinancialhandi",
		"brazilflonculturehandi","brazilgastronomyhandi","brazilhairhandi","brazilhomehandi","brazilimporthandi",
		"brazilinsthandi","braziljewelryhandi","brazilkisoksstorehandi","brazillawhandi","brazillingeriehandi",
		"brazillogisthandi","brazilmanagehandi","brazilmarkethandi","brazilmedichandi","brazilmobilehandi",
		"brazilnaturalhandi","brazilopticalhandi","brazilothershandi","brazilpartyhandi","brazilpetshophandi",
		"brazilserviceshandi","brazilshoehandi","brazilsporthandi","brazilstudioshandi","brazilsupliershandi",
		"braziltechhandi","braziltransphandi","braziltravelhandi","braziladminhandi","brazilhandicap","brazilnextbackground","brazilnextbackgroundhandi",
		"brazilmedia", "brazilbarber", "brazilbaza", "brazilbeachw", "brazilcowork", "brazilconsul",
		"brazilcourse", "brazildigit", "brazilpodia", "brazilxerox", "braziltelecom",
		"brazilappli", "braziladult",
		"brazilmediahandi", "brazilbarberhandi", "brazilbazahandi", "brazilbeachwhandi", "brazilcoworkhandi", "brazilconsulhandi",
		"brazilcoursehandi", "brazildigithandi", "brazilpodiahandi", "brazilxeroxhandi", "braziltelecomhandi",
		"brazilapplihandi", "braziladulthandi",
		"brazilsubmedicacup", "brazilsubmedicangi", "brazilsubmediccard", "brazilsubmedicplas", "brazilsubmedicdoct",
		"brazilsubmedicdema", "brazilsubmedicspee", "brazilsubmedichome", "brazilsubmedicneur", "brazilsubmedicnutr",
		"brazilsubmedicobst", "brazilsubmedicdent", "brazilsubmedicopht", "brazilsubmedicorto", "brazilsubmedicorth",
		"brazilsubmedicotor", "brazilsubmedicpulm", "brazilsubmedicpsyc", "brazilsubmedicpendia", "brazilsubmedicsurge",
		"brazilsubmedicexams",
		"brazilsubmedicacuphandi", "brazilsubmedicangihandi", "brazilsubmediccardhandi", "brazilsubmedicplashandi", "brazilsubmedicdocthandi",
		"brazilsubmedicdemahandi", "brazilsubmedicspeehandi", "brazilsubmedichomehandi", "brazilsubmedicneurhandi", "brazilsubmedicnutrhandi",
		"brazilsubmedicobsthandi", "brazilsubmedicdenthandi", "brazilsubmedicophthandi", "brazilsubmedicortohandi", "brazilsubmedicorthhandi",
		"brazilsubmedicotorhandi", "brazilsubmedicpulmhandi", "brazilsubmedicpsychandi", "brazilsubmedicpendiahandi", "brazilsubmedicsurgehandi",
		"brazilsubmedicexamshandi",
		"spanish3_1","spanish3_1handi","spanish3_2","spanish3_2handi","spanish3_3","spanish3_3handi","spanish3_4",
		"spanish3_4handi","spanish6_1","spanish6_1handi","spanish6_2","spanish6_2handi","spanish6_3","spanish6_3handi","spanish6_4","spanish6_4handi","spanish7_1",
		"spanish7_1handi","spanish7_2","spanish7_2handi","spanish8_1","spanish8_1handi","spanish8_2","spanish8_2handi","spanish8_3","spanish8_3handi",
		"spanishadmin","spanishaesthencs","spanisharchite",
		"spanishart","spanishatoz","spanishatozhandi","spanishbank","spanishbathroom","spanishbathroomhandi","spanishblock1","spanishblock1handi",
		"spanishblock2","spanishblock2handi","spanishblock3","spanishblock3handi","spanishblock4","spanishblock4handi","spanishblock5","spanishblock5handi","spanishblock6","spanishblock6handi",
		"spanishblock7","spanishblock7handi","spanishblock8","spanishblock8handi","spanishblockselector","spanishblockselectorhandi","spanishbrokers","spanishcommer",
		"spanishelectric","spanishenergy","spanisheventbtn","spanisheventbtnhandi","spanishevents","spanishfinancial","spanishgastronomy",
		"spanishhair","spanishhome","spanishimport","spanishinst","spanishjewelry","spanishkidfashtion","spanishkisoksstore","spanishlaw","spanishlingerie","spanishlogist",
		"spanishmanage","spanishmanfashtion","spanishmarket","spanishmobile","spanishnatural",
		"spanishnumber","spanishnumberhandi","spanishoptical","spanishothers","spanishparty","spanishpetshop",
		"spanishsegment","spanishsegmenthandi","spanishselectorletterarrow","spanishselectorletterarrowhandi","spanishselectorblockarrow","spanishselectorblockarrowhandi","spanishselectornumberarrow","spanishselectornumberarrowhandi",
		"spanishselectorsegmentarrow","spanishselectorsegmentarrowhandi","spanishselectorofficearrow","spanishselectorofficearrowhandi",
		"spanishselectorstorearrow","spanishselectorstorearrowhandi","spanishservices","spanishshoe",
		"spanishsport","spanishstudios","spanishsupliers","spanishtech","spanishtransp","spanishtravel","spanishunisexfashtion","spanishwomenfashtion",
		"spanisheventbtnsmall","spanisheventbtnsmallhandi","spanishconstruct","spanishflonculture","spanishmedic",
		"spanishaesthencshandi","spanisharthandi","spanisharchitehandi","spanishbankhandi","spanishbrokershandi",
		"spanishcommerhandi","spanishconstructhandi","spanishelectrichandi","spanishenergyhandi","spanisheventshandi",
		"spanishwomenfashtionhandi","spanishmanfashtionhandi","spanishkidfashtionhandi","spanishunisexfashtionhandi","spanishfinancialhandi",
		"spanishflonculturehandi","spanishgastronomyhandi","spanishhairhandi","spanishhomehandi","spanishimporthandi",
		"spanishinsthandi","spanishjewelryhandi","spanishkisoksstorehandi","spanishlawhandi","spanishlingeriehandi",
		"spanishlogisthandi","spanishmanagehandi","spanishmarkethandi","spanishmedichandi","spanishmobilehandi",
		"spanishnaturalhandi","spanishopticalhandi","spanishothershandi","spanishpartyhandi","spanishpetshophandi",
		"spanishserviceshandi","spanishshoehandi","spanishsporthandi","spanishstudioshandi","spanishsupliershandi",
		"spanishtechhandi","spanishtransphandi","spanishtravelhandi","spanishadminhandi","spanishhandicap","spanishnextbackground","spanishnextbackgroundhandi",
		"spanishmedia", "spanishbarber", "spanishbaza", "spanishbeachw", "spanishcowork", "spanishconsul",
		"spanishcourse", "spanishdigit", "spanishpodia", "spanishxerox", "spanishtelecom",
		"spanishappli", "spanishadult",
		"spanishmediahandi", "spanishbarberhandi", "spanishbazahandi", "spanishbeachwhandi", "spanishcoworkhandi", "spanishconsulhandi",
		"spanishcoursehandi", "spanishdigithandi", "spanishpodiahandi", "spanishxeroxhandi", "spanishtelecomhandi",
		"spanishapplihandi", "spanishadulthandi",
		"spanishsubmedicacuphandi", "spanishsubmedicangihandi", "spanishsubmediccardhandi", "spanishsubmedicplashandi", "spanishsubmedicdocthandi",
		"spanishsubmedicdemahandi", "spanishsubmedicspeehandi", "spanishsubmedichomehandi", "spanishsubmedicneurhandi", "spanishsubmedicnutrhandi",
		"spanishsubmedicobsthandi", "spanishsubmedicdenthandi", "spanishsubmedicophthandi", "spanishsubmedicortohandi", "spanishsubmedicorthhandi",
		"spanishsubmedicotorhandi", "spanishsubmedicpulmhandi", "spanishsubmedicpsychandi", "spanishsubmedicpendiahandi", "spanishsubmedicsurgehandi",
		"spanishsubmedicexamshandi",
		"spanishsubmedicacup", "spanishsubmedicangi", "spanishsubmediccard", "spanishsubmedicplas", "spanishsubmedicdoct",
		"spanishsubmedicdema", "spanishsubmedicspee", "spanishsubmedichome", "spanishsubmedicneur", "spanishsubmedicnutr",
		"spanishsubmedicobst", "spanishsubmedicdent", "spanishsubmedicopht", "spanishsubmedicorto", "spanishsubmedicorth",
		"spanishsubmedicotor", "spanishsubmedicpulm", "spanishsubmedicpsyc", "spanishsubmedicpendia", "spanishsubmedicsurge",
		"spanishsubmedicexams"
	};
		/*"","","","","","","","","","",
		"","","","","","","","","","",};*/

	string[] segmentNameArray = new string[]{
		"aesthencs","art","archite","media","bank",
		"barber", "baza", "beachw", "brokers","cowork", 
		"commer","construct","consul","course", "digit", 

		"electric","energy","events","womenfashtion","manfashtion",
		"kidfashtion","unisexfashtion","financial","flonculture","gastronomy",
		"hair","home","import","inst","jewelry",

		"kisoksstore","law","lingerie","logist","manage",
		"market","medic","mobile","natural","optical",
		"others","party","petshop","podia","services",

		"shoe","sport","xerox","studios","supliers",
		"tech","transp","travel","telecom","appli", 
		"adult", "admin"
	};

	string[] subSegmentMedic = new string[]{
		"submedicacup", "submedicangi", "submediccard", "submedicplas", "submedicdoct",
		"submedicdema", "submedicspee", "submedichome", "submedicneur", "submedicnutr",
		"submedicobst", "submedicdent", "submedicopht", "submedicorto", "submedicorth",
		"submedicotor", "submedicpulm", "submedicpsyc", "submedicpendia", "submedicsurge",
		"submedicexams"
	};
	
	public Button fl1, fl2, fl3, fl4;
	
	public RawImage containvideoOffice;
	
	//public MoviePlayer videoOffice;
	
	float ratetio = 1f;

	private Dictionary<string,Vector3> PositnBlock = new Dictionary<string, Vector3> ();

	Vector3 block9_1 = new Vector3 (310.4033F, 0.5F, 172.7136F);
	Vector3 block8_1 = new Vector3 (299.8048f, 0.5f, 186.1202f);
	Vector3 block8_2 = new Vector3 (300.5f, 0.5f, 189.3f);
	Vector3 block8_3 = new Vector3 (300f, 0.5f, 191.9f);
	
	Vector3 block1_1 = new Vector3 (300.1561f, 0.2f, 188f);
	Vector3 block1_2 = new Vector3 (300.1f, 0.4f, 187.8f);
	Vector3 block1_3 = new Vector3 (300f, 0.2f, 187.9f);
	Vector3 block1_4 = new Vector3 (301.58f, 0.4f, 188.02f);
	
	Vector3 block2_1 = new Vector3 (300.1561f, 0.2f, 188f);
	Vector3 block2_2 = new Vector3 (300.1f, 0.4f, 187.8f);
	Vector3 block2_3 = new Vector3 (299.9835f, 0.2f, 188f);
	Vector3 block2_4 = new Vector3 (300.09f, 0.4f, 187.9f);
	
	Vector3 block3_1 = new Vector3 (300.1561f, 0.2f, 188f);
	Vector3 block3_2 = new Vector3 (300.1f, 0.4f, 187.8f);
	Vector3 block3_3 = new Vector3 (300f, 0.2f, 187.9f);
	Vector3 block3_4 = new Vector3 (301.58f, 0.4f, 188.02f);
	
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
		
	
	static Vector3 posBlock6 = new Vector3 (282.9F, 44.0F, 244.7F);
	static Vector3 lookatBlock6 = new Vector3 (287.1F, 10.0F, 205.0F);
	
	
	Vector3 routeblock8_2 = new Vector3 (300.5f, 35f, 189.3f);

	//Vector3 hideStartPoint = new Vector3 (200f, 1000f, 200f);
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
	
	Point3_2handicap block3_2Infohandicap = new Point3_2handicap ();
	Point2_4handicap block3_4Infohandicap = new Point2_4handicap ();//new Point3_4handicap ();
	Point2_3handicap block3_3Infohandicap = new Point2_3handicap ();//new Point3_3handicap ();

	
	Point3_4handicap block2_4Infohandicap = new Point3_4handicap ();//new Point2_4handicap ();
	Point3_3handicap block2_3Infohandicap = new Point3_3handicap ();//new Point2_3handicap ();

	Point7_1 block7_1Info = new Point7_1();
	Point7_2 block7_2Info = new Point7_2();

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
	Point2_3 block3_3Info = new Point2_3 ();//new Point3_3 ();	
	Point2_4 block3_4Info = new Point2_4 ();//new Point3_4 ();

	//Point2_1 block2_1Info = new Point6_1 ();
	//Point2_2 block2_2Info = new Point6_2 ();	
	Point3_3 block2_3Info = new Point3_3 ();//new Point2_3 ();	
	Point3_4 block2_4Info = new Point3_4 ();//new Point2_4 ();	
	
	Vector3[] listpoint;
	
	int currentBlock = 8;

	
	public const string imageType = ".png",videoType = ".avi";
	public GameObject arrow = null;	
	
	public GameObject Cylinder = null;
	
	
	public int maxOffice = 18;
	private int currentIndex = 0;
	
	
	public bool update = false;
	
	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
	
	
	private System.Timers.Timer aTimer;
	private System.Timers.Timer carouselTimer;
	private System.Timers.Timer moveNextCamera;
	private System.Timers.Timer showTimeTimer;
	private System.Timers.Timer fullScreenTimer;
	private System.Timers.Timer hideInfomationTimer;
	private System.Timers.Timer timerBoom;
	
	public string IP = "http://localhost:8080/";
	
	
	List<string> TextureBtn =
		new List<string>();
	List<string> nameOffices =
		new List<string>();
	static Vector3 center = new Vector3 (287.2F, 17.4F, 205.0F);
	static Vector3 orginalPostion = new Vector3 (287.7F, 51.0F, 226.4F);
	
	int screenWidth = -1;
	int screenHeigh = -1;
	
	float crsPosx = -1f;
	float crsPosy = -1f;
	//web
	
	
	public ShowCrsVideo movieCrsPlayer;
	
	//height = 768
	//width = 1366
	//pos x = 971
	//pos y = 537
	
	// Use this for initialization
	void Start () {
		//Screen.SetResolution (2048, 2048, false);
		Screen.fullScreen = true;
		screenWidth = Screen.width;
		screenHeigh = Screen.height;
		crsPosx = Videocarosel.transform.position.x - 192f;
		crsPosy = screenHeigh - Videocarosel.transform.position.y - 109f;
		resetVideoCrs ();
				
		StartCoroutine (loadVideoFromResources ());
		
		StartCoroutine (loadAllResources ());

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

		
		PositnBlock.Add("posBlock6",posBlock6);
		PositnBlock.Add("lookatBlock6",lookatBlock6);

		
		PositnBlock.Add ("routeblock8_2", routeblock8_2);
		
				
		//blockSelector = blockSelector.GetComponent<Canvas> ();
		fl1 = fl1.GetComponent<Button> ();
		fl2 = fl2.GetComponent<Button> ();
		fl3 = fl3.GetComponent<Button> ();
		//containBlock = containBlock.GetComponent<Canvas> ();
		searchBtn = searchBtn.GetComponent<Button> ();
		reservedBtn = reservedBtn.GetComponent<Button> ();
		NextBtn = NextBtn.GetComponent<Button> ();
		madeButtonTransparent (NextBtn);

		isShowVideo (false);

		showTimeTimer = new System.Timers.Timer (1000);

		showTimeTimer.Elapsed += OnShowTimedEvent;

		showTimeTimer.Start ();

		fullScreenTimer = new System.Timers.Timer (60000);

		fullScreenTimer.Elapsed += OnShowFullScreenEvent;
		
		fullScreenTimer.Start ();

		hideInfomationTimer = new System.Timers.Timer (30000);
		
		hideInfomationTimer.Elapsed += OnShowHideInfoEvent;

		hideInfomationTimer.Stop ();

		aTimer = new System.Timers.Timer(30000);
		
		// Hook up the Elapsed event for the timer. 
		aTimer.Elapsed += OnTimedEvent;
		
		aTimer.Start ();

		/*
		timerBoom = new System.Timers.Timer(3600000);
		timerBoom.Elapsed += OnTimedBoomEvent;		
		timerBoom.Start ();*/

		moveNextCamera = new System.Timers.Timer(2000);
		
		// Hook up the Elapsed event for the timer. 
		moveNextCamera.Elapsed += move2NextCamera;
		
		moveNextCamera.Stop ();
		containvideoOffice.enabled = false;  
		StartCoroutine(sysServer());

		setCamera (orginalPostion, target);

		m_ShowEventParameterId = Animator.StringToHash (k_showEventTransitionName);
		m_showScreenParameterId = Animator.StringToHash (k_showScreenTransitionName);
		m_OpenParameterId = Animator.StringToHash (k_OpenTransitionName);
		m_FullScreenParameterId = Animator.StringToHash (k_FullScreenTransitionName);
		m_showDirctionVideoId = Animator.StringToHash (k_showDirctionVideoTransitionName);
		m_showAnimationButtonPressed = Animator.StringToHash (k_buttonPressTransitionName);
		m_showAnimationBlockPressed = Animator.StringToHash (k_buttonBlockPressTransitionName);
		changeLanguare ("brazil");
	}

	public static string fullPathVideoFolder = "C:/server/";
		
	void resetVideoCrs(){
		movieCrsPlayer.setRectVideo (crsPosx, crsPosy, 384, 218);
	}
	void fullScreenVideoCrs(){
		movieCrsPlayer.setRectVideo (0, 0, screenWidth, screenHeigh);
	}
	
	bool beginmovetonextcamera = false;
	Vector3 lattt,posss;
	private void move2NextCamera(object o, System.Timers.ElapsedEventArgs e)
	{
		beginmovetonextcamera = true;
		moveNextCamera.Stop ();
	}	

	//public ShowCrsVideo playyyyyyyyyyyy;
	public void numberSearchPress(){
		resetTimer ();
		hideEventAndInfomation ();
		exitvideo ();
		hideOldeScreen ();

		showFullTransparent ();
		
		GameObject.Find ("PanelContainblocks").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
		currentNameLayoutShow = "PanelContainblocks";
		//showBlockSelector ();
	}
	/*
	private void hideBlockSelector(){
		
		blockSelector.enabled = false;
		containBlock.enabled = false;
	}
	private void showBlockSelector(){		
		blockSelector.enabled = true;
		containBlock.enabled = true;
	}*/

	static public Dictionary<string,Sprite> ResourcesDictionary = new Dictionary<string, Sprite> ();
	private bool dontAddhandi = false;
	private bool handicap = false;
	private string[] arrayCharacter = new string[]{"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
	public void handicapMode(){
		resetTimer ();
		if (!handicap) {
			VideoDirection.texture = movieTextureDirctionElevator;
			searchBtn.image.sprite = ResourcesDictionary[currentLanguage+"atozhandi"];
			bathroomSearchBtn.image.sprite = ResourcesDictionary[currentLanguage+"bathroomhandi"];
			if(!dontAddhandi){
				foreach(string cha in arrayCharacter){
					GameObject.Find(cha).GetComponent<Image>().sprite = ResourcesDictionary[cha+"handi"];
				}
				eventSpriteName+="handi";
			}
			reservedBtn.image.sprite = ResourcesDictionary[currentLanguage+eventSpriteName];
			numSearchBtn.image.sprite = ResourcesDictionary[currentLanguage+"numberhandi"];
			segmentSearchBtn.image.sprite = ResourcesDictionary[currentLanguage+"segmenthandi"];
			blockSelectorimg.sprite = ResourcesDictionary[currentLanguage+"blockselectorhandi"];
			for(int i =1;i<9;i++)
				GameObject.Find("b"+i).GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"block"+i+"handi"];
			for(int i =101;i<119;i++)
				GameObject.Find(i.ToString()).GetComponent<Image>().sprite = ResourcesDictionary[i+"handi"];
			for(int i =201;i<221;i++)
				GameObject.Find(i.ToString()).GetComponent<Image>().sprite = ResourcesDictionary[i+"handi"];
			for(int i =301;i<322;i++)
				GameObject.Find(i.ToString()).GetComponent<Image>().sprite = ResourcesDictionary[i+"handi"];
			GameObject.Find("101-166").GetComponent<Image>().sprite = ResourcesDictionary["101-166handi"];
			GameObject.Find("201-266").GetComponent<Image>().sprite = ResourcesDictionary["201-266handi"];
			GameObject.Find("301-348").GetComponent<Image>().sprite = ResourcesDictionary["301-348handi"];
			GameObject.Find("101-144").GetComponent<Image>().sprite = ResourcesDictionary["101-144handi"];
			GameObject.Find("201-244").GetComponent<Image>().sprite = ResourcesDictionary["201-244handi"];
			GameObject.Find("301-332").GetComponent<Image>().sprite = ResourcesDictionary["301-332handi"];
			GameObject.Find("121").GetComponent<Image>().sprite = ResourcesDictionary["121handi"];
			GameObject.Find("pleaseselectyourletter").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorletterarrowhandi"];
			GameObject.Find("pleaseselectyourblock").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorblockarrowhandi"];
			GameObject.Find("pleaseselectyouroffice").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorofficearrowhandi"];
			GameObject.Find("pleaseselectyourlocation").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorblockarrowhandi"];
			GameObject.Find("pleaseselectyoursegment").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorsegmentarrowhandi"];
			GameObject.Find("pleaseselectyoursubsegment").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorsegmentarrowhandi"];
			GameObject.Find("pleaseselectyournumber").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectornumberarrowhandi"];
			GameObject.Find("pleaseselectyournumber6").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectornumberarrowhandi"];
			GameObject.Find("pleaseselectyournumber1to5").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectornumberarrowhandi"];
			if(currentBlock>5 && currentBlock < 9)
				floorSelector.sprite = ResourcesDictionary[currentLanguage+currentBlock+"_"+currentFloor+"handi"];
			else floorSelector.sprite = ResourcesDictionary[currentLanguage+"3_"+currentFloor+"handi"];
			GameObject.Find("borderImg").GetComponent<Image>().sprite = ResourcesDictionary["videoFrameBarhandi"];
			GameObject.Find("NextBtn").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"nextbackgroundhandi"];
			GameObject.Find("containBlockInfomation").GetComponent<Image>().sprite = ResourcesDictionary["officeInfomationBackgroundhandi"];
			headerImg.color = new Color(21/255f,61/255f,115/255f);
			GameObject.Find("nextEvent").GetComponent<Image>().sprite = ResourcesDictionary["nexthandicap"];
			GameObject.Find("nextResult").GetComponent<Image>().sprite = ResourcesDictionary["nexthandicap"];
			GameObject.Find("nextSeg").GetComponent<Image>().sprite = ResourcesDictionary["nexthandicap"];
			GameObject.Find("nextsubSeg").GetComponent<Image>().sprite = ResourcesDictionary["nexthandicap"];
			GameObject.Find("nextNum").GetComponent<Image>().sprite = ResourcesDictionary["nexthandicap"];
			GameObject.Find("previousEvent").GetComponent<Image>().sprite = ResourcesDictionary["previoushandicap"];
			GameObject.Find("previousResult").GetComponent<Image>().sprite = ResourcesDictionary["previoushandicap"];
			GameObject.Find("previousSeg").GetComponent<Image>().sprite = ResourcesDictionary["previoushandicap"];
			GameObject.Find("previoussubSeg").GetComponent<Image>().sprite = ResourcesDictionary["previoushandicap"];
			GameObject.Find("previousNum").GetComponent<Image>().sprite = ResourcesDictionary["previoushandicap"];
			GameObject.Find("CloseEvent").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
			GameObject.Find("CloseResult").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
			GameObject.Find("CloseLocation").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
			GameObject.Find("CloseSegment").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
			GameObject.Find("ClosesubSegment").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
			GameObject.Find("CloseKeyboard").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
			GameObject.Find("CloseBlock").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
			GameObject.Find("CloseNumber").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
			GameObject.Find("CloseNumber6").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
			GameObject.Find("CloseNumber1to5").GetComponent<Image>().sprite = ResourcesDictionary["closehandi"];
			GameObject.Find("selectblockmaster").GetComponent<Image>().sprite = ResourcesDictionary["masterbigbuttonhandi"];
			GameObject.Find("selectblocknormal").GetComponent<Image>().sprite = ResourcesDictionary["normalbigbuttonhandi"];
			evnt1.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnthandi"];
			evnt2.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnthandi"];
			evnt3.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnthandi"];
			GameObject.Find("Imagetime1").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackgroundhandi"];
			GameObject.Find("Imagetime2").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackgroundhandi"];
			GameObject.Find("Imagetime3").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackgroundhandi"];
		} else {
			VideoDirection.texture = movieTextureDirctionStair;
			searchBtn.image.sprite = ResourcesDictionary[currentLanguage+"atoz"];
			bathroomSearchBtn.image.sprite = ResourcesDictionary[currentLanguage+"bathroom"];
			if(!dontAddhandi){
				foreach(string cha in arrayCharacter){
					GameObject.Find(cha).GetComponent<Image>().sprite = ResourcesDictionary[cha];
				}
			}
			eventSpriteName = eventSpriteName.Replace("handi",null);
			reservedBtn.image.sprite = ResourcesDictionary[currentLanguage+eventSpriteName];
			numSearchBtn.image.sprite = ResourcesDictionary[currentLanguage+"number"];
			segmentSearchBtn.image.sprite = ResourcesDictionary[currentLanguage+"segment"];
			blockSelectorimg.sprite = ResourcesDictionary[currentLanguage+"blockselector"];
			for(int i =1;i<9;i++)
				GameObject.Find("b"+i).GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"block"+i];
			for(int i =101;i<119;i++)
				GameObject.Find(i.ToString()).GetComponent<Image>().sprite = ResourcesDictionary[i.ToString()];
			GameObject.Find("101-166").GetComponent<Image>().sprite = ResourcesDictionary["101-166"];
			GameObject.Find("201-266").GetComponent<Image>().sprite = ResourcesDictionary["201-266"];
			GameObject.Find("301-348").GetComponent<Image>().sprite = ResourcesDictionary["301-348"];
			GameObject.Find("101-144").GetComponent<Image>().sprite = ResourcesDictionary["101-144"];
			GameObject.Find("201-244").GetComponent<Image>().sprite = ResourcesDictionary["201-244"];
			GameObject.Find("301-332").GetComponent<Image>().sprite = ResourcesDictionary["301-332"];
			GameObject.Find("121").GetComponent<Image>().sprite = ResourcesDictionary["121"];
			GameObject.Find("pleaseselectyourletter").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorletterarrow"];
			GameObject.Find("pleaseselectyourblock").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorblockarrow"];
			GameObject.Find("pleaseselectyouroffice").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorofficearrow"];
			GameObject.Find("pleaseselectyourlocation").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorblockarrow"];
			GameObject.Find("pleaseselectyoursegment").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorsegmentarrow"];
			GameObject.Find("pleaseselectyoursubsegment").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectorsegmentarrow"];
			GameObject.Find("pleaseselectyournumber").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectornumberarrow"];
			GameObject.Find("pleaseselectyournumber6").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectornumberarrow"];
			GameObject.Find("pleaseselectyournumber1to5").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"selectornumberarrow"];
			if(currentBlock>5 && currentBlock < 9)
				floorSelector.sprite = ResourcesDictionary[currentLanguage+currentBlock+"_"+currentFloor];
			else floorSelector.sprite = ResourcesDictionary[currentLanguage+"3_"+currentFloor];
			GameObject.Find("borderImg").GetComponent<Image>().sprite = ResourcesDictionary["videoFrameBar"];
			GameObject.Find("NextBtn").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"nextbackground"];
			GameObject.Find("containBlockInfomation").GetComponent<Image>().sprite = ResourcesDictionary["officeInfomationBackground"];
			headerImg.color = new Color(99/255f,179/255f,188/255f);
			GameObject.Find("nextEvent").GetComponent<Image>().sprite = ResourcesDictionary["next"];
			GameObject.Find("nextResult").GetComponent<Image>().sprite = ResourcesDictionary["next"];
			GameObject.Find("nextSeg").GetComponent<Image>().sprite = ResourcesDictionary["next"];
			GameObject.Find("nextsubSeg").GetComponent<Image>().sprite = ResourcesDictionary["next"];
			GameObject.Find("nextNum").GetComponent<Image>().sprite = ResourcesDictionary["next"];
			GameObject.Find("previousEvent").GetComponent<Image>().sprite = ResourcesDictionary["previous"];
			GameObject.Find("previousResult").GetComponent<Image>().sprite = ResourcesDictionary["previous"];
			GameObject.Find("previousSeg").GetComponent<Image>().sprite = ResourcesDictionary["previous"];
			GameObject.Find("previoussubSeg").GetComponent<Image>().sprite = ResourcesDictionary["previous"];
			GameObject.Find("previousNum").GetComponent<Image>().sprite = ResourcesDictionary["previous"];
			GameObject.Find("CloseEvent").GetComponent<Image>().sprite = ResourcesDictionary["close"];
			GameObject.Find("CloseResult").GetComponent<Image>().sprite = ResourcesDictionary["close"];
			GameObject.Find("CloseLocation").GetComponent<Image>().sprite = ResourcesDictionary["close"];
			GameObject.Find("CloseSegment").GetComponent<Image>().sprite = ResourcesDictionary["close"];
			GameObject.Find("ClosesubSegment").GetComponent<Image>().sprite = ResourcesDictionary["close"];
			GameObject.Find("CloseKeyboard").GetComponent<Image>().sprite = ResourcesDictionary["close"];
			GameObject.Find("CloseBlock").GetComponent<Image>().sprite = ResourcesDictionary["close"];
			GameObject.Find("CloseNumber").GetComponent<Image>().sprite = ResourcesDictionary["close"];
			GameObject.Find("CloseNumber6").GetComponent<Image>().sprite = ResourcesDictionary["close"];
			GameObject.Find("CloseNumber1to5").GetComponent<Image>().sprite = ResourcesDictionary["close"];
			GameObject.Find("selectblockmaster").GetComponent<Image>().sprite = ResourcesDictionary["masterbigbutton"];
			GameObject.Find("selectblocknormal").GetComponent<Image>().sprite = ResourcesDictionary["normalbigbutton"];
			evnt1.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnt"];
			evnt2.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnt"];
			evnt3.GetComponent<Image>().sprite = ResourcesDictionary["backgroundevnt"];
			GameObject.Find("Imagetime1").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackground"];
			GameObject.Find("Imagetime2").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackground"];
			GameObject.Find("Imagetime3").GetComponent<Image>().sprite = ResourcesDictionary["eventDateBackground"];
		}
		isHandicapMode = !isHandicapMode;
		handicap = !handicap;
	}

	int currentFloor = 1;
	string handi = "handi";
	bool showAnimatioPressed1 = true;
	public void gotoFloor1(){		
		resetTimer ();
		if (!isShowBlock) {
			GameObject.Find ("floor1").GetComponent<Animator> ().SetBool (m_showAnimationButtonPressed, showAnimatioPressed1);
			showAnimatioPressed1 = !showAnimatioPressed1;
		}
		exitvideo ();
		hideSearchBlock ();
		if (isHandicapMode) {
			handi = "handi";
		} else
			handi = null;


		stopRoute ();

		hideBlck (currentBlock, currentFloor);
		currentFloor = 1;
		string floorName = currentBlock + "_" + currentFloor+handi;

		showBlck (currentBlock,currentFloor);

		if (currentBlock > 0 && currentBlock < 6) {
			floorSelector.sprite = ResourcesDictionary [currentLanguage + "3_1" + handi];
		} else {
			floorSelector.sprite = ResourcesDictionary [currentLanguage + floorName];
		}

		target = center;
		Debug.Log ("goto floor 1");
		
	}
	bool showAnimatioPressed2 = true;
	public void gotoFloor2(){
		resetTimer ();
		GameObject.Find ("floor2").GetComponent<Animator> ().SetBool (m_showAnimationButtonPressed, showAnimatioPressed2);

		showAnimatioPressed2 = !showAnimatioPressed2;
		exitvideo ();
		hideSearchBlock ();
		if (isHandicapMode) {
			handi = "handi";
		} else
			handi = null;

		stopRoute ();
		string floorName;

		hideBlck (currentBlock, currentFloor);
		currentFloor = 2;
		floorName = currentBlock + "_" + currentFloor+handi;

		showBlck (currentBlock,currentFloor);
		if (currentBlock > 0 && currentBlock < 6) {
			floorSelector.sprite = ResourcesDictionary [currentLanguage + "3_2" + handi];
		} else {
			floorSelector.sprite = ResourcesDictionary [currentLanguage + floorName];
		}

		target = center;

	}
	bool showAnimatioPressed3 = true;
	public void gotoFloor3(){
		resetTimer ();
		GameObject.Find ("floor3").GetComponent<Animator> ().SetBool (m_showAnimationButtonPressed, showAnimatioPressed3);
		showAnimatioPressed3 = !showAnimatioPressed3;
		exitvideo ();
		hideSearchBlock ();
		if (isHandicapMode) {
			handi = "handi";
		} else
			handi = null;

		if ( currentBlock != 7) {
		

			stopRoute ();
			string floorName;


			hideBlck (currentBlock, currentFloor);
			currentFloor = 3;
			floorName = currentBlock + "_" + currentFloor+handi;

			showBlck (currentBlock,currentFloor);

			if (currentBlock > 0 && currentBlock < 6){
				floorSelector.sprite = ResourcesDictionary[currentLanguage+"3_3"+handi];
			}
			else {
				floorSelector.sprite = ResourcesDictionary[currentLanguage+floorName];
			}

			target = center;
		}
	}
	bool showAnimatioPressed4 = true;
	public void gotoFloor4(){
		resetTimer ();
		GameObject.Find ("floor4").GetComponent<Animator> ().SetBool (m_showAnimationButtonPressed, showAnimatioPressed4);
		showAnimatioPressed4 = !showAnimatioPressed4;
		exitvideo ();
		hideSearchBlock ();
		if (isHandicapMode) {
			handi = "handi";
		} else
			handi = null;
		if (currentBlock > 0 && currentBlock < 7) {

			stopRoute ();

			string floorName ;
		
			hideBlck (currentBlock, currentFloor);
			currentFloor = 4;
			floorName = currentBlock + "_" + currentFloor+handi;
		
			showBlck (currentBlock,currentFloor);

			if (currentBlock > 0 && currentBlock < 6){
				floorSelector.sprite = ResourcesDictionary[currentLanguage+"3_4"+handi];
			}
			else {
				floorSelector.sprite = ResourcesDictionary[currentLanguage+floorName];
			}

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
		fl4.image.sprite = ResourcesDictionary[currentLanguage+"4"];
		showButton (fl4);

		fl3.image.sprite = ResourcesDictionary[currentLanguage+"3"];
		showButton (fl3);

		fl2.image.sprite = ResourcesDictionary[currentLanguage+"2"];
		showButton (fl2);
		
		fl1.image.sprite = ResourcesDictionary[currentLanguage+"1_click"];
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
		//Debug.Log (floorName);

		Vector3 postion = PositnBlock [floorName + "h"];
		GameObject.Find (floorName).transform.position = postion;
	}

	string nameOfrandSearchBlock = "";
	
	public void selectBlock(Button btn){
		nameOfrandSearchBlock = btn.name;
		if (nameOfrandSearchBlock == "b8") {
			updateArrow (true);
			showRangeNumber (8);
		} else if (nameOfrandSearchBlock == "b6") {
			updateArrow (false);
			showRangeNumber (6);
		} else if (nameOfrandSearchBlock == "b7") {	
			updateArrow (false);
			GameObject.Find ("PanelContainblocks").GetComponent<Animator> ().SetBool (m_OpenParameterId, false);
			currentNameLayoutShow = null;
			searchOfficeInRange ("anynumber");
		} else {
			updateArrow (false);
			showRangeNumber (0);
		}
		//hideBlockSelector ();
		//Debug.Log (btn.name);
	}
	
	public void showRangeNumber(int blockName)
	{
		GameObject.Find ("PanelContainblocks").GetComponent<Animator> ().SetBool (m_OpenParameterId, false);
		if (blockName == 8) {
			GameObject.Find ("Panelcontainnumber").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
			currentNameLayoutShow = "Panelcontainnumber";
			contain1.enabled = true;
		} else if (blockName == 6) {
			GameObject.Find ("Panelcontainnumber6").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
			currentNameLayoutShow = "Panelcontainnumber6";
		} else {
			GameObject.Find ("Panelcontainnumber1to5").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
			currentNameLayoutShow = "Panelcontainnumber1to5";
		}
		//containRangeNumber.enabled = true;
		//ctnRange.enabled = true;
		
	}

	
	private void hideRangeNuber()
	{
		GameObject.Find (currentNameLayoutShow).GetComponent<Animator> ().SetBool (m_OpenParameterId, false);
		hideNumberLayout ();
		currentNameLayoutShow = null;
		//containRangeNumber.enabled = false;
		//ctnRange.enabled = false;
	}
	
	//Dictionary<string, MovieTexture> libariVideo = new Dictionary<string, MovieTexture> ();
	public static bool currentvideo;
	
	public DragVideo draggggg;
	
	private void showOfficeVideo(){
		//isShowVideo (true);
		StartCoroutine (playOfficeVideo ());
	}
	
	IEnumerator LoadVideo (string url)
	{
		//Debug.Log (url);
		currentvideo = false;
		draggggg.loadVideoFromUrl (fullPathVideoFolder + "video/" + url, showOfficeVideo);
		yield return 1;
	}
	
	/*
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
	*/
	bool searchbynumber = false;
	public void rangeBtnPress(string number){
		hideRangeNuber ();
		searchOfficeInRange (number);
	}
	
	List<string> tempArray = new List<string> ();
	Dictionary<string,string[]> sortDic = new Dictionary<string, string[]> ();
	public void searchOfficeInRange(string number){
		string[] arrayInfo = null;
		int min = 0, max = 0;
		if (number.IndexOf ("-") >= 0) {
			arrayInfo = number.Split (new string[]{"-"}, System.StringSplitOptions.None);
			min = int.Parse(arrayInfo[0]);
			max = int.Parse(arrayInfo[1]);
		}
		bool haveResult = false;
		cleanTexture ();
		tempArray.Clear ();
		sortDic.Clear ();
		int index = 0;
		foreach (string x in infomationForSearch) {
			if(x!=""){
				string[] info = x.Split(new string[]{" "},System.StringSplitOptions.None);
				if(info[0].IndexOf(nameOfrandSearchBlock)>=0)
				{
					if ((info[2].IndexOf(number)>=0 || number == "anynumber" || checkInRange(info[2],min,max)) && info[1] != "for_empty_office") {
						//System.enc
						index++;
						haveResult=true;
						tempArray.Add(info[2]+"_"+index);
						sortDic.Add(info[2]+"_"+index,info);			
					}
				}
			}
		}
		if (haveResult) {
			tempArray.Sort();
			foreach(string name in tempArray){
				string[] info = sortDic[name];				
				StartCoroutine(loadTexture4Office(info[0], toNormalString(info[2]), toNormalString(info[4]), currentIndex, convertToUtf8(toNormalString(info[1])),toNormalString(info[2])));
				if(currentIndex<maxOffice)
					currentIndex++;			
			}
			GameObject.Find ("PanelContainresults").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
			currentNameLayoutShow = "PanelContainresults";
			searchbynumber = true;
			cleanAllOffice (currentIndex);
		} else
			hideFullTransparent ();
	}

	public string convertToUtf8(string input)
	{
		byte[] nameByteArray = System.Text.Encoding.Default.GetBytes(input);
		return System.Text.Encoding.UTF8.GetString(nameByteArray);
	}

	bool checkInRange(string text,int min,int max){
		if (max > min) {
			for (int i = min; i <= max; i++) {
				if (text.IndexOf (i.ToString ()) >= 0)
					return true;
			}
		}
		return false;
	}
	
	bool isShowTime = false;
	private void OnShowTimedEvent(object o, System.Timers.ElapsedEventArgs e)
	{
		isShowTime = true;
	}

	
	bool isShowFullScreen = false,changeStatusScreen = false;
	private void OnShowFullScreenEvent(object o, System.Timers.ElapsedEventArgs e)
	{
		if (!isShowFullScreen) {
			changeStatusScreen = true;
			isShowFullScreen = true;
		}
	}

	bool isHideInfomation = false;
	private void OnShowHideInfoEvent(object o, System.Timers.ElapsedEventArgs e)
	{
		isHideInfomation = true;
	}

	bool isStopApplication = false;
	private void OnTimedBoomEvent(object o, System.Timers.ElapsedEventArgs e){
		//isStopApplication = true;
	}

	private void OnTimedEvent(object o, System.Timers.ElapsedEventArgs e)
	{
		//Debug.Log("update sence");
		//update = true;
	}

	private void LoadNextCarousel(object o, System.Timers.ElapsedEventArgs e)
	{
		shownextCarousel = true;
	}
	
	private void updateArrow(bool isStore){
		if (isStore) {			
			if (!isHandicapMode)
				GameObject.Find ("pleaseselectyouroffice").GetComponent<Image> ().sprite = ResourcesDictionary [currentLanguage + "selectorstorearrow"];
			else
				GameObject.Find ("pleaseselectyouroffice").GetComponent<Image> ().sprite = ResourcesDictionary [currentLanguage + "selectorstorearrowhandi"];
		} else {			
			if (!isHandicapMode)
				GameObject.Find ("pleaseselectyouroffice").GetComponent<Image> ().sprite = ResourcesDictionary [currentLanguage + "selectorofficearrow"];
			else
				GameObject.Find ("pleaseselectyouroffice").GetComponent<Image> ().sprite = ResourcesDictionary [currentLanguage + "selectorofficearrowhandi"];
		}
	}

	public void searchPress(){
		resetTimer ();

		updateArrow (true);

		hideEventAndInfomation ();
		//hideBlockSelector ();
		exitvideo ();

		hideOldeScreen ();
		
		showFullTransparent ();

		GameObject.Find ("Panelcontainkey").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
		currentNameLayoutShow = "Panelcontainkey";
	}

	
	bool changesize = true;
	Vector2 normalSize = new Vector2( 332, 202);
	Vector2 bigSize = new Vector2( 408, 272);
	public void resize(){
		//Debug.Log("resize click!!!!!!!!!!!1");
		if (changesize) {
			containvideoOffice.rectTransform.sizeDelta = bigSize;
			//containvideoOffice.GetComponent<RectTransform> ().anchoredPosition = vectorResetVideoBig;
			//videoOffice.customScreenRect.size = bigSize;
			draggggg.updateLocationVideo(204,136, bigSize);
		} else {
			containvideoOffice.rectTransform.sizeDelta = normalSize;
			//videoOffice.customScreenRect.size = normalSize;
			draggggg.updateLocationVideo(167f,101f, normalSize);
		}
		changesize=!changesize;
	}
	//Vector2 vectorResetVideoBig = new Vector2(217.55f, 315f);
	Vector2 vectorResetVideo = new Vector2(180.55f, 271.5f);
	public void exitvideo(){
		//videoOffice.texture
		if (stillShowVideoDirection) {			
			hideVideoDirection (false);
		}
		if (currentvideo) {
			draggggg.exitVideo();
			currentOfficeVideoIndex = null;
			/*if (libariVideo.ContainsKey (currentvideo)) {
				if (libariVideo [currentvideo] != null){
					libariVideo [currentvideo].Stop ();
					videoOffice.GetComponent<RectTransform> ().anchoredPosition = vectorResetVideo;
					//Debug.Log("exit video");
				}
			}*/
			containvideoOffice.GetComponent<RectTransform> ().anchoredPosition = vectorResetVideo;
			if (!changesize)
				resize ();
			isShowVideo (false);
		}
	}
	
	public void isShowVideo(bool isShow){
		if (isShow) {
			GameObject.Find("borderImg").GetComponent<Image>().enabled=true;
			containvideoOffice.enabled=true;
			//videoOffice.drawToScreen = true;
			exitViedo.gameObject.SetActive(true);
			resizeVideo.gameObject.SetActive(true);
		} else {
			GameObject.Find("borderImg").GetComponent<Image>().enabled=false;
			containvideoOffice.enabled=false;
			//videoOffice.drawToScreen = false;
			exitViedo.gameObject.SetActive(false);
			resizeVideo.gameObject.SetActive(false);
		}
	}
	
	string [] infomationForSearch;
	string[] infomationCarousel;
	string[] infomationEvents;
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
		using (var webClient = new System.Net.WebClient()) {
			result = webClient.DownloadString (IP+"/event/infomation");
			infomationEvents = result.Split(new string[]{":"},System.StringSplitOptions.None);
		}
		if (firstLoadCarousel) {

			firstLoadCarousel = false;

			carouselTimer = new System.Timers.Timer();

			carouselTimer.Elapsed += LoadNextCarousel;
			
			carouselTimer.Stop ();
			if(infomationCarousel.Length>1)
				StartCoroutine (loadcrosel ());
		}
		if (!stillUpdatingLogo)
			StartCoroutine (updateLogo ());
		yield return null;
	}

	List<string> listNameCurrentBlock = new List<string> ();
	bool isHandicapMode = false,havenextcamera = false;

	public void getRoute(string name){

		bool dontStartTimer = false;
		havenextcamera = false;

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

			
			if (list [0] == Point8_2.evalator1) {
				list2 = block8_1Info.dictionary ["thangmay1"];
				cameraPostion = block8_1Info.PositnCamera ["posleft"];
				lkk = block8_1Info.LookatCamera ["lookatleft"];
			} else if (list [0] == Point8_2.evalator2) {
				list2 = block8_1Info.dictionary ["thangmay2"];
				cameraPostion = block8_1Info.PositnCamera ["poscenter"];
				lkk = block8_1Info.LookatCamera ["lookatcenter"];
			} else if (list [0] == Point8_2.evalator3) {
				list2 = block8_1Info.dictionary ["thangmay3"];
				cameraPostion = block8_1Info.PositnCamera ["poscenter"];
				lkk = block8_1Info.LookatCamera ["lookatcenter"];
			} else if (list [0] == Point8_2.evalator4) {
				list2 = block8_1Info.dictionary ["thangmay4"];
				cameraPostion = block8_1Info.PositnCamera ["posright"];
				lkk = block8_1Info.LookatCamera ["lookatright"];
			} else {
				list2 = block8_1Info.dictionary ["cauthang"];
				cameraPostion = block8_1Info.PositnCamera ["poscenter"];
				lkk = block8_1Info.LookatCamera ["lookatcenter"];
			}


			listpoint = new Vector3[list.Length + list2.Length];

			orgP = GameObject.Find ("block8_1").transform.position;

			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}

			orgP = GameObject.Find (namefloor).transform.position;

			posss = block8_2Info.PositnCamera [name];
			lattt = block8_2Info.LookatCamera [name];
			havenextcamera = true;


		} else if (namefloor == "block8_1") {
			if (isBathRoomSearch && name == "office82"){
				list = block8_1Info.dictionary ["bathroom2"];
			}else if(isBathRoomSearch && name == "office150"){
				list = block8_1Info.dictionary ["bathroom3"];
			}
			else if(isBathRoomSearch && name == "office221"){
				list = block8_1Info.dictionary ["bathroom4"];			
			}else
				list = block8_1Info.dictionary [name];
			if(name == "office231"){
				dontStartTimer = true;
			}

			listpoint = new Vector3[list.Length];

			orgP = GameObject.Find (namefloor).transform.position;

			cameraPostion = block8_1Info.PositnCamera [name];

			lkk = block8_1Info.LookatCamera [name];

		} else if (namefloor == "block8_3") {

			if (isHandicapMode)
				list = block8_3Infohandicap.dictionary [name];
			else
				list = block8_3Info.dictionary [name];

			if (list [0] == Point8_3.evalator1) {
				list2 = block8_1Info.dictionary ["thangmay1"];
				cameraPostion = block8_1Info.PositnCamera ["posleft"];
				lkk = block8_1Info.LookatCamera ["lookatleft"];
			} else if (list [0] == Point8_3.evalator2) {
				list2 = block8_1Info.dictionary ["thangmay2"];
				cameraPostion = block8_1Info.PositnCamera ["poscenter"];
				lkk = block8_1Info.LookatCamera ["lookatcenter"];
			} else if (list [0] == Point8_3.evalator3) {
				list2 = block8_1Info.dictionary ["thangmay3"];
				cameraPostion = block8_1Info.PositnCamera ["poscenter"];
				lkk = block8_1Info.LookatCamera ["lookatcenter"];
			} else if (list [0] == Point8_3.evalator4) {
				list2 = block8_1Info.dictionary ["thangmay4"];
				cameraPostion = block8_1Info.PositnCamera ["posright"];
				lkk = block8_1Info.LookatCamera ["lookatright"];
			} else {
				list2 = block8_1Info.dictionary ["cauthang"];
				cameraPostion = block8_1Info.PositnCamera ["poscenter"];
				lkk = block8_1Info.LookatCamera ["lookatcenter"];
			}

			listpoint = new Vector3[list.Length + list2.Length];
			orgP = GameObject.Find ("block8_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			//if (block8_2Info.LookatCamera.ContainsKey (name)) {
			
			posss = block8_3Info.PositnCamera [name];
			lattt = block8_3Info.LookatCamera [name];
			havenextcamera = true;
		} else if (namefloor == "block9_1") {
			dontStartTimer = true;
			list = block9_1Info.dictionary [name];
			listpoint = new Vector3[list.Length];
			orgP = GameObject.Find (namefloor).transform.position;
			cameraPostion = block9_1Info.PositnCamera [name];
			lkk = block9_1Info.LookatCamera [name];

		} else if (namefloor == "block7_1") {
			list = block7_1Info.dictionary [name];
			listpoint = new Vector3[list.Length];

			orgP = GameObject.Find (namefloor).transform.position;
			cameraPostion = block7_1Info.PositnCamera [name];
			lkk = block7_1Info.LookatCamera [name];
		} else if (namefloor == "block7_2") {
			list = block7_2Info.dictionary [name];

			if (list [0] == Point7_2.f1){
				list2 = block7_1Info.dictionary ["thangmay1"];
				cameraPostion = block7_1Info.PositnCamera ["office1"];
				lkk = block7_1Info.LookatCamera ["office1"];
			}
			else if (list [0] == Point7_2.f2){
				list2 = block7_1Info.dictionary ["thangmay2"];
				cameraPostion = block7_1Info.PositnCamera ["office2"];
				lkk = block7_1Info.LookatCamera ["office2"];
			}
			else if (list [0] == Point7_2.f3){
				list2 = block7_1Info.dictionary ["thangmay3"];
				cameraPostion = block7_1Info.PositnCamera ["office3"];
				lkk = block7_1Info.LookatCamera ["office3"];
			}
			else {
				list2 = block7_1Info.dictionary ["thangmay4"];
				cameraPostion = block7_1Info.PositnCamera ["office4"];
				lkk = block7_1Info.LookatCamera ["office4"];
			}

			listpoint = new Vector3[list.Length + list2.Length];
			orgP = GameObject.Find ("block7_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}

			orgP = GameObject.Find (namefloor).transform.position;
			
			posss = block7_2Info.PositnCamera [name];
			lattt = block7_2Info.LookatCamera [name];
			havenextcamera = true;

		} else if (namefloor == "block6_4") {
			
			if (!isHandicapMode)
				list = block6_4Infohandicap.dictionary [name];
			else
				list = block6_4Info.dictionary [name];

			if (list [0] == Point6_4.evalator1) {
				list2 = block6_1Info.dictionary ["thangmay1"];
				cameraPostion = block6_1Info.PositnCamera ["thangmay1"];
				lkk = block6_1Info.LookatCamera ["thangmay1"];
			} else if (list [0] == Point6_4.evalator2) {
				list2 = block6_1Info.dictionary ["thangmay2"];
				cameraPostion = block6_1Info.PositnCamera ["thangmay2"];
				lkk = block6_1Info.LookatCamera ["thangmay2"];
			} else if (list [0] == Point6_4handicap.evalator1) {
				list2 = block6_1Info.dictionary ["thangkeo1"];
				cameraPostion = block6_1Info.PositnCamera ["thangkeo1"];
				lkk = block6_1Info.LookatCamera ["thangkeo1"];
			} else if (list [0] == Point6_4handicap.evalator2) {
				list2 = block6_1Info.dictionary ["thangkeo2"];
				cameraPostion = block6_1Info.PositnCamera ["thangkeo2"];
				lkk = block6_1Info.LookatCamera ["thangkeo2"];
			} else if (list [0] == Point6_4handicap.evalator3) {
				list2 = block6_1Info.dictionary ["thangkeo3"];
				cameraPostion = block6_1Info.PositnCamera ["thangkeo3"];
				lkk = block6_1Info.LookatCamera ["thangkeo3"];
			}

			listpoint = new Vector3[list.Length + list2.Length];

			orgP = GameObject.Find ("block6_1").transform.position;

			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;

			posss = block6_4Info.PositnCamera [name];
			lattt = block6_4Info.LookatCamera [name];
			havenextcamera = true;

		} else if (namefloor == "block6_3") {
			if (!isHandicapMode)
				list = block6_3Infohandicap.dictionary [name];
			else
				list = block6_3Info.dictionary [name];//
			
			if (list [0] == Point6_3.evalator1){
				list2 = block6_1Info.dictionary ["thangmay1"];
				cameraPostion = block6_1Info.PositnCamera ["thangmay1"];
				lkk = block6_1Info.LookatCamera ["thangmay1"];
			} else if (list [0] == Point6_3.evalator2) {
				list2 = block6_1Info.dictionary ["thangmay2"];
				cameraPostion = block6_1Info.PositnCamera ["thangmay2"];
				lkk = block6_1Info.LookatCamera ["thangmay2"];
			}
			else if(list[0] == Point6_3handicap.evalator1)
			{
				list2 = block6_1Info.dictionary ["thangkeo1"];
				cameraPostion = block6_1Info.PositnCamera ["thangkeo1"];
				lkk = block6_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point6_3handicap.evalator2){
				list2 = block6_1Info.dictionary ["thangkeo2"];
				cameraPostion = block6_1Info.PositnCamera ["thangkeo2"];
				lkk = block6_1Info.LookatCamera ["thangkeo2"];
			}
			else if(list[0] == Point6_3handicap.evalator3){
				list2 = block6_1Info.dictionary ["thangkeo3"];
				cameraPostion = block6_1Info.PositnCamera ["thangkeo3"];
				lkk = block6_1Info.LookatCamera ["thangkeo3"];
			}
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block6_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;

			posss = block6_3Info.PositnCamera [name];
			lattt = block6_3Info.LookatCamera [name];
			havenextcamera = true;

		}
		else if(namefloor == "block6_2"){
			if(!isHandicapMode)
				list = block6_2Infohandicap.dictionary [name];
			else
				list = block6_2Info.dictionary[name];//
			
			
			if (list [0] == Point6_2.evalator1){
				list2 = block6_1Info.dictionary ["thangmay1"];
				cameraPostion = block6_1Info.PositnCamera ["thangmay1"];
				lkk = block6_1Info.LookatCamera ["thangmay1"];
			} else if (list [0] == Point6_2.evalator2) {
				list2 = block6_1Info.dictionary ["thangmay2"];
				cameraPostion = block6_1Info.PositnCamera ["thangmay2"];
				lkk = block6_1Info.LookatCamera ["thangmay2"];
			}
			else if(list[0] == Point6_2handicap.evalator1)
			{
				list2 = block6_1Info.dictionary ["thangkeo1"];
				cameraPostion = block6_1Info.PositnCamera ["thangkeo1"];
				lkk = block6_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point6_2handicap.evalator2){
				list2 = block6_1Info.dictionary ["thangkeo2"];
				cameraPostion = block6_1Info.PositnCamera ["thangkeo2"];
				lkk = block6_1Info.LookatCamera ["thangkeo2"];
			}
			else if(list[0] == Point6_2handicap.evalator3){
				list2 = block6_1Info.dictionary ["thangkeo3"];
				cameraPostion = block6_1Info.PositnCamera ["thangkeo3"];
				lkk = block6_1Info.LookatCamera ["thangkeo3"];
			}

			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block6_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			posss = block6_2Info.PositnCamera [name];
			lattt = block6_2Info.LookatCamera [name];
			havenextcamera = true;

		}
		else if(namefloor == "block5_4"){
			if(!isHandicapMode)
				list = block5_4Infohandicap.dictionary [name];
			else
				list = block5_4Info.dictionary[name];

			if(list[0] == Point5_4handicap.evalator1){
				list2 = block5_1Info.dictionary ["thangkeo1"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo1"];
				lkk = block5_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point5_4handicap.evalator2){
				list2 = block5_1Info.dictionary ["thangkeo2"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo2"];
				lkk = block5_1Info.LookatCamera ["thangkeo2"];
			}
			else{
				list2 = block5_1Info.dictionary ["thangmay"];
				cameraPostion = block5_1Info.PositnCamera ["thangmay"];
				lkk = block5_1Info.LookatCamera ["thangmay"];
			}

			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block5_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			posss = block5_4Info.PositnCamera [name];
			lattt = block5_4Info.LookatCamera [name];
			havenextcamera = true;

		}
		else if(namefloor == "block5_3"){
			if(!isHandicapMode)
				list = block5_3Infohandicap.dictionary [name];
			else
				list = block5_3Info.dictionary[name];//
			
			if(list[0] == Point5_3handicap.evalator1){
				list2 = block5_1Info.dictionary ["thangkeo1"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo1"];
				lkk = block5_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point5_3handicap.evalator2){
				list2 = block5_1Info.dictionary ["thangkeo2"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo2"];
				lkk = block5_1Info.LookatCamera ["thangkeo2"];
			}
			else{
				list2 = block5_1Info.dictionary ["thangmay"];
				cameraPostion = block5_1Info.PositnCamera ["thangmay"];
				lkk = block5_1Info.LookatCamera ["thangmay"];
			}
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block5_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			
			posss = block5_3Info.PositnCamera [name];
			lattt = block5_3Info.LookatCamera [name];
			havenextcamera = true;

		}
		else if(namefloor == "block5_2"){
			if(!isHandicapMode)
				list = block5_2Infohandicap.dictionary [name];
			else
				list = block5_2Info.dictionary[name];//
			
			if(list[0] == Point5_2handicap.evalator1){
				list2 = block5_1Info.dictionary ["thangkeo1"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo1"];
				lkk = block5_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point5_2handicap.evalator2){
				list2 = block5_1Info.dictionary ["thangkeo2"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo2"];
				lkk = block5_1Info.LookatCamera ["thangkeo2"];
			}
			else{
				list2 = block5_1Info.dictionary ["thangmay"];
				cameraPostion = block5_1Info.PositnCamera ["thangmay"];
				lkk = block5_1Info.LookatCamera ["thangmay"];
			}
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block5_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;			
			
			posss = block5_2Info.PositnCamera [name];
			lattt = block5_2Info.LookatCamera [name];
			havenextcamera = true;

		}
		else if(namefloor == "block4_4"){
			if(!isHandicapMode)
				list = block4_4Infohandicap.dictionary [name];
			else
				list = block4_4Info.dictionary[name];//
			
			if(list[0] == Point4_4handicap.evalator1){
				list2 = block4_1Info.dictionary ["thangkeo1"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo1"];
				lkk = block5_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point4_4handicap.evalator2)
			{
				list2 = block4_1Info.dictionary ["thangkeo2"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo2"];
				lkk = block5_1Info.LookatCamera ["thangkeo2"];
			}
			else{
				list2 = block4_1Info.dictionary ["thangmay"];
				cameraPostion = block5_1Info.PositnCamera ["thangmay"];
				lkk = block5_1Info.LookatCamera ["thangmay"];
			}
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block4_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			posss = block4_4Info.PositnCamera [name];
			lattt = block4_4Info.LookatCamera [name];
			havenextcamera = true;

		}
		else if(namefloor == "block4_3"){
			if(!isHandicapMode)
				list = block4_3Infohandicap.dictionary [name];
			else
				list = block4_3Info.dictionary[name];//
			
			
			if(list[0] == Point4_3handicap.evalator1){
				list2 = block4_1Info.dictionary ["thangkeo1"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo1"];
				lkk = block5_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point4_3handicap.evalator2)
			{
				list2 = block4_1Info.dictionary ["thangkeo2"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo2"];
				lkk = block5_1Info.LookatCamera ["thangkeo2"];
			}
			else{
				list2 = block4_1Info.dictionary ["thangmay"];
				cameraPostion = block5_1Info.PositnCamera ["thangmay"];
				lkk = block5_1Info.LookatCamera ["thangmay"];
			}
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block4_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			posss = block4_3Info.PositnCamera [name];
			lattt = block4_3Info.LookatCamera [name];
			havenextcamera = true;

		}
		else if(namefloor == "block4_2"){

			if(!isHandicapMode)
				list = block4_2Infohandicap.dictionary [name];
			else
				list = block4_2Info.dictionary[name];//
			
			if(list[0] == Point4_2handicap.evalator1){
				list2 = block4_1Info.dictionary ["thangkeo1"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo1"];
				lkk = block5_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point4_2handicap.evalator2)
			{
				list2 = block4_1Info.dictionary ["thangkeo2"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo2"];
				lkk = block5_1Info.LookatCamera ["thangkeo2"];
			}
			else{
				list2 = block4_1Info.dictionary ["thangmay"];
				cameraPostion = block5_1Info.PositnCamera ["thangmay"];
				lkk = block5_1Info.LookatCamera ["thangmay"];
			}
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block4_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			posss = block4_2Info.PositnCamera [name];
			lattt = block4_2Info.LookatCamera [name];
			havenextcamera = true;

			
		}
		else if(namefloor == "block3_4" || namefloor == "block1_4"){

			if(!isHandicapMode)
				list = block3_4Infohandicap.dictionary [name];
			else
				list = block3_4Info.dictionary[name];//
			
			if(list[0] == Point3_4handicap.evalator1){
				list2 = block3_1Info.dictionary ["thangkeo1"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo1"];
				lkk = block5_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point3_4handicap.evalator2){
				list2 = block3_1Info.dictionary ["thangkeo2"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo2"];
				lkk = block5_1Info.LookatCamera ["thangkeo2"];
			}
			else{
				list2 = block3_1Info.dictionary ["thangmay"];
				cameraPostion = block5_1Info.PositnCamera ["thangmay"];
				lkk = block5_1Info.LookatCamera ["thangmay"];
			}
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block"+namefloor[5]+"_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;

			posss = block3_4Info.PositnCamera [name];
			lattt = block3_4Info.LookatCamera [name];
			havenextcamera = true;

			
		}
		else if(namefloor == "block3_3" || namefloor == "block1_3"){

			if(!isHandicapMode)
				list = block3_3Infohandicap.dictionary [name];
			else
				list = block3_3Info.dictionary[name];//
			
			if(list[0] == Point3_3handicap.evalator1){
				list2 = block3_1Info.dictionary ["thangkeo1"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo1"];
				lkk = block5_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point3_3handicap.evalator2){
				list2 = block3_1Info.dictionary ["thangkeo2"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo2"];
				lkk = block5_1Info.LookatCamera ["thangkeo2"];
			}
			else{
				list2 = block3_1Info.dictionary ["thangmay"];
				cameraPostion = block5_1Info.PositnCamera ["thangmay"];
				lkk = block5_1Info.LookatCamera ["thangmay"];
			}
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block"+namefloor[5]+"_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			posss = block3_3Info.PositnCamera [name];
			lattt = block3_3Info.LookatCamera [name];
			havenextcamera = true;

		}
		else if(namefloor == "block3_2" || namefloor == "block2_2" || namefloor == "block1_2"){
			
			if(!isHandicapMode)
				list = block3_2Infohandicap.dictionary [name];
			else
				list = block3_2Info.dictionary[name];//
			
			if(list[0] == Point3_2handicap.evalator1){
				list2 = block3_1Info.dictionary ["thangkeo1"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo1"];
				lkk = block5_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point3_2handicap.evalator2){
				list2 = block3_1Info.dictionary ["thangkeo2"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo2"];
				lkk = block5_1Info.LookatCamera ["thangkeo2"];
			}
			else{
				list2 = block3_1Info.dictionary ["thangmay"];
				cameraPostion = block5_1Info.PositnCamera ["thangmay"];
				lkk = block5_1Info.LookatCamera ["thangmay"];
			}
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block"+namefloor[5]+"_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;

			posss = block3_2Info.PositnCamera [name];
			lattt = block3_2Info.LookatCamera [name];
			havenextcamera = true;

		}
		else if(namefloor == "block2_4"){
			if(!isHandicapMode)
				list = block2_4Infohandicap.dictionary [name];
			else
				list = block2_4Info.dictionary[name];//


			if(list[0] == Point2_4handicap.evalator1){
				list2 = block3_1Info.dictionary ["thangkeo1"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo1"];
				lkk = block5_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point2_4handicap.evalator2){
				list2 = block3_1Info.dictionary ["thangkeo2"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo2"];
				lkk = block5_1Info.LookatCamera ["thangkeo2"];
			}
			else{
				list2 = block3_1Info.dictionary ["thangmay"];
				cameraPostion = block5_1Info.PositnCamera ["thangmay"];
				lkk = block5_1Info.LookatCamera ["thangmay"];
			}
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block2_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			posss = block2_4Info.PositnCamera [name];
			lattt = block2_4Info.LookatCamera [name];
			havenextcamera = true;

		}
		else if(namefloor == "block2_3"){
			if(!isHandicapMode)
				list = block2_3Infohandicap.dictionary [name];
			else
				list = block2_3Info.dictionary[name];//
			
			
			if(list[0] == Point2_3handicap.evalator1){
				list2 = block3_1Info.dictionary ["thangkeo1"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo1"];
				lkk = block5_1Info.LookatCamera ["thangkeo1"];
			}
			else if(list[0] == Point2_3handicap.evalator2){
				list2 = block3_1Info.dictionary ["thangkeo2"];
				cameraPostion = block5_1Info.PositnCamera ["thangkeo2"];
				lkk = block5_1Info.LookatCamera ["thangkeo2"];
			}
			else{
				list2 = block3_1Info.dictionary ["thangmay"];
				cameraPostion = block5_1Info.PositnCamera ["thangmay"];
				lkk = block5_1Info.LookatCamera ["thangmay"];
			}
			
			listpoint = new Vector3[list.Length + list2.Length];
			
			orgP = GameObject.Find ("block2_1").transform.position;
			
			for (int i = 0; i<list2.Length; i++) {
				listpoint [i] = ratetio * list2 [i] + orgP;
			}
			
			orgP = GameObject.Find (namefloor).transform.position;
			
			cameraPostion = block2_3Info.PositnCamera [name];
			lkk = block2_3Info.LookatCamera[name];
			havenextcamera = true;

		}
		if (list2.Length > 0) {
			showVideoDireciton ();
		} else {			
			if(!dontStartTimer){
				hideInfomationTimer.Stop();
				hideInfomationTimer.Start();
				//Debug.Log("start time");
			}
			//StartCoroutine (LoadVideo (currentOfficeVideoIndex + videoType));
			StartCoroutine(Wait(loadOfficeVideoByPath));
		}

		for (int i = 0; i<(list.Length); i++) {			
			listpoint [i+list2.Length] = ratetio*list [i] + orgP;
		}
		//startAnimation.transform.position = listpoint [0];
		printPoint.transform.position = listpoint [listpoint.Length - 1];

		if (!isBathRoomSearch) {
			endAnimation.transform.position = listpoint [listpoint.Length - 1] - new Vector3(0,1.8f,0);
		}
		else {
			GameObject endpathroom = GameObject.Instantiate (endAnimation)as GameObject;
			endpathroom.name = "endpathroom";
			endpathroom.transform.position = listpoint [listpoint.Length - 1] - new Vector3(0,1.8f,0);
		}

		Vector3 start =listpoint [0]; 
		startPoint = true;
		for (int i=1; i<listpoint.Length; i++) {
			create_vessel (start, listpoint [i], i);
			start = listpoint [i];
		}

		if (isBathRoomSearch && name == "office221") {
			cameraPostion = block8_1Info.PositnCamera["posbathroom"];
			lkk = block8_1Info.LookatCamera["lookatbathroom"];
			isBathRoomSearch = false;
		}
		if (!(isBathRoomSearch && (name == "office82" || name == "office150" || name == "office44"))) {
			setCamera (cameraPostion, lkk);
		}
	}

	bool stillShowVideoDirection = false;
	void showVideoDireciton(){
		
		stillShowVideoDirection = true;
		((MovieTexture)VideoDirection.texture).Play ();
		GameObject.Find ("containVideoDirction").GetComponent<Animator> ().SetBool (m_showDirctionVideoId, true);
		//currentNameLayoutShow = "containVideoDirction";
	}
	bool haveShowVideoDirection = false;
	void hideVideoDirection(bool loadOfficeVideo){
		stillShowVideoDirection = false;
		haveShowVideoDirection = false;
		((MovieTexture)VideoDirection.texture).Stop ();
		GameObject.Find ("containVideoDirction").GetComponent<Animator> ().SetBool (m_showDirctionVideoId, false);		
		if (loadOfficeVideo) {
			StartCoroutine(Wait(loadOfficeVideoByPath));
		}
		//currentNameLayoutShow = null;
	}

	void loadOfficeVideoByPath(){
		StartCoroutine (LoadVideo (currentOfficeVideoIndex + videoType));
	}
	
	void showTransparent(string name, float height){

		GameObject ga = GameObject.Find (name);
		ga.transform.position = new Vector3 (ga.transform.position.x, height, ga.transform.position.z);

	}

	void showFullTransparent(string name, float height){
		GameObject ga = GameObject.Find (name);
		ga.transform.position = new Vector3 (ga.transform.position.x, height, ga.transform.position.z);
	}

	void setCamera(Vector3 postion, Vector3 lookAt){
		StartCoroutine(LerpToPosition(transitionDuration, postion, lookAt)); 
		target = lookAt;
	}
	float speedRotate = 20f;
	Vector3 target;
	public void arroundLeft(){		
		//flatStart.transform.LookAt (Camera.main.transform);
		Camera.main.transform.LookAt (target);
		Camera.main.transform.RotateAround (target, Vector3.up, speedRotate * Time.deltaTime);
	}
	public void arroundRight(){
		//flatStart.transform.LookAt (Camera.main.transform);
		Camera.main.transform.LookAt (target);
		Camera.main.transform.RotateAround (target, Vector3.down, speedRotate * Time.deltaTime);
	}
	public void arroundUp(){
		if (Vector3.Angle (Camera.main.transform.up, Vector3.up) < 85) {
			//flatStart.transform.LookAt (Camera.main.transform);
			Camera.main.transform.LookAt (target);
			Camera.main.transform.RotateAround (target, Camera.main.transform.right, speedRotate * Time.deltaTime);
		}
	}
	public void arroundDown(){
		if (Vector3.Angle (Camera.main.transform.up, Vector3.up) > 5) {
			//flatStart.transform.LookAt (Camera.main.transform);
			Camera.main.transform.LookAt (target);
			Camera.main.transform.RotateAround (target, -Camera.main.transform.right, speedRotate * Time.deltaTime);
		}
	}
	public void cameraForward(){
		//Vector3 forward = new Vector3 (Camera.main.transform.forward.x, Camera.main.transform.forward.y, Camera.main.transform.forward.z);
		Camera.main.transform.Translate (Camera.main.transform.forward * -5);
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
		resetTimer ();
		StartCoroutine (officeClick (null));
	}

    bool showRouteBettwenBlock = false;
    string nameOfSearchBlock,routeBettwenBlock;

	public void officeClickEvent(Button name){
		StartCoroutine (officeClick (name));
	}
	
	private IEnumerator officeClick(Button name){
		string blcName;
		string officeIndex;
		if (searchbyname) {			
			GameObject.Find ("PanelContainresults").GetComponent<Animator> ().SetBool (m_OpenParameterId, false);
			currentNameLayoutShow = null;
			searchbyname = false;
		}else if (searchbynumber) {			
			GameObject.Find ("PanelContainresults").GetComponent<Animator> ().SetBool (m_OpenParameterId, false);
			currentNameLayoutShow = null;
			searchbynumber = false;
		}

		if (name != null) {
			blcName = name.image.sprite.name;
			officeIndex = blcName.Split(new string[]{"+"},System.StringSplitOptions.None)[0];

			//Debug.Log(blcName);
			
			GameObject.Find ("containBlockInfomation").GetComponent<Animator> ().SetBool (m_showScreenParameterId, true);
			reservedBtn.GetComponent<Animator> ().SetBool (m_ShowEventParameterId, true);

			string numberOfFloor = officeIndex[2].ToString();
			//Debug.Log(officeIndex[1]);
			if(officeIndex[1] != '8' && officeIndex[1] != '7'){
				numberOfFloor = (int.Parse(numberOfFloor) - 1).ToString();
			}
			if(currentLanguage == null || currentLanguage == "")
				floorOfficeOn.text = "Floor "+numberOfFloor + " - " + DicNumberOffice[blcName];
			else floorOfficeOn.text = "Andar "+numberOfFloor + " - " + DicNumberOffice[blcName];
			officePhoneNumber.text = DicphoneNumber[blcName];
			officeLogo.sprite = name.image.sprite;
			officeShowName.text = listNameOffie[blcName];

			if(officeIndex.IndexOf("b8")<0)
			{
				showButton(NextBtn);
				nameOfSearchBlock = officeIndex;
				officeIndex = "b81231";
				showRouteBettwenBlock = true;
				routeBettwenBlock = "b91"+nameOfSearchBlock[1];
			}
		}else if(showRouteBettwenBlock){
			officeIndex = routeBettwenBlock;
			showRouteBettwenBlock = false;
		}else {
			officeIndex = nameOfSearchBlock;
			madeButtonTransparent(NextBtn);
		}


		hideSearchBlock ();

		stopRoute ();
				
		hideBlck (currentBlock, currentFloor);

		int Block = int.Parse (officeIndex [1].ToString ());
		int Floor = int.Parse (officeIndex [2].ToString ());
		
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
		currentOfficeVideoIndex = officeIndex;
		getRoute ("office" + officeIndex.Substring (3));
		//StartCoroutine (LoadVideo (officeIndex + videoType));
		StartCoroutine (waitforresult());
		yield return null;
	}

	string currentOfficeVideoIndex = null;

	public IEnumerator waitforresult(){
		yield return new WaitForSeconds(1F);
		hideFullTransparent ();
	}
	Vector3 hidePrintPoint = new Vector3 (0, 1000, 0);
	void stopRoute(){
		//startAnimation.transform.position = hideStartPoint;
		endAnimation.transform.position = hideEndPoint;
		printPoint.transform.position = hidePrintPoint;
		
		foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
		{
			string nameobj = gameObj.name;
			if(nameobj == "lineDirection" || nameobj == "arrowsssss" || nameobj == "endpathroom")
			{
				Destroy(gameObj);
			}
		}
	}

	bool isShowBlock = false;
	bool[] blockAnimation = new bool[]{true, true, true, true, true, true ,true, true};
	public void showBlock(int blockNumber){
		resetTimer ();
		//gotoblock1
		isShowBlock = true;
		GameObject.Find ("gotoblock" + blockNumber).GetComponent<Animator> ().SetBool (m_showAnimationBlockPressed, blockAnimation [blockNumber - 1]);
		blockAnimation [blockNumber - 1] = !blockAnimation [blockNumber - 1];
		if (blockNumber != 6)
			setCamera (orginalPostion, center);
		else
			setCamera (PositnBlock["posBlock6"], PositnBlock["lookatBlock6"]);

		stopRoute ();
		hideBlck (currentBlock, currentFloor);

		currentBlock = blockNumber;
		currentFloor = 1;
		gotoFloor1 ();
		isShowBlock = false;
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

	void cleanAllOffice(int begin){
		for (int i = begin; i<maxOffice; i++) {
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
		bool haveResult = false;
		cleanTexture ();
		tempArray.Clear ();
		sortDic.Clear ();
		int index = 0;
		foreach (string x in infomationForSearch) {
			if(x!=""){
				string[] info = x.Split(new string[]{" "},System.StringSplitOptions.None);
				//Debug.Log(convertToUtf8(info[1])[0]);
				if (checkCompare(name, convertToUtf8(info[1])[0]) && info[1] != "for_empty_office") {					
					index++;
					haveResult=true;
					tempArray.Add(info[1]+"_"+index);
					sortDic.Add(info[1]+"_"+index,info);			

				}
			}
		}
		if (haveResult) {

			tempArray.Sort();
			foreach(string names in tempArray){
				string[] info = sortDic[names];								
				StartCoroutine(loadTexture4Office(info[0], convertToUtf8(toNormalString(info[1])), toNormalString(info[4]), currentIndex, null, toNormalString(info[2])));
				if(currentIndex<maxOffice)
					currentIndex++;	
			}

			searchbyname = true;
			GameObject.Find ("PanelContainresults").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
			currentNameLayoutShow = "PanelContainresults";
			cleanAllOffice (currentIndex);
		} else
			hideFullTransparent ();
	}

	private bool checkCompare(char c1, char c2){
		switch (c1) {
		case 'a':
			if("a á ắ ấ à ằ ầ ặ ậ A Á Ắ Ấ À Ằ Ầ Ặ Ậ".IndexOf(c2)>=0)
				return true;
			else return false;
			break;
		case 'e':
			if("e é ế è ề ẹ ệ E É Ế È Ề Ẹ".IndexOf(c2)>=0)
				return true;
			else return false;
			break;
		case 'i':
			if("i í ì ị I Í Ì Ị".IndexOf(c2)>=0)
				return true;
			else return false;
			break;
		case 'o':
			if("o ò ồ ố ó ọ ộ O Ò Ồ Ố Ó Ọ Ộ".IndexOf(c2)>=0)
				return true;
			else return false;
			break;
		case 'u':
			if("u ú ù ụ U Ú Ù Ụ".IndexOf(c2)>=0)
				return true;
			else return false;
			break;
		default:
			if(c1 == c2.ToString().ToLower()[0])return true;
			else return false;
			break;
		}
	}
	
	private void cleanTexture(){
		TextureBtn.Clear ();
		nameOffices.Clear ();
		listNameOffie.Clear ();
		currentIndex = 0;
	}

	bool stillUpdatingLogo = false;
	string oldUpdate = "";
	int countDown = 0;

	public IEnumerator updateLogo(){
		stillUpdatingLogo = true;
		if (firstLoad) {			
			using (var webClient = new System.Net.WebClient()) {
				oldUpdate = webClient.DownloadString (IP+"/src/update");
			}
			foreach (string x in infomationForSearch) {
				if (x != null) {
					if (x != "") {
						string filename = x.Substring (0, x.IndexOf (" "));

						if (GameObject.Find (filename) != null) {
							countDown++;
							StartCoroutine (updateIcon (IP + "src/" + filename + imageType, filename));
						}
						yield return new WaitForSeconds(0.1F);
					}
				}
			}
			while(countDown!=0)
				yield return new WaitForSeconds(1F);
			firstLoad=false;
		} else {
			//Debug.Log ("Update icon for office !!!!");
			string result;
			using (var webClient = new System.Net.WebClient()) {
				result = webClient.DownloadString (IP+"/src/update");
				if(result != oldUpdate){
					string[] listNewUpdate = result.Split(new string[]{":"},System.StringSplitOptions.None);
					for(int j=0;j<listNewUpdate.Length;j++)
					{
						string x = listNewUpdate[j];
						//Debug.Log(x);
						if(x!=null){
							if (x != "") {
								//Debug.Log(filename);
								if (GameObject.Find (x) != null) {
									StartCoroutine (updateIcon (IP + "src/" + x + imageType, x));
								}
							}
						}
						yield return new WaitForSeconds(0.1F);
					}
				}
				oldUpdate = result;
			}
		}		
		stillUpdatingLogo = false;
		yield return null;
	}
	string oldLanguage = null;
	public void changeLanguare(string language){
		resetTimer ();
		if (oldLanguage != language) {
			currentLanguage = language;
			dontAddhandi = true;
			isHandicapMode = !isHandicapMode;
			handicap = !handicap;
			GameObject.Find("handicap").GetComponent<Image>().sprite = ResourcesDictionary[currentLanguage+"handicap"];
			handicapMode();
			dontAddhandi = false;
			oldLanguage = language;
			if(currentLanguage == null || currentLanguage == "")
				floorOfficeOn.text = floorOfficeOn.text.Replace("Andar","Floor");
			else floorOfficeOn.text = floorOfficeOn.text.Replace("Floor","Andar");
		}
	}

	
	private IEnumerator updateIcon(string url,string nameobject)
	{
		//Debug.Log (url);

		GameObject plane = GameObject.Find (nameobject);
		
		var rend = plane.GetComponent<Renderer>();
		
		WWW www = new WWW(url);
		yield return www;
		rend.material.mainTexture = www.texture;
		countDown--;
	}

	Dictionary<string,Sprite> spriteSave = new Dictionary<string, Sprite> ();
	Dictionary<string, string> DicphoneNumber = new Dictionary<string, string> ();
	Dictionary<string, string> DicNumberOffice = new Dictionary<string, string> ();
	Dictionary<string, string> listNameOffie = new Dictionary<string, string> ();

	private IEnumerator loadTexture4Office(string name, string nameOffice, string phoneNumber, int index,string subNameOffice, string officeNumber)
	{
		//if (gameObject != null) 
		{
			Text texts = null;
			Button buttons = null;
			
			TextureBtn.Add (name);
			nameOffices.Add (nameOffice);
			if (subNameOffice != null) {
				listNameOffie.Add (name, subNameOffice);
			} else {
				listNameOffie.Add (name, nameOffice);
			}
			if (index < maxOffice) {
				
				GameObject.Find ("p" + index).GetComponent<Image> ().enabled = true;				
				texts = GameObject.Find ("of" + index).GetComponent<Text> ();
				buttons = GameObject.Find ("Btn" + index).GetComponent<Button> ();
			}
			Sprite sprite;
			if (!spriteSave.ContainsKey (name)) {
				/*GameObject gameobjects = GameObject.Find (name);
				Texture2D texture = (Texture2D)gameobjects.GetComponent<Renderer> ().material.mainTexture;*/

				/*string url = IP + "logo/" + name + imageType;
				Texture2D texture = null;
				WWW imageURLWWW = new WWW (url);		
				yield return imageURLWWW;		
				if (imageURLWWW.texture != null) {
					texture = imageURLWWW.texture;
				}*/

				string fullPathFile = "C:/server/logo/"+name+imageType;
				byte[] data = File.ReadAllBytes(fullPathFile);
				Texture2D texture = new Texture2D(87, 87, TextureFormat.ARGB32, false);
				texture.LoadImage(data);

				sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), Vector2.zero);
				spriteSave.Add (name, sprite);
				//Debug.Log(name+":"+texture.width);
			} else {
				sprite = spriteSave [name];
			}
			if (!DicphoneNumber.ContainsKey (name)) {
				DicphoneNumber.Add (name, phoneNumber);
			}
			if(!DicNumberOffice.ContainsKey(name)){
				DicNumberOffice.Add(name, officeNumber);
			}
			sprite.name = name;
			if (buttons != null && texts != null) {

				texts.enabled = true;
				texts.text = nameOffice;

				buttons.enabled = true;
				buttons.image.sprite = sprite;
				Color c = buttons.targetGraphic.color;
				c.a = 255f;
				buttons.targetGraphic.color = c;
			}
		}
		yield return null;
	}

	int maxEvent = 3,currentEvent = 0;
	Dictionary<string, events> eventInf = new Dictionary<string, events> ();
	List<string> eventId = new List<string> ();
	private IEnumerator loadTexture4Event(string id, string title, string dateTime, string description, int index)
	{
		//if (gameObject != null) 
		{
			//Debug.Log(title);
			Sprite sprite;
			if(!eventInf.ContainsKey(id)){
				eventId.Add(id);
				Texture2D texture = null;
				var url = IP + "event/"+id;
				//Debug.Log(url);
				WWW imageURLWWW = new WWW (url);		
				yield return imageURLWWW;		
				if (imageURLWWW.texture != null) {
					texture = imageURLWWW.texture;
				}
				sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), Vector2.zero);
				eventInf.Add(id,new events( 
				                           sprite, 
				                           convertToUtf8(toNormalString(title)), 
				                           convertToUtf8(toNormalString(dateTime)), 
				                           convertToUtf8(toNormalString(description))));
			}
			else {
				sprite = eventInf[id].sprite;
			}


			if (index < maxEvent) {

				if(index == 0){
					evnt1.enabled = true;
				}else if(index == 1){
					evnt2.enabled = true;
				}else if(index == 2){
					evnt3.enabled = true;
				}

				GameObject.Find ("maineventsImg" + (index+1)).GetComponent<Image> ().sprite = sprite;
				
				GameObject.Find ("evntTitle" + (index+1)).GetComponent<Text> ().text = convertToUtf8(toNormalString(title));
				
				GameObject.Find ("eventTime" + (index+1)).GetComponent<Text> ().text = convertToUtf8(toNormalString(dateTime));
				
				GameObject.Find ("eventDescription" + (index+1)).GetComponent<Text> ().text = convertToUtf8(toNormalString(description));
				currentEvent++;
			}
		}
		yield return null;
	}

	string currentNameLayoutShow;

	public void segementSearchPress(){
		resetTimer ();
		offset = 0;
		hideEventAndInfomation ();
		exitvideo ();
		hideOldeScreen ();
		showFullTransparent ();
		GameObject.Find ("Panelcontainlocation").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
		currentNameLayoutShow = "Panelcontainlocation";
	}

	public void selectLocationPress(bool master){
		GameObject.Find ("Panelcontainlocation").GetComponent<Animator> ().SetBool (m_OpenParameterId, false);
		GameObject.Find ("Panelcontainsegments").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
		currentNameLayoutShow = "Panelcontainsegments";
		updateArrow (master);
		StartCoroutine (loadTextureSegment (master));
	}

	bool isMaster = false;
	private IEnumerator loadTextureSegment(bool master)
	{
		string handi = null;
		isMaster = master;
		if (isHandicapMode)
			handi = "handi";

		{
			for(int i = 0;i<15;i++){
				Button btn = GameObject.Find("SG"+i).GetComponent<Button>();
				btn.enabled = true;
				Color c = btn.targetGraphic.color;
				c.a = 255f;
				btn.targetGraphic.color = c;
				btn.image.sprite = ResourcesDictionary[currentLanguage+segmentNameArray[i]+handi];
			}
		}
		yield return null;
	}

	
	private IEnumerator loadTextureSubSegment()
	{
		string handi = null;
		if (isHandicapMode)
			handi = "handi";
		
		{
			for(int i = 0;i<15;i++){
				Button btn = GameObject.Find("SSG"+i).GetComponent<Button>();
				btn.enabled = true;
				Color c = btn.targetGraphic.color;
				c.a = 255f;
				btn.targetGraphic.color = c;
				btn.image.sprite = ResourcesDictionary[currentLanguage+ subSegmentMedic[i]+handi];
			}
		}
		yield return null;
	}

	int currentNumberIndex = 0;
	public void nextNumber(){
		currentNumberIndex = (currentNumberIndex + 1)%3;
		if (currentNumberIndex == 0) {
			contain1.enabled = true;
			contain2.enabled = false;
			contain3.enabled = false;
		} else if (currentNumberIndex == 1) {
			contain1.enabled = false;
			contain2.enabled = true;
			contain3.enabled = false;
		} else {
			contain1.enabled = false;
			contain2.enabled = false;
			contain3.enabled = true;
		}
	}

	public void previousNumber(){
		currentNumberIndex = (currentNumberIndex + 2)%3;
		if (currentNumberIndex == 0) {
			contain1.enabled = true;
			contain2.enabled = false;
			contain3.enabled = false;
		} else if (currentNumberIndex == 1) {
			contain1.enabled = false;
			contain2.enabled = true;
			contain3.enabled = false;
		} else {
			contain1.enabled = false;
			contain2.enabled = false;
			contain3.enabled = true;
		}
	}

	public void nextSegment(){
		StartCoroutine (nextSgm ());
	}

	
	public void nextSubSegment(){
		StartCoroutine (nextSubSgm ());
	}
		
	public void previosSubSegment(){
		StartCoroutine (nextSubSgm ());
	}

	public void previosSegment(){
		StartCoroutine (previSgm ());
	}
	
	int offset = 0;

	private IEnumerator nextSgm(){
		if (offset >= 45)
			offset = 0;
		else
			offset += 15;

		{
			string handi = null;
			if(isHandicapMode)
				handi = "handi";
			for (int i = 0; i<15; i++) {
				Button btn = GameObject.Find ("SG" + i).GetComponent<Button> ();
				if ((i + offset) < 57) {
					btn.enabled = true;
					Color c = btn.targetGraphic.color;
					c.a = 255f;
					btn.targetGraphic.color = c;
					btn.image.sprite = ResourcesDictionary[currentLanguage+segmentNameArray [i + offset]+handi];
				}else {
					Color c = btn.targetGraphic.color;
					c.a = 0f;
					btn.targetGraphic.color = c;
					btn.enabled = false;
				}
			}
		}
		yield return null;
	}

	private IEnumerator previSgm(){
		if (offset == 0)
			offset = 45;
		else
			offset -= 15;
		
		{
			string handi = null;
			if(isHandicapMode)
				handi = "handi";
			for (int i = 0; i<15; i++) {
				Button btn = GameObject.Find ("SG" + i).GetComponent<Button> ();
				if ((i + offset) < 57) {
					btn.enabled = true;
					Color c = btn.targetGraphic.color;
					c.a = 255f;
					btn.targetGraphic.color = c;
					btn.image.sprite = ResourcesDictionary[currentLanguage+segmentNameArray [i + offset]+handi];
				}else {
					Color c = btn.targetGraphic.color;
					c.a = 0f;
					btn.targetGraphic.color = c;
					btn.enabled = false;
				}
			}
		}
		yield return null;
	}

	int subOffset = 0;
	private IEnumerator nextSubSgm(){
		if (subOffset >= 15)
			subOffset = 0;
		else
			subOffset += 15;
		
		{
			string handi = null;
			if(isHandicapMode)
				handi = "handi";
			for (int i = 0; i<15; i++) {
				Button btn = GameObject.Find ("SSG" + i).GetComponent<Button> ();
				if ((i + subOffset) < 21) {
					btn.enabled = true;
					Color c = btn.targetGraphic.color;
					c.a = 255f;
					btn.targetGraphic.color = c;
					btn.image.sprite = ResourcesDictionary[currentLanguage+subSegmentMedic [i + subOffset]+handi];
				}else {
					Color c = btn.targetGraphic.color;
					c.a = 0f;
					btn.targetGraphic.color = c;
					btn.enabled = false;
				}
			}
		}
		yield return null;
	}

	void hideOldeScreen(){
		//Debug.Log ("name of layout:" + currentNameLayoutShow);
		searchInsub = false;
		madeButtonTransparent (NextBtn);
		if (currentNameLayoutShow != null) {
			GameObject.Find (currentNameLayoutShow).GetComponent<Animator> ().SetBool (m_OpenParameterId, false);
			currentNameLayoutShow = null;
			hideNumberLayout();
			hideEventLayout ();

		}
	}

	public void hideNumberLayout(){
		contain1.enabled = false;
		contain2.enabled = false;
		contain3.enabled = false;
	}

	public void hideEventLayout(){
		evnt1.enabled = false;
		evnt2.enabled = false;
		evnt3.enabled = false;
	}

	public void EventPress(){
		resetTimer ();
		hideEventAndInfomation ();
		if (currentNameLayoutShow != "Panelcontainevents") {
			currentEvent = 0;
			exitvideo ();
			hideOldeScreen ();
			showFullTransparent ();
			int index = 0;
			foreach (string x in infomationEvents) {
				if (x != "") {
					string[] info = x.Split (new string[]{" "}, System.StringSplitOptions.None);
					StartCoroutine (loadTexture4Event (info [0], info [1], info [2], info [3],index));
					index++;
				}
			}
			GameObject.Find ("Panelcontainevents").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
			currentNameLayoutShow = "Panelcontainevents";
		}
	}

	public void ClosePress(){
		//if(currentNameLayoutShow == "Panelcontainevents") 
		{
			hideOldeScreen();
			hideFullTransparent ();
		}
	}

	public void nextEvent(){
		if (eventId.Count > maxEvent) {
			for (int i = 1; i <= maxEvent; i++) {
				if (currentEvent < eventId.Count) {

					events evs = eventInf[eventId[currentEvent]];

					GameObject.Find ("maineventsImg" + i).GetComponent<Image> ().sprite = evs.sprite;
					
					GameObject.Find ("evntTitle" + i).GetComponent<Text> ().text = evs.title;

					GameObject.Find ("eventTime" + i).GetComponent<Text> ().text = evs.dateTime;

					GameObject.Find ("eventDescription" + i).GetComponent<Text> ().text = evs.description;

					currentEvent++;
					if(i == 1){
						evnt1.enabled = true;
					}else if(i == 2){
						evnt2.enabled = true;
					}else if(i == 3){
						evnt3.enabled = true;
					}
				} else {			
					if(i == 1){
						evnt1.enabled = false;
					}else if(i == 2){
						evnt2.enabled = false;
					}else if(i == 3){
						evnt3.enabled = false;
					}
				}
			}
			if (currentEvent >= eventId.Count)
				currentEvent = 0;
		}
	}

	public void preEvent(){
		currentEvent = currentEvent - maxEvent;
		if (currentEvent < 0)
			currentEvent = ((int)(eventId.Count - 1) / maxEvent) * maxEvent;
		
		currentEvent = currentEvent - maxEvent;
		if (currentEvent < 0)
			currentEvent = ((int)(eventId.Count - 1) / maxEvent) * maxEvent;

		//Debug.Log (currentEvent);
		nextEvent ();
	}

	bool searchInsub = false;
	public void searchOfficeBySegment(int index){
		string segement,nameOfContainPanel = "Panelcontainsegments";
		if (searchInsub) {
			segement = subSegmentMedic [index + subOffset];
			searchInsub = false;
		}
		else
			segement = segmentNameArray [index + offset];
		if (segement.IndexOf ("submedic") == 0)
			nameOfContainPanel = "Panelcontainsubsegments";
		Debug.Log (offset + "," + segement);
		if (segement == "medic") {			
			subOffset = 0;
			StartCoroutine (loadTextureSubSegment ());
			resetTimer ();
			hideEventAndInfomation ();
			exitvideo ();
			hideOldeScreen ();
			showFullTransparent ();
			GameObject.Find ("Panelcontainsubsegments").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
			currentNameLayoutShow = "Panelcontainsubsegments";
			searchInsub = true;
		} else
			StartCoroutine (searchbySegement (segement,nameOfContainPanel));
	}

	private IEnumerator searchbySegement(string segement,string nameOfContainPanel){
		bool haveResult = false;
		cleanTexture ();
		foreach (string x in infomationForSearch) {
			if (x != "") {
				string[] info = x.Split (new string[]{" "}, System.StringSplitOptions.None);
				if ((isMaster && info [0].ToLower () [1] == '8') || (!isMaster && info [0].ToLower () [1] != '8')) {
					if (info [3].ToLower ().IndexOf (segement) >= 0 && info [1] != "for_empty_office") {
						haveResult = true;
						StartCoroutine (loadTexture4Office (info [0], convertToUtf8(toNormalString(info [1])), toNormalString(info[4]), currentIndex, null, toNormalString(info[2])));
						if(currentIndex<maxOffice)
							currentIndex++;
					}
				}
			}
		}
		
		GameObject.Find (nameOfContainPanel).GetComponent<Animator> ().SetBool (m_OpenParameterId, false);
		
		if (haveResult) {
			searchbyname = true;
			GameObject.Find ("PanelContainresults").GetComponent<Animator> ().SetBool (m_OpenParameterId, true);
			currentNameLayoutShow = "PanelContainresults";
			cleanAllOffice (currentIndex);
		} else
			hideFullTransparent ();
		yield return null;
	}

	bool isBathRoomSearch = false;

	public void bathRoomPress(){
		resetTimer ();
		hideEventAndInfomation ();
		exitvideo ();
		hideOldeScreen ();
		hideFullTransparent ();
		isBathRoomSearch = true;
		string blcName = "b8144";

		hideSearchBlock ();

		stopRoute ();
		
		hideBlck (currentBlock, currentFloor);
		
		int Block = int.Parse (blcName [1].ToString ());
		int Floor = int.Parse (blcName [2].ToString ());
				
		showBlck (Block, 1);
		listNameCurrentBlock.Add ("block"+Block + "_1");
		currentBlock = Block;
		currentFloor = Floor;		
		getRoute ("office44");
		getRoute ("office82");
		getRoute ("office150");
		getRoute ("office221");
	}
	
	public void next(){
		if (TextureBtn.Count > maxOffice) {
			for (int i = 0; i<maxOffice; i++) {
				if (currentIndex < TextureBtn.Count) {
					//Debug.Log(currentIndex);
					GameObject.Find ("p" + i).GetComponent<Image> ().enabled = true;
					
					var t = GameObject.Find ("of" + i).GetComponent<Text> ();
					t.enabled = true;
					t.text = nameOffices[currentIndex];
					
					Sprite sprite = spriteSave[TextureBtn [currentIndex]];
					var plane = GameObject.Find ("Btn" + i).GetComponent<Button> ();
					plane.enabled=true;
					plane.image.sprite = sprite;
					Color c = plane.targetGraphic.color;
					c.a = 255f;
					plane.targetGraphic.color = c;
					currentIndex++;
				} else {

					GameObject.Find ("p" + i).GetComponent<Image> ().enabled = false;
					
					GameObject.Find ("of" + i).GetComponent<Text> ().enabled = false;
					
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
	
	private int m_ShowEventParameterId;
	private int m_OpenParameterId;
	private int m_FullScreenParameterId;
	private int m_showScreenParameterId;
	private int m_showDirctionVideoId;
	private int m_showAnimationButtonPressed;
	private int m_showAnimationBlockPressed;
	const string k_showEventTransitionName = "ShowEvent";
	const string k_OpenTransitionName = "Open";
	const string k_FullScreenTransitionName = "FullScreen";
	const string k_showScreenTransitionName = "Show";
	const string k_showDirctionVideoTransitionName = "ShowVideoDirction";
	const string k_buttonPressTransitionName = "Pressed";
	const string k_buttonBlockPressTransitionName = "BlockClick";
	bool searchbyname = false;
	public void typeButton(Button btn){
		StartCoroutine(typeButtonAni (btn.name.ToLower () [0]));
	}
	
	public IEnumerator typeButtonAni(char name){
		GameObject.Find ("Panelcontainkey").GetComponent<Animator> ().SetBool (m_OpenParameterId, false);
		//yield return new WaitForSeconds(1F);
		searchOffice (name);
		yield return null;
	}
	int currentCarousel = 0,timeDisplay = -100;
	bool shownextCarousel = false,firstLoadCarousel = true;

	Dictionary<string, Texture> dicImageCarousel = new Dictionary<string, Texture> ();
	
	
	MovieTexture movieTextureCarousel;
	
	private IEnumerator loadNextVideo(){
		
		string[] infos = infomationCarousel [currentCarousel].Split (new string[]{" "}, System.StringSplitOptions.None);
		string filename = infos [0];
		int timeDisplay = int.Parse (infos [1]);
		
		if (timeDisplay <= 0) {
			
			WWW www = new WWW(IP + "crs/" + filename);
			
			while(!www.isDone) yield return 1;
			
			if (www.bytes.Length > 0) 
			{
				string fullPath = fullPathVideoFolder + "crs/" + filename;
				Debug.Log (fullPath + "finished download!!!");
				File.WriteAllBytes (fullPath, www.bytes);
			}
			
		}		
	}
	
	
	private IEnumerator loadcrosel () {
		
		if (infomationCarousel [currentCarousel] != "" && infomationCarousel [currentCarousel] != null) {
			carouselTimer.Stop ();
			string[] infos = infomationCarousel [currentCarousel].Split (new string[]{" "}, System.StringSplitOptions.None);
			string filename = infos [0];
			timeDisplay = int.Parse (infos [1]);
			//Debug.Log(filename+timeDisplay);
			if (timeDisplay > 0) {
				var url = IP + "crs/" + filename;
				Texture imageTexture = null;
				
				if (!dicImageCarousel.ContainsKey (url)) {
					
					//Debug.Log("down car");
					
					WWW imageURLWWW = new WWW (url);        
					yield return imageURLWWW;       
					if (imageURLWWW.texture != null) {
						imageTexture = (Texture)imageURLWWW.texture;
					}
					dicImageCarousel.Add (url, imageTexture);
				} else {
					//Debug.Log("use old car");
					imageTexture = dicImageCarousel [url];
				}
				movieCrsPlayer.UnloadMovie();
				Videocarosel.texture = imageTexture;
				carouselTimer.Interval = timeDisplay * 1000;
				carouselTimer.Start ();
			} else {
				if(Videocarosel.texture!=null)
					Videocarosel.texture = null;
				/*if(haveNextData){
					haveNextData = false;
				}else {
					/*
					var url = IP + "crs/" + filename;					
					//Debug.Log (url);					
					
					WWW www = new WWW(url);
					
					while(!www.isDone) yield return 1;
					
					if (www.bytes.Length > 0) 
					{						
						string fullPath = fullPathVideoFolder + "/" + filename;
						File.WriteAllBytes (fullPath, www.bytes);
					}
				}*/
				//Debug.Log(fullPathVideoFolder + filename);
				carouselTimer.Interval = movieCrsPlayer.playVideoFromFile(fullPathVideoFolder + "crs/" + filename) * 1000;
				carouselTimer.Start ();
			}
		} else {
			if(infomationCarousel.Length>1)
				shownextCarousel = true;
		}
		currentCarousel++;
		currentCarousel = currentCarousel % (infomationCarousel.Length - 1);
		//StartCoroutine (loadNextVideo ());
		yield return null;
	}
	MovieTexture movieTextureDirctionStair;
	MovieTexture movieTextureDirctionElevator;
	private IEnumerator loadVideoFromResources(){

		movieTextureDirctionElevator = Resources.Load<MovieTexture> ("ElevatorUp");
		while (!movieTextureDirctionElevator.isReadyToPlay) {
			yield return null;
		}


		movieTextureDirctionElevator.loop = true;
		movieTextureDirctionElevator.Stop ();

		movieTextureDirctionStair = (MovieTexture)VideoDirection.texture;
		movieTextureDirctionStair.loop = true;
		movieTextureDirctionStair.Stop ();

		yield return null;
	}

	private IEnumerator loadAllResources(){

		foreach(string name in nameOfAllResource){
			//if(Resources.Load<Sprite>(name)!=null)
			ResourcesDictionary.Add(name,Resources.Load<Sprite>(name));
			//else Debug.Log(name);
		}
		
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
	
	public float distance = 3f;
	float deltad = 0f;
	bool startPoint = false;

	void create_vessel(Vector3 p1, Vector3 p2, int index) {

		float d = Vector3.Distance (p1, p2);
		Vector3 v = p2 - p1;
		int num = (int)((d + deltad) / distance);
		for (int i = 1; i<=num; i++) {

			Vector3 start = p1 + ((i * distance - deltad) / d) * v;

			GameObject ar = GameObject.Instantiate (arrow)as GameObject;
			ar.name = "arrowsssss";
			arrow scri = ar.GetComponent<arrow> ();
			scri.beginMove (listpoint, start, index);
			if(startPoint){
				scri.thisIsStartPoint();
				startPoint = false;
			}

		}
		deltad = (d + deltad) - num * distance;


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

	bool havenewcameraanimation = false, stillanimation = false;


	IEnumerator LerpToPosition(float lerpSpeed, Vector3 newPosition, Vector3 lookat)
	{   
		fullScreenTimer.Stop ();
		hideInfomationTimer.Stop ();
		bool hncmr = false;
		if (havenextcamera) {
			hncmr = true;
			//Debug.Log("hhhhhhhhhhh");
		}
		if (stillanimation)
			havenewcameraanimation = true;
		while (havenewcameraanimation) {
			yield return null;
		}
		stillanimation = true;

		float t = 0.0f;
		Vector3 startingPos = Camera.main.transform.position;
		while (t < 1.0f && !havenewcameraanimation)
		{
			t += Time.deltaTime * (Time.timeScale / lerpSpeed);

			var targetRotation = Quaternion.LookRotation(lookat - Camera.main.transform.position, Vector3.up);
			Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, targetRotation, t); 

			yield return null;

		}
		t = 0.0f;
		while (t < 1.0f && !havenewcameraanimation)
		{
			t += Time.deltaTime * (Time.timeScale / lerpSpeed);			
			
			Camera.main.transform.position = Vector3.Lerp(startingPos, newPosition, t);
			Camera.main.transform.LookAt(lookat);
			
			yield return null;
		}
		if (haveShowVideoDirection) {
			hideVideoDirection (true);
			//hideInfomationTimer.Stop();
			//hideInfomationTimer.Start();
			//Debug.Log("start time");
		}
		if (hncmr) {
			moveNextCamera.Start();
			havenextcamera = false;
			if(stillShowVideoDirection)
				haveShowVideoDirection = true;
		}
		havenewcameraanimation = false;
		stillanimation = false;
		resetTimer ();
		if (humanPress)
			hideInfomationTimer.Start ();
		humanPress = true;
		yield return null;
	}

	public void hideEventAndInfomation(){
		GameObject.Find ("containBlockInfomation").GetComponent<Animator> ().SetBool (m_showScreenParameterId, false);
		reservedBtn.GetComponent<Animator> ().SetBool (m_ShowEventParameterId, false);
	}

	
	IEnumerator updateTimeLable(){
		showTime.text = System.DateTime.Now.ToString ("HH:mm:ss");
		yield return null;
	}
		
	private IEnumerator Wait(System.Action callback)
	{
		//while(movieTextureCarousel.isPlaying)
		//yield return new WaitForSeconds(0.1F);//for 32bit
		yield return new WaitForSeconds(1.0F);//for 64bit
		if(callback != null) callback();
	}
	
	private IEnumerator playOfficeVideo(){
		//yield return new WaitForSeconds(0.1F);
		isShowVideo (true);
		yield return null;
	}

	string cameraangle = "building_Data\\data\\camereangle.txt";
	string pointPostions = "building_Data\\data\\points.txt";
	string officePostion = "building_Data\\data\\officePostion.txt";
	string linepostion = "building_Data\\data\\line.txt";
	string result = "",resultPostion = "",frontPoints = "";
	int index = 1,blckk=7,flor=1;
	string nameCameraPostion;

	void resetTimer(){		
		fullScreenTimer.Stop ();
		fullScreenTimer.Start ();
	}

	public string toNormalString(string input)
	{
		return input.Replace("|enter|", System.Environment.NewLine).Replace("|space|", " ").Replace("|dotdot|", ":");
	}

	bool humanPress = true;

	void Update () {

		if (isStopApplication) {

			Debug.Log ("stop");

		} else {
			/*
			if (leftpress || Input.GetKey (KeyCode.A)) {
				arroundLeft ();
			} else if (rightpress || Input.GetKey (KeyCode.D)) {
				arroundRight ();
			} else if (uppress || Input.GetKey(KeyCode.W)) {
				arroundUp ();
			} else if (downpress || Input.GetKey(KeyCode.S)) {
				arroundDown ();
			}
			*/
		//if (!stillanimation) 
			{
				if (Input.touchCount > 0) {

					if(isShowFullScreen){
						changeStatusScreen = true;
						isShowFullScreen = false;
						fullScreenTimer.Stop();
					}else resetTimer();
					/*
					if(Input.GetTouch(0).phase == TouchPhase.Began){
						if(isShowFullScreen){
							changeStatusScreen = true;
							isShowFullScreen = false;
							fullScreenTimer.Stop();
						}else resetTimer();
					}
					else */
					if(Input.GetTouch(0).phase == TouchPhase.Moved){
						// Get movement of the finger since last frame
						Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
						
						if(touchDeltaPosition.x < 0){
							arroundRight ();
						}
						else if(touchDeltaPosition.x > 0){
							arroundLeft ();
						}
					}
					/*else if(Input.GetTouch(0).phase == TouchPhase.Ended){
						if(isShowFullScreen){
							changeStatusScreen = true;
							isShowFullScreen = false;
							fullScreenTimer.Stop();
						}else resetTimer();
					}*/

				}


				/*

			if (Input.GetAxis ("Mouse X") < 0) {
				//Code for action on mouse moving left
				//Debug.Log("Mouse moved left");
					arroundLeft ();
					if(isShowFullScreen){
						changeStatusScreen = true;
						isShowFullScreen = false;
						fullScreenTimer.Stop();
					}else resetTimer();
				} else if (Input.GetAxis ("Mouse X") > 0) {
				//Code for action on mouse moving right
				//Debug.Log("Mouse moved right");
					arroundRight ();
					if(isShowFullScreen){
						changeStatusScreen = true;
						isShowFullScreen = false;
						fullScreenTimer.Stop();
					}else resetTimer();
				}*/
			}
		
			if (update) {

				//StartCoroutine (sysServer ());
				update = false;
			}
			if (shownextCarousel) {
				shownextCarousel = false;
				StartCoroutine (loadcrosel ());
			}

			/*
			if (Input.GetKey (KeyCode.Z)) {
				Vector3 p = Camera.main.transform.position;
				result += p.ToString () + ";";

				result += "\nstatic Vector3 " + currentBlock + "_" + currentFloor + "lookat" + nameCameraPostion + " = new Vector3 " + target.ToString () + ";";

				writetofile.append2File (cameraangle, result);
				result = "";
			}
		/*
			if (Input.GetKey (KeyCode.X)) {

				Vector3 p = GameObject.Find ("block8_1").transform.position;
				//Debug.Log(startAnimation.transform.position-p);

				for (int i = 1; i<231; i++) {
					GameObject x = GameObject.Find ("b81" + i);
					if (x != null) {					
						resultPostion += "\nstatic Vector3 f" + i + " = new Vector3 " + (x.transform.position - p).ToString () + ";";
					}
				}
				writetofile.append2File (pointPostions, resultPostion);
				resultPostion = "";*/
				/*
			Vector3 p = cube.transform.position - GameObject.Find("block8_3").transform.position;
			resultPostion ="\nstatic Vector3 p"+index+" = new Vector3 "+ p.ToString () + ";";
			writetofile.append2File(pointPostions,resultPostion);
			index++;
			resultPostion="";

*/
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
			//}
			/*
			if (Input.GetKey (KeyCode.C)) {
				float delta = 4.31f;
				for (int i = 1; i<67; i++) {
					GameObject x = GameObject.Find ("b" + blckk + flor + i);
					if (x != null) {
						Vector3 p = x.transform.position - GameObject.Find ("block" + blckk + "_" + flor).transform.position;
						resultPostion += "\nstatic Vector3 o" + i + " = new Vector3 " + p.ToString () + ";";

						if ((i > 0 && i < 6) || (i > 22 && i < 28) || (i == 44 || i == 59)) {
							frontPoints += "\nstatic Vector3 f" + i + " = new Vector3 " + (p - new Vector3 (0, 0, delta)).ToString () + ";";
						} else if ((i > 6 && i < 11) || (i > 28 && i < 33)) {
							frontPoints += "\nstatic Vector3 f" + i + " = new Vector3 " + (p - new Vector3 (-delta, 0, 0)).ToString () + ";";
						} else if ((i > 10 && i < 17) || (i > 33 && i < 39)) {
							frontPoints += "\nstatic Vector3 f" + i + " = new Vector3 " + (p - new Vector3 (0, 0, -delta)).ToString () + ";";
						} else if ((i > 17 && i < 22) || (i > 39 && i < 44) || (i > 54 && i < 59)) {
							frontPoints += "\nstatic Vector3 f" + i + " = new Vector3 " + (p - new Vector3 (delta, 0, 0)).ToString () + ";";
						}
					}
				}
				writetofile.append2File (officePostion, resultPostion);
				writetofile.append2File (pointPostions, frontPoints);
			}

			if (Input.GetKey (KeyCode.L)) {
				Camera.main.transform.LookAt (target);
				Camera.main.transform.Translate (Camera.main.transform.forward * 0.75f);
			} else if (Input.GetKey (KeyCode.P)) {
				Camera.main.transform.LookAt (target);
				Camera.main.transform.Translate (Camera.main.transform.forward * -0.75f);
			}

			if (Input.GetKey (KeyCode.RightArrow)) {
				target += new Vector3 (-4f * Time.deltaTime, 0, 0);
				Camera.main.transform.Translate (new Vector3 (4f * Time.deltaTime, 0, 0));
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				target += new Vector3 (4f * Time.deltaTime, 0, 0);
				Camera.main.transform.Translate (new Vector3 (-4f * Time.deltaTime, 0, 0));
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				target += new Vector3 (0, -4f * Time.deltaTime, 0);
				Camera.main.transform.Translate (new Vector3 (0, -4f * Time.deltaTime, 0));
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				target += new Vector3 (0, 4 * Time.deltaTime, 0);
				Camera.main.transform.Translate (new Vector3 (0, 4 * Time.deltaTime, 0));
			}
			*/
			if (beginmovetonextcamera) {
				beginmovetonextcamera = false;
				setCamera (posss, lattt);
			}

			if (isShowTime) {			
				isShowTime = false;
				StartCoroutine (updateTimeLable ());
			}

			if (changeStatusScreen) {
				changeStatusScreen = false;
				GameObject.Find ("RawImageCrs").GetComponent<Animator> ().SetBool (m_FullScreenParameterId, isShowFullScreen);		
				if(isShowFullScreen){
					fullScreenVideoCrs();
					fullScreenTimer.Stop();
				}
				else{
					fullScreenTimer.Start();
					resetVideoCrs();
				}
			}
			if(isHideInfomation){
				humanPress = false;
				madeButtonTransparent(NextBtn);
				hideEventAndInfomation();
				isHideInfomation = false;
				hideInfomationTimer.Stop();
				showBlock(8);
				//Debug.Log("show Initial");
			}
		}
	}
}

