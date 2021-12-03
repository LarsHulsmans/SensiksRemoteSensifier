using Sensiks.SDK.Shared.SensiksDataTypes;

public class FanActuator : Actuator
{
    public FanPosition position;

    public FanActuator(FanPosition pos)
    {
        this.actuatorType = ActuatorType.FAN;
        this.value = 0;
        this.position = pos;
    }

    public FanActuator(FanActuator ac)
    {
        this.actuatorType = ac.actuatorType;
        this.position = ac.position;
        this.value = ac.value;
    }
}
