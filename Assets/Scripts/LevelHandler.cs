using System.Collections; 
using System.Collections.Generic; 
using System.IO; 
using System.Xml; 
using UnityEngine; 
 
public class LevelHandler : MonoBehaviour 
{ 
    public TextAsset levelData; 

    public GameObject playerPrefab; 
    public GameObject groundPrefab; 
    public GameObject wallPrefab; 
    public GameObject pelletPrefab;
 
    private GameObject levelObject; 
 
    // Start is called before the first frame update 
    void Start() 
    { 
        levelObject = new GameObject("Level"); 
        levelObject.transform.localScale = new Vector3(2, 1, 2); 
 
        LoadLevel(levelData.text); 
    } 
 
    // Update is called once per frame 
    void Update() 
    { 
         
    } 
 
    private void LoadLevel(string level) { 
        XmlDocument doc = new XmlDocument(); 
        doc.Load(new StringReader(level)); 
 
        ParsePlayer(doc);
        ParseGround(doc); 
        ParseWalls(doc);
        ParsePellets(doc);
    } 
 
    private void ParsePlayer(XmlDocument doc) { 
        XmlNode main = doc.SelectSingleNode("Level/Player"); 
        if(main == null) { 
            return; 
        } 
 
        float xPos = (float)XmlConvert.ToDouble(main.Attributes["xPos"].Value); 
        float zPos = (float)XmlConvert.ToDouble(main.Attributes["zPos"].Value); 
 
        GameObject tempObject = Instantiate(playerPrefab); 
 
        tempObject.transform.localPosition = new Vector3(xPos, 1, zPos); 
    } 

    private void ParseGround(XmlDocument doc) { 
        XmlNode main = doc.SelectSingleNode("Level/Ground"); 
        if(main == null) { 
            return; 
        } 
 
        float xSc = (float)XmlConvert.ToDouble(main.Attributes["xSc"].Value); 
        float zSc = (float)XmlConvert.ToDouble(main.Attributes["zSc"].Value); 
 
        GameObject tempObject = Instantiate(groundPrefab); 
        tempObject.transform.parent = levelObject.transform; 
 
        tempObject.transform.localPosition = new Vector3((xSc/2)-0.25f, 0, (zSc/2)-0.25f); 
        tempObject.transform.localScale = new Vector3(xSc/10, 1, zSc/10); 
    } 
 
    private void ParseWalls(XmlDocument doc) { 
        XmlNode main = doc.SelectSingleNode("Level/Walls"); 
        if(main == null) { 
            return; 
        } 
 
        GameObject wallsObject = new GameObject("Walls"); 
        wallsObject.transform.parent = levelObject.transform;
        
        GameObject tempObject; 
        foreach(XmlNode node in main) { 
            float xPos = (float)XmlConvert.ToDouble(node.Attributes["xPos"].Value); 
            float zPos = (float)XmlConvert.ToDouble(node.Attributes["zPos"].Value); 
 
            tempObject = Instantiate(wallPrefab); 
            tempObject.transform.parent = wallsObject.transform; 
 
            tempObject.transform.localPosition = new Vector3(xPos, 2.5f, zPos); 
        }

        wallsObject.transform.localScale = new Vector3(1, 1, 1);
    } 

    private void ParsePellets(XmlDocument doc) {
        XmlNode main = doc.SelectSingleNode("Level/Pellets"); 
        if(main == null) { 
            return; 
        } 
 
        GameObject pelletsObject = new GameObject("Pellets"); 
        pelletsObject.transform.parent = levelObject.transform; 
 
        GameObject tempObject; 
        foreach(XmlNode node in main) { 
            float xPos = (float)XmlConvert.ToDouble(node.Attributes["xPos"].Value); 
            float zPos = (float)XmlConvert.ToDouble(node.Attributes["zPos"].Value); 
 
            tempObject = Instantiate(pelletPrefab); 
            tempObject.transform.parent = pelletsObject.transform; 
 
            tempObject.transform.localPosition = new Vector3(xPos, 1, zPos); 
        }

        pelletsObject.transform.localScale = new Vector3(1, 1, 1);
    }
} 