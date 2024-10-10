using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Macondo.Model.Enums;
namespace Macondo.Model
{
 public class Item
{
 public Guid Id { get; set; } // شناسه منحصر به فرد هر آیتم
    public string Name { get; set; } // نام آیتم
    public ItemType Type { get; set; } // نوع آیتم (از enum)

    // سازنده برای ایجاد آیتم جدید
    public Item(string name, ItemType type)
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = type;
    }
}
}