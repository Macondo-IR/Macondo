using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Macondo.Model
{
public class List
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public string Name { get; set; }
    public List<Item> Items { get; set; }

    public List(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Items = new List<Item>();
    }

}
}