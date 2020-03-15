/*
 * کنترولر کارت، کار افزودن و حذف کارت را انجام میدهد
 * اما یک وظیفه دیگری را نیز انجام میدهد
 * یعنی کار با سشن
 * در واقع کار با سشن به کنترولر ربطی ندارد
 * بخاطر همین باید کاری کنیم که خود کارت مسئولیت ذخیره کردن خودش را نیز انجام دهد
 * اما نکته این است که کارت در دامین قرار دارد
 * یعنی به هیچ تکنولوژی وابسته نیست
 * اگر عملیات ذخیره و بازیابی سشن را در خود کارت انجام دهیم وابسته می شویم به سشن های وب
 * اگر در آینده بخواهیم کارت را در مثلا موبایل استفاده کنیم نمی شود
 * پس به یک ساب کلاس از کارت نیاز داریم که عملیات سشن را به آن اضافه کنیم
 * این پیاده سازی برای وب است
 * اگر در آینده برای موبایل خواستیم باید از کارت ارث بری کنیم و عملیات مورد نظر را اضافه کنیم
 * پس در نتیجه این کلاس را بصورت زیر ایجاد می کنیم
 * 
 * 
 * proxy design pattern
 */


using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using MyStore.Core.Domain.Carts;
using MyStore.Core.Domain.Products;
using MyStore.EndPoints.WebUI.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.EndPoints.WebUI.Models.Carts
{
    public class SessionCart:Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
            ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}


/*
 * you are only concerned about private members are inherited or not?
 * Answer is yes, all private members are inherited but you cant access them without reflection.
 * Example :

public class Base
{
    private int value = 5;

    public int GetValue()
    {
        return value;
    }
}

public class Inherited : Base
{
    public void PrintValue()
    {
        Console.WriteLine(GetValue());
    }
}

static void Main()
{
    new Inherited().PrintValue();//prints 5
}

 * 
 */
