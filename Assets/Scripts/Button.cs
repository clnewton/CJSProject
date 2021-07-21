using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
	[SerializeField] ButtonController buttonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;

    public bool changeScene;
	public bool quitButton;
	public string scene;

    // Update is called once per frame
    void Update()
    {
		if(buttonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;

				if(changeScene){
					SceneManager.LoadScene(scene);
				}
				else if(quitButton)
				{
					Application.Quit();
				}
			}
		}else{
			animator.SetBool ("selected", false);
		}
    }
}
