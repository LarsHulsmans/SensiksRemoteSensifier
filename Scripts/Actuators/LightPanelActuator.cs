using Sensiks.SDK.Shared.SensiksDataTypes;

public class LightPanelActuator : Actuator
{
    public LightPanelPosition position;

    public float rValue;
    public float gValue;
    public float bValue;

    public LightPanelActuator(LightPanelPosition pos)
    {
        this.actuatorType = ActuatorType.LIGHT_PANEL;
        this.position = pos;
    }

    public LightPanelActuator(LightPanelActuator ac)
    {
        this.actuatorType = ac.actuatorType;
        this.position = ac.position;
        this.value = ac.value;
        this.rValue = ac.rValue;
        this.gValue = ac.gValue;
        this.bValue = ac.bValue;
    }
}
