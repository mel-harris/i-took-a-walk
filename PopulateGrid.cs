using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PopulateGrid : MonoBehaviour
{

    private Object[] textures;
    public GameObject UIImageTemplate;
    public GameObject ContentParent;
    // public Texture2D[] textures;

    // array = new DirectoryInfo( folderpath ).GetFiles("*.png", SearchOption.AllDirectories);
    void Start()
    {
        Populate();
    }

    void Update()
    {
        
        // Populate();

    }

    public void Populate()
    {
        //removes all previously existing images
        textures = Resources.LoadAll("screenshots", typeof(Texture2D));
        foreach (var t in textures)
        {
            Debug.Log(t.name);
            GameObject newImage = Instantiate(UIImageTemplate, ContentParent.transform);
            newImage.GetComponent<RawImage>().texture = (Texture2D)t;
        }
    }
    // public void PopulateNew(string pathname)
    // {
    //     Debug.Log(pathname);
    //     Object newTextures = Resources.Load(pathname, typeof(Texture2D));
    //     GameObject newImage = Instantiate(UIImageTemplate, ContentParent.transform);
    //     newImage.GetComponent<RawImage>().texture = (Texture2D)newTextures;
    // }

    // void Populate()
    // {
    //   Texture2D t =(Texture2D)AssetDatabase.LoadAssetAtPath<UnityEngine.Object>("Assets/screenshots/");
    // }
}
