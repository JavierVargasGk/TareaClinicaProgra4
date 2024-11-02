namespace TareaClinicaProgra4.Models;

public class Virus
{
    private int id;
    private String nombre;
    private DateTime fecha;
    private int mortalidad;
    private int contagio;
    private String peligrosidad;
    public Virus(int id, string nombre, DateTime fecha, int mortalidad, int contagio)
    {
        this.id = id;
        this.nombre = nombre;
        this.fecha = fecha;
        this.mortalidad = mortalidad;
        this.contagio = contagio;
        this.peligrosidad = AsignarPeligrosidad(mortalidad, contagio);
    }

    public Virus()
    {
        this.id = 0;
        this.nombre = "";
        this.mortalidad = 0;
        this.contagio = 0;
        this.peligrosidad = AsignarPeligrosidad(this.mortalidad, this.contagio);
        
    }
    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
    public int Mortalidad { get => mortalidad; set => mortalidad = value; }
    public int Contagio { get => contagio; set => contagio = value; }
    public string Peligrosidad { get => peligrosidad; set => peligrosidad = value; }

    public string AsignarPeligrosidad(int mortalidad, int contagio)
    {
        int indicePeligrosidad = mortalidad * contagio;
        if (indicePeligrosidad < 30 && indicePeligrosidad >= 1)
        {
            return "Bajo";
        }

        if (indicePeligrosidad <= 65 && indicePeligrosidad >= 30)
        {
            return "Medio";
        }
        if (indicePeligrosidad > 65)
        {
            return "Alto";
        }

        return "Sin peligro alguno";
    }
    
    
    
}