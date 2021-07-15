using Microsoft.AspNetCore.Mvc;
using MongoDBCRUDWithRepositoryPattern.Models;
using MongoDBCRUDWithRepositoryPattern.Services;

namespace MongoDBCRUDWithRepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : BaseMongoController<Cars>
    {
        public CarsController(CarsRepository carsRepository) : base(carsRepository)
        {
        }
    }
}
