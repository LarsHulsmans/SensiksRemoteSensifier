using Sensiks.SDK.Shared.SensiksDataTypes;

public class ScentActuator : Actuator
{
    public Scent position;

    public ScentActuator(Scent pos)
    {
        this.actuatorType = ActuatorType.SCENT;
        this.value = 0;
        this.position = pos;
    }

    public ScentActuator(ScentActuator ac)
    {
        this.actuatorType = ac.actuatorType;
        this.position = ac.position;
        this.value = ac.value;
    }
}
