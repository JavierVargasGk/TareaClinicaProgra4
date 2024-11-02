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
}