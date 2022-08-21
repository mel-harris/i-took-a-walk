using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class screenshotTaker : MonoBehaviour
{
    // public FirstPersonController firstPersonController;
    public PopulateGrid grid;
    public static bool GameIsPaused = false;
    public GameObject cameraUI;
    // public GameObject preview;



    public void OnClickScreenCaptureButton(){
        StartCoroutine(CaptureScreen());

    }
    
    public IEnumerator CaptureScreen(){
        yield return null;
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;

        // turn off current post processing volume
        // turn on new post processing volume
        yield return new WaitForEndOfFrame();
        string filename = System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png";
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/Resources/screenshots/" + filename);
        // System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
        UnityEditor.AssetDatabase.Refresh();
        Debug.Log("screenshot taken");
        
        // grid.Populate(Application.dataPath + "/Resources/screenshots/" + filename);

        // turn on new 
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
// turn back on current post processing volume
    }
    void Update(){
       if (Input.GetMouseButtonDown(2)){
           OnClickScreenCaptureButton();
       }

       if (Input.GetKeyDown(KeyCode.Space))
       {
           if (GameIsPaused)
           {
               Resume();
           } else
           {
               Pause();
           }
           
       }
    //    if (Input.GetKeyDown(KeyCode.V))
    //    {
    //        if (PreviewUp)
    //        {
    //            Return();
    //        } else
    //        {
    //            ShowPreview();

    //        }
    //    }
   }

   void Resume ()
   {
       cameraUI.SetActive(false);
       Time.timeScale = 1f;
       GameIsPaused = false;
    //    this.firstPersonController.mouseLookEnabled = true;
   }

   void Pause ()
   {
       cameraUI.SetActive(true);
       Time.timeScale = 0f;
       GameIsPaused = true;
    //    this.firstPersonController.mouseLookEnabled = false;
   }

//    void Return ()
//    {
//        preview.SetActive(false);
//        Time.timeScale = 1f;
//        PreviewUp = false;
//    }
//    void ShowPreview ()
//    {
//        preview.SetActive(true);
//        Time.timeScale = 0f;
//        PreviewUp = true;
//    }
}


