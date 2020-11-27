using System.Collections.Generic;

namespace TacoLoco.Contracts.Responses
{
    public class ErrorResponse
    {
        public List<ErrorModels> Errors { get; set; }= new List<ErrorModels>();
    }
}
