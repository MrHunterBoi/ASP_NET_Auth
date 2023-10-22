using ASP_API.Models;

namespace ASP_API.Utils
{
    public class ProcedFull
    {
        public int IDproc { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int? Equipment_ID { get; set; }
        public int? Medicine_ID { get; set; }
        public int? Patient_ID { get; set; }
        public int? Staff_ID { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Staff Staff { get; set; }

        public ProcedFull(Proced proced) 
        {
            this.IDproc = proced.IDproc;
            this.Name = proced.Name;
            this.Price = proced.Price;
            this.Equipment_ID = proced.Equipment_ID;
            this.Medicine_ID = proced.Medicine_ID;
            this.Patient_ID = proced.Patient_ID;
            this.Staff_ID = proced.Staff_ID;
        }
    }
}
