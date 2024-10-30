using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIhandler : MonoBehaviour
{
    public float displayTime = 4.0f;
    private VisualElement m_NonPlayerDialogue;
    private float m_TimerDisplay;


    public static UIhandler instance { get; private set; }
    private VisualElement m_Healthbar;

   private void Awake()
   {
      instance = this;
      
   }


   // Start is called before the first frame update
   void Start()
   {
       UIDocument uiDocument = GetComponent<UIDocument>();
       m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
       SetHealthValue(1.0f);

        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        m_NonPlayerDialogue.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;
    
   }
   
   
      private void Update()
   {
       if (m_TimerDisplay > 0)
       {
           m_TimerDisplay -= Time.deltaTime;
       }
            if (m_TimerDisplay < 0)
                {
                    m_NonPlayerDialogue.style.display = DisplayStyle.None;
                }
   }

          public void SetHealthValue(float percentage)
   {
       m_Healthbar.style.width = Length.Percent(47 * percentage);
   }



    public void DisplayDialogue()
    {
        m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }
}
