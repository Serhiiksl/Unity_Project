
using UnityEngine;
using UnityEngine.AI;

public class AIControleCar : MonoBehaviour
{
    public Camera cam;
    private NavMeshAgent agent;
    public GameObject Front;
    private AudioSource steps, stopaudio;
    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        steps = GetComponent<AudioSource>();
        stopaudio= gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        steps.Stop();
        stopaudio.Stop();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!steps.isPlaying)
        {
            stopaudio.Stop();
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                Front.SetActive(true);
                steps.Play();
            }
            
        }
        else if(Input.GetMouseButtonUp(0) && steps.isPlaying) {
        Front.SetActive(false);
            steps.Stop();
            stopaudio.Play();
        }
        
    }
}
