//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoSubscriptionAccounting.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subscriber
    {
        public Subscriber()
        {
            this.Deliveries = new HashSet<Delivery>();
        }
    
        public int Id { get; set; }
        public string SurnameNP { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int Apartment { get; set; }
    
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
