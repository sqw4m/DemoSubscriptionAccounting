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
    
    public partial class PublicationType
    {
        public PublicationType()
        {
            this.Publications = new HashSet<Publication>();
        }
    
        public int Id { get; set; }
        public string TypeName { get; set; }
    
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
