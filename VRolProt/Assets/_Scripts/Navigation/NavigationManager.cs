using UnityEngine;

public class NavigationManager : MonoBehaviour {

    public static GameObject MainChar;
    
    public GameObject ClickEffectObject;

    private SimpleAgentScript agent;

    public bool Disabled { get; internal set; }

    void Start () {
        MainChar = this.gameObject;
        agent = gameObject.GetComponent<SimpleAgentScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalConfig.CharControlEnabled && !Disabled && Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(GlobalConfig.MainCamera.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.MoveCommand(hit.point);
                CreateClickEffect(hit.point);
            }
        }
    }
    private void CreateClickEffect(Vector3 position)
    {
        if (ClickEffectObject == null)
            return;
        var clickObject = (GameObject)Instantiate(ClickEffectObject);
        clickObject.transform.position = position;
    }
}
