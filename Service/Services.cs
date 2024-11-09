using System.Data.Entity;
using TareaClinicaProgra4.Models;

namespace TareaClinicaProgra4.Service;

public class Services:DbContext
{
    public Services() : base("Clinica"){}
    public DbSet<Virus> VirusDataBase { get; set; }

    public void AgregarVirus(Virus model)
    {
        if (VirusDataBase == null)
        {
            throw new ArgumentNullException();
        }

        var thingy = model.AsignarPeligrosidad(model.Mortalidad, model.Contagio);
        model.Peligrosidad = thingy.ToString();
        VirusDataBase.Add(model);
        SaveChanges();
    }

    public List<Virus> MostrarViruses()
    {
        return VirusDataBase.ToList();
    }

    public Virus BuscarVirus(int id)
    {
        var model = VirusDataBase.Where(x => x.Id == id).FirstOrDefault();
        if (model == null)
        {
            throw new ArgumentNullException();
        }
        return model;
    }

    public void EliminarVirus(Virus model)
    {
        if (model == null)
        {
            throw new ArgumentNullException();
        }
        VirusDataBase.Remove(model);
        SaveChanges();

    }

    public void EditVirus(Virus model)
    {
        if (model == null)
        {
            throw new Exception("Virus nuevo no encontrado");
        }
        var virusModificar = BuscarVirus(model.Id);
        if (virusModificar == null)
        {
            throw new Exception("Virus no encontrado");
        }
        virusModificar.Contagio = model.Contagio;
        virusModificar.Mortalidad = model.Mortalidad;
        virusModificar.Peligrosidad = virusModificar.AsignarPeligrosidad(virusModificar.Mortalidad, model.Contagio);
        virusModificar.Nombre = model.Nombre;
        virusModificar.Fecha = model.Fecha;
        SaveChanges();
    }
}