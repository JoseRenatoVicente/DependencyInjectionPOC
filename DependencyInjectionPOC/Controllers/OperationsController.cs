using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {

        private readonly IOperationTransient _transientOperation1;
        private readonly IOperationTransient _transientOperation2;

        private readonly IOperationSingleton _singletonOperation1;
        private readonly IOperationSingleton _singletonOperation2;

        private readonly IOperationScoped _scopedOperation1;
        private readonly IOperationScoped _scopedOperation2;

        public OperationsController(IOperationTransient transientOperation1, IOperationTransient transientOperation2, IOperationSingleton singletonOperation1, IOperationSingleton singletonOperation2, IOperationScoped scopedOperation1, IOperationScoped scopedOperation2)
        {
            _transientOperation1 = transientOperation1;
            _transientOperation2 = transientOperation2;
            _singletonOperation1 = singletonOperation1;
            _singletonOperation2 = singletonOperation2;
            _scopedOperation1 = scopedOperation1;
            _scopedOperation2 = scopedOperation2;
        }

        [HttpGet("All")]
        public IEnumerable<string> GetAll()
        {
            return new string[]
            {
              "Transient: " + _transientOperation1.OperationId,
              "Scoped: " + _scopedOperation1.OperationId,
              "Singleton: " + _singletonOperation1.OperationId
            };
        }

        [HttpGet("Transient")]
        public IEnumerable<string> GetTransient()
        {
            return new string[]
            {
              "Transient Instance 1: " + _transientOperation1.OperationId,
              "Transient Instance 2: " + _transientOperation2.OperationId
            };

        }

        [HttpGet("Scoped")]
        public IEnumerable<string> GetScoped()
        {
            return new string[]
            {
              "Scoped Instance 1: " + _scopedOperation1.OperationId,
              "Scoped Instance 1: " + _scopedOperation2.OperationId
            };

        }

        [HttpGet("Singleton")]
        public IEnumerable<string> GetSingleton()
        {
            return new string[]
            {
              "Singleton Instance 1: " + _singletonOperation1.OperationId,
              "Singleton Instance 1: " + _singletonOperation2.OperationId
            };
        }
    }
}
