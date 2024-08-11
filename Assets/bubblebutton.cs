using UnityEngine;
using UnityEngine.UI;

public class BubbleButton : MonoBehaviour
{
	private Animator animator;
	private Button button;

	void Start()
	{
		animator = GetComponent<Animator>();
		button = GetComponent<Button>();
		button.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick()
	{
		animator.Play("BubbleButtonAnimation");
	}
}
