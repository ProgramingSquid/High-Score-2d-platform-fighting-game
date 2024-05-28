using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI highScore;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Retry(int level)
    {
        Application.LoadLevel(level);
    }
    public void PlayerDeath()
    {
        gameObject.active = true;
        player.active = false;
        int currentScore = FindObjectOfType<ScoreManager>().score;
        finalScore.SetText($"Final Score: {currentScore.ToString()}");
        string fileName = Application.persistentDataPath + "/HighScore.txt";
        if (File.Exists(fileName))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(fileName, FileMode.Open);
            int oldHighScore = (int)formatter.Deserialize(stream);
             

            if(oldHighScore > currentScore)
            {
                highScore.text = $"High Score: {oldHighScore.ToString()}";
                stream.Close();
                
            }
            else
            {
                highScore.text = $"High Score: {currentScore.ToString()}";
                stream.Close(); 
                FileStream save = new FileStream(fileName, FileMode.Create);
                formatter.Serialize(save, currentScore);
                save.Close();
                

            }
            
        }
        else
        {
            highScore.text = $"High Score: {currentScore.ToString()}";
            FileStream save = new FileStream(fileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(save, currentScore);
            save.Close();
           
        }
    }
}
