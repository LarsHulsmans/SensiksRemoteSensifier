using Sensiks.SDK.Shared.SensiksDataTypes;

public class CeilingActuator : Actuator
{
    public CeilingAnimation animation;

    public CeilingActuator(CeilingAnimation anim)
    {
        this.actuatorType = ActuatorType.CEILING;
        this.value = 0;
        this.animation = anim;
    }

    public CeilingActuator(CeilingActuator ac)
    {
        this.actuatorType = ac.actuatorType;
        this.value = ac.value;
        this.animation = ac.animation;
    }
}
