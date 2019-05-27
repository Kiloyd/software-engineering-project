using System.Collections; 
using System.Collections.Generic; 
using System.IO; 
using System.Xml; 
using UnityEngine; 
 
public class LevelHandler : MonoBehaviour 
{
    [SerializeField]
    private TextAsset levelData; 

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject groundPrefab;

    [SerializeField]
    private GameObject wallPrefab; 

    [SerializeField]
    private GameObject pelletPrefab;

    [SerializeField]
    private GameObject stationPrefab;

    [SerializeField]
    private GameObject cratePrefab;
 
    private GameObject levelObject; 
 
    void Start() 
    { 
        levelObject = new GameObject("Level"); 
        levelObject.transform.localScale = new Vector3(2, 1, 2); 
 
        LoadLevel(levelData.text); 
    } 
 
    private void LoadLevel(string level) { 
        XmlDocument doc = new XmlDocument(); 
        doc.Load(new StringReader(level)); 
 
        ParsePlayer(doc);
        ParseGround(doc); 
        ParseWalls(doc);
        ParsePellets(doc);
        ParseStations(doc);
        ParseCrates(doc);
        ParseItems(doc);
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
        GameObject tempObject = Instantiate(groundPrefab); 
        tempObject.transform.parent = levelObject.transform; 

        XmlNode main = doc.SelectSingleNode("Level/Ground"); 
        if(main == null) { 
            return; 
        } 
 
        float xSc = (float)XmlConvert.ToDouble(main.Attributes["xSc"].Value); 
        float zSc = (float)XmlConvert.ToDouble(main.Attributes["zSc"].Value); 
 
        tempObject.transform.localPosition = new Vector3((xSc/2)-0.25f, 0, (zSc/2)-0.25f); 
        tempObject.transform.localScale = new Vector3(xSc/10, 1, zSc/10); 
    } 
 
    private void ParseWalls(XmlDocument doc) { 
        GameObject wallsObject = new GameObject("Walls"); 
        wallsObject.transform.parent = levelObject.transform;

        XmlNode main = doc.SelectSingleNode("Level/Walls"); 
        if(main == null) { 
            return; 
        } 
        
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
        GameObject pelletsObject = new GameObject("Pellets"); 
        pelletsObject.transform.parent = levelObject.transform; 

        XmlNode main = doc.SelectSingleNode("Level/Pellets"); 
        if(main == null) { 
            return; 
        } 
 
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

    private void ParseStations(XmlDocument doc) {
        GameObject stationsObject = new GameObject("Stations"); 
        stationsObject.transform.parent = levelObject.transform; 

        XmlNode main = doc.SelectSingleNode("Level/Stations"); 
        if(main == null) { 
            return; 
        } 
 
        GameObject tempObject; 
        foreach(XmlNode node in main) { 
            float xPos = (float)XmlConvert.ToDouble(node.Attributes["xPos"].Value); 
            float zPos = (float)XmlConvert.ToDouble(node.Attributes["zPos"].Value); 
 
            tempObject = Instantiate(stationPrefab); 
            tempObject.transform.parent = stationsObject.transform; 
 
            tempObject.transform.localPosition = new Vector3(xPos, 1, zPos); 
        }

        stationsObject.transform.localScale = new Vector3(1, 1, 1);
    }

    private void ParseCrates(XmlDocument doc) {
        GameObject cratesObject = new GameObject("Crates");
        cratesObject.transform.parent = levelObject.transform;

        XmlNode main = doc.SelectSingleNode("Level/Crates");
        if(main == null) {
            return;
        }

        GameObject tempObject;
        foreach(XmlNode node in main) {
            float xPos = (float)XmlConvert.ToDouble(node.Attributes["xPos"].Value); 
            float yPos = (float)XmlConvert.ToDouble(node.Attributes["yPos"].Value); 
            float zPos = (float)XmlConvert.ToDouble(node.Attributes["zPos"].Value); 

            tempObject = Instantiate(cratePrefab);
            tempObject.transform.parent = cratesObject.transform;

            tempObject.transform.localPosition = new Vector3(xPos, yPos, zPos);
        }

        cratesObject.transform.localScale = new Vector3(1, 1, 1);
    }

    private void ParseItems(XmlDocument doc) {
        GameObject itemsObject = new GameObject("Items");
        itemsObject.transform.parent = levelObject.transform;

        return;
    }
} 