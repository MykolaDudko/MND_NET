namespace DataContext
{
    using System.Data.Entity;

    public class DataModel : DbContext
    {

        static DataModel()
        {
            Database.SetInitializer(new MyContextInitializer());
      
        }
        public DataModel()
            : base("name=DataModel")
        {
        }
        
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }

    }
}