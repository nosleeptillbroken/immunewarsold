using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour 
{

	public Canvas quitMenu;
	public Button startButton;
	public Button exitButton;

	void Start()
	{
		quitMenu = quitMenu.GetComponent<Canvas>();
		startButton = startButton.GetComponent<Button>();
		exitButton = exitButton.GetComponent<Button>();
		quitMenu.enabled = false;
	}

	public void exitPressed()
	{
		quitMenu.enabled = true;
		startButton.enabled = false;
		exitButton.enabled = false;
	}

	public void noPressed()
	{
		quitMenu.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;
	}

	public void startLevel()
	{
		SceneManager.LoadScene(1);
	}

	public void exitGame()
	{
		Application.Quit();
	}
}