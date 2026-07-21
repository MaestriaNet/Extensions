namespace Maestria.Extensions.Tests.TestEntities;

public class PersonEntity
{
    public PersonEntity()
    {
    }

    public PersonEntity(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
}