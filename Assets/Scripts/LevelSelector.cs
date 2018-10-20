using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public Button[] levels;

	void Awake () {
        int levelNum = 0;
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        while (levelNum < levelReached) {
            levels[levelNum].interactable = true;
            GameObject lockObj = levels[levelNum].transform.Find("Lock").gameObject;
            lockObj.SetActive(false);
            levelNum++;
        }
        while (levelNum < levels.Length) {
            levels[levelNum].interactable = false;
            GameObject lockObj = levels[levelNum].transform.Find("Lock").gameObject;
            lockObj.SetActive(true);
            levelNum++;
        }
	}
	
}
