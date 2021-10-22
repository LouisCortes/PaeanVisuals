using UnityEngine;
using Pcx;

[ExecuteInEditMode]
public class liquideAnimation : MonoBehaviour
{
    [SerializeField] PointCloudData _sourceData = null;
    [SerializeField] ComputeShader _computeShader = null;

    public float _audio1 = 0;
    public float _audio2 = 0;
    public float _liquide = 0;
    public Texture noise;
    public GettingStartedReceiving osc;
    // public fluid_dynamics fluid;
    ComputeBuffer _pointBuffer;
     public GameObject obj;
    //public GameObject probe;
    void OnDisable()
    {
        if (_pointBuffer != null)
        {
            _pointBuffer.Release();
            _pointBuffer = null;
        }
    }

    void Update()
    {
        if (_sourceData == null) return;

        var sourceBuffer = _sourceData.computeBuffer;

        if (_pointBuffer == null || _pointBuffer.count != sourceBuffer.count)
        {
            if (_pointBuffer != null) _pointBuffer.Release();
            _pointBuffer = new ComputeBuffer(sourceBuffer.count, PointCloudData.elementSize);
        }

        var time = Application.isPlaying ? Time.time : 0;

        var kernel = _computeShader.FindKernel("Main");
        _computeShader.SetFloat("audio1", _audio1+osc.audio1);
        _computeShader.SetFloat("audio2", _audio2+osc.audio2+osc.address02+osc.fac2+osc.mid);
        _computeShader.SetFloat("liquide", _liquide+osc.liquide3);
        _computeShader.SetFloat("wpx", obj.transform.position.x);
        _computeShader.SetFloat("wpy", obj.transform.position.y);
        _computeShader.SetFloat("wpz", obj.transform.position.z);
        _computeShader.SetTexture(kernel,"noise", noise);
        //_computeShader.SetTexture(kernel, "fluid", fluid.texture1);
        //_computeShader.SetTexture(kernel, "ref", probe.GetComponent<ReflectionProbe>().texture);
        _computeShader.SetFloat("time", time);
        _computeShader.SetBuffer(kernel, "SourceBuffer", sourceBuffer);
        _computeShader.SetBuffer(kernel, "OutputBuffer", _pointBuffer);
        _computeShader.Dispatch(kernel, sourceBuffer.count / 128, 1, 1);

        GetComponent<PointCloudRenderer>().sourceBuffer = _pointBuffer;
    }
}
