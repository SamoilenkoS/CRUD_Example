using CRUD_DAL.Entities;
using LinqToDB.Mapping;

namespace CRUD_DAL.DbConfiguration
{
    public class CRUDMappingSchema : MappingSchema
    {
        public CRUDMappingSchema()
        {
            GetFluentMappingBuilder()
                .Entity<Product>()
                .HasAttribute(new TableAttribute("Products") {IsColumnAttributeRequired = false})
                .HasPrimaryKey(x => x.Id);
        }
    }
}
