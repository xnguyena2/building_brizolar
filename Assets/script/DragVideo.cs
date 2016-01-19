using UnityEngine;
using System.Collections;
using MP;
using UnityEngine.EventSystems;
using System.IO;

public class DragVideo : MonoBehaviour ,IBeginDragHandler,IDragHandler,IEndDragHandler{
	public static GameObject video;
	public MoviePlayer movieShow;
	Vector3 postion;
	Vector3 ofset;
	private LoadOptions loadOptions = LoadOptions.Default;
	int screenWidth;
	int screenHeigh;
	float offsetx,offsety;
	float officeVideoPosx, officeVideoPosy;
	
	void Start(){
		offsetx = 167f;
		offsety = 101f;
		screenWidth = Screen.width;
		screenHeigh = Screen.height;
		officeVideoPosx = transform.position.x - offsetx;
		officeVideoPosy = screenHeigh - transform.position.y - offsety;
		//Debug.Log (System.IO.Directory.GetCurrentDirectory());
		loadOptions.videoStreamInfo = new VideoStreamInfo();
		loadOptions.videoStreamInfo.codecFourCC = MP.Decoder.VideoDecoderMJPEG.FOURCC_MJPG;
		movieShow.loadOptions = loadOptions;
		movieShow.loop = true;
		//movieShow.audioSource = null;
		//StartCoroutine (loadvideo ());
	}
	
	public void loadVideoFromUrl(string url,System.Action callback){
		//return loadvideoPath ("C:\\Users\\Nguyen Phong\\Documents\\Visual Studio 2013\\Projects\\Admin Manager\\Server\\bin\\Release\\video\\a.avi", callback);
		StartCoroutine( loadvideoUrl (url, callback));
	}
	
	public void updateLocationVideo(float x, float y){
		StartCoroutine (updatelocationVideo (x,y));
	}
	
	IEnumerator updatelocationVideo(float x, float y){
		offsetx = x;
		offsety = y;
		movieShow.customScreenRect.x = transform.position.x - offsetx;// = new Rect (postion.x, postion.y, 200, 200);
		movieShow.customScreenRect.y = screenHeigh - transform.position.y - offsety;
		yield return null;
	}
	
	IEnumerator loadvideoUrl (string url, System.Action callback)
	{
		// download		
		offsetx = 167f;
		offsety = 101f;
		WWW www = new WWW(url);
		
		while(!www.isDone) yield return 1;
		
		// load and play
		if (www.bytes.Length > 0) 
		{
			ControlEvent.currentvideo = true;
			movieShow.Load (www.bytes);
			//movieShow.drawToScreen = true;
			movieShow.customScreenRect = new Rect (officeVideoPosx, officeVideoPosy, 332, 202);
			movieShow.play = true;
			//movieShow.loop = true;
			if(callback != null) callback();
		}
		yield return null;
	}
	
	
	IEnumerator loadvideoPath (string path, System.Action callback)
	{
		// download
		
		offsetx = 167f;
		offsety = 101f;
		if (System.IO.File.Exists (path)) {
			ControlEvent.currentvideo = true;
			movieShow.Load (path);
			//movieShow.drawToScreen = true;
			movieShow.customScreenRect = new Rect (officeVideoPosx, officeVideoPosy, 332, 202);
			movieShow.play = true;
			//movieShow.loop = true;
			if(callback != null) callback();
		}
		yield return null;
	}
	
	
	#region IBeginDragHandler implementation
	
	public void OnBeginDrag (PointerEventData eventData)
	{
		video = gameObject;
		postion = transform.position;
		ofset = postion - Input.mousePosition;
		movieShow.customScreenRect.x = transform.position.x - offsetx;// = new Rect (postion.x, postion.y, 200, 200);
		movieShow.customScreenRect.y = screenHeigh - transform.position.y - offsety;
	}
	
	#endregion
	
	
	
	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition + ofset;
		movieShow.customScreenRect.x = transform.position.x - offsetx;// = new Rect (postion.x, postion.y, 200, 200);
		movieShow.customScreenRect.y = screenHeigh - transform.position.y - offsety;
	}
	#endregion
	
	#region IEndDragHandler implementation
	
	public void OnEndDrag (PointerEventData eventData)
	{
		
	}
	
	#endregion
}
