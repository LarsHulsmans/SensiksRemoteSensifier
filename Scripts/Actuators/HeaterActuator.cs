using Sensiks.SDK.Shared.SensiksDataTypes;

public class HeaterActuator : Actuator
{
    public HeaterPosition position;

    public HeaterActuator(HeaterPosition pos)
    {
        this.actuatorType = ActuatorType.HEATER;
        this.value = 0;
        this.position = pos;
    }

    public HeaterActuator(HeaterActuator ac)
    {
        this.actuatorType = ac.actuatorType;
        this.position = ac.position;
        this.value = ac.value;
    }
}
