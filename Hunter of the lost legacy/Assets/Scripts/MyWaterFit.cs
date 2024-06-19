using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
[ExecuteInEditMode]
public class MyWaterFit : MonoBehaviour
{
    public string waterSurfaceName;
    WaterSurface targetSurface;
    WaterSearchParameters searchParameters = new WaterSearchParameters();
    WaterSearchResult searchResult = new WaterSearchResult();
    void Start()
    {
        GameObject waterSurfaceObject = GameObject.Find(waterSurfaceName);
        if (waterSurfaceObject != null)
        {
            targetSurface = waterSurfaceObject.GetComponent<WaterSurface>();
        }
    }
    void Update()
    {
        if (targetSurface != null)
        {
            searchParameters.startPositionWS = searchResult.candidateLocationWS;
            searchParameters.targetPositionWS = gameObject.transform.position;
            searchParameters.error = 0.01f;
            searchParameters.maxIterations = 8;
            if (targetSurface.ProjectPointOnWaterSurface(searchParameters, out searchResult))
            {
                gameObject.transform.position = searchResult.projectedPositionWS;
            }
        }
    }
}