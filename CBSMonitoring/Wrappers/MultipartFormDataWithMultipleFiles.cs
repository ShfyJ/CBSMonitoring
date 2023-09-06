using CBSMonitoring.DTOs;
using Swashbuckle.AspNetCore.JsonMultipartFormDataSupport.Attributes;

namespace CBSMonitoring.Wrappers
{
    public class MultipartFormDataWithMultipleFiles<TJson>
    {
        #nullable disable
        [FromJson]
        public TJson Json { get; set; }
        #nullable enable
        public IFormCollection? FileItems { get; set; }   
    }
}
