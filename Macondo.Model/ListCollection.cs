using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Macondo.Model
{
    public class ListCollection
    {
    private List<List> lists = new List<List>();

    // متد برای اضافه کردن لیست به کالکشن با Order یکتا
    public void AddList(List newList)
    {
        // تعیین Order یکتا برای لیست جدید
        int maxOrder = lists.Any() ? lists.Max(l => l.Order) : 0;
        newList.Order = maxOrder + 1;
        
        lists.Add(newList);
    }

    // متد برای حذف لیست و تنظیم مجدد Orderها
    public void RemoveList(List listToRemove)
    {
        lists.Remove(listToRemove);

        // تنظیم مجدد Orderها برای حفظ یکتا بودن
        int currentOrder = 1;
        foreach (var list in lists.OrderBy(l => l.Order))
        {
            list.Order = currentOrder;
            currentOrder++;
        }
    }

    // متد نمایش لیست‌ها
    public void DisplayLists()
    {
        foreach (var list in lists.OrderBy(l => l.Order))
        {
            Console.WriteLine($"List Name: {list.Name}, Order: {list.Order}");
        }
    }

    // متد به‌روزرسانی Order یک لیست
    public void UpdateOrder(List targetList, int newOrder)
    {
        if (newOrder < 1 || newOrder > lists.Count)
        {
            Console.WriteLine("Invalid Order.");
            return;
        }

        // جابجا کردن Order بقیه لیست‌ها
        var affectedLists = lists.Where(l => l.Order >= newOrder && l != targetList).OrderBy(l => l.Order).ToList();
        targetList.Order = newOrder;

        int nextOrder = newOrder + 1;
        foreach (var list in affectedLists)
        {
            list.Order = nextOrder++;
        }
    } 
    }
}