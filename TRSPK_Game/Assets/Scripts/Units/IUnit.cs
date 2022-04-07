using System;

public interface IUnit
{
    int Id { get; set; }
    string Name { get; set; }
    int HitPoints { get; set; }
    int Attack { get; set; }
    int Defence { get; set; }
    int Cost { get; set; }

    public void Joining();

}

